using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Webcam
{
    public partial class Form1 : Form
    {

        bool _streaming;
        Capture _capture;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _streaming = false;
            _capture = new Capture();
            
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            if (!_streaming)
            {
                Application.Idle += StreamOrigin;
            }
            else
            {
                Application.Idle -= StreamOrigin;
            }

            _streaming = !_streaming;
        }

        private void btnCanny_Click(object sender, EventArgs e)
        {
            if (!_streaming)
            {
                Application.Idle += StreamCanny;
            }
            else
            {
                Application.Idle -= StreamCanny;
            }

            _streaming = !_streaming;
        }

        private void btnLaplas_Click(object sender, EventArgs e)
        {
            if (!_streaming)
            {
                Application.Idle += StreamLaplas;
            }
            else
            {
                Application.Idle -= StreamLaplas;
            }

            _streaming = !_streaming;
        }

        private void StreamCanny(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            CascadeClassifier classifierFace = new CascadeClassifier("haarcascade_frontalface_default.xml");
            CascadeClassifier classifierEyes = new CascadeClassifier("haarcascade_eye.xml");
            var imgGray = img.Convert<Gray, Byte>();
            Rectangle[] faces = classifierFace.DetectMultiScale(imgGray, 1.1, 4);
            foreach (var face in faces)
            {
                img.Draw(face, new Bgr(0, 0, 255), 2);

                imgGray.ROI = face;
                Rectangle[] eyes = classifierEyes.DetectMultiScale(imgGray, 1.1, 4);
                foreach (var eye in eyes)
                {
                    var ey = eye;
                    ey.X += face.X;
                    ey.Y += face.Y;
                    img.Draw(ey, new Bgr(0, 0, 255), 2);
                }
            }
            picStream.Image = img.Bitmap;
        }

        private void StreamOrigin(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            var bmp = img.Bitmap;
            picOutput.Image = bmp;
        }

        private void StreamLaplas(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            HOGDescriptor descriptor = new HOGDescriptor();
            descriptor.SetSVMDetector(HOGDescriptor.GetDefaultPeopleDetector());

            MCvObjectDetection[] results = descriptor.DetectMultiScale(img);
            Rectangle[] regions = new Rectangle[results.Length];
            for (int i = 0; i < results.Length; i++)
                regions[i] = results[i].Rect;

            foreach (var rect in regions)
            {
                img.Draw(rect, new Bgr(Color.Red), 10);
            }
            picStream.Image = img.Bitmap;
        }
    }
}
