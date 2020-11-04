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

        private void btnSobel_Click(object sender, EventArgs e)
        {
            if (!_streaming)
            {
                Application.Idle += StreamSobel;
            }
            else
            {
                Application.Idle -= StreamSobel;
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
            var grayScaleImage = img.Convert<Gray, byte>();
            var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            var cannyImage = new UMat();
            CvInvoke.Canny(blurredImage, cannyImage, 20, 20);
            var bmp = cannyImage.Bitmap;
            picStream.Image = bmp;
        }

        private void StreamOrigin(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            var bmp = img.Bitmap;
            picOutput.Image = bmp;
        }

        private void StreamSobel(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            var grayScaleImage = img.Convert<Gray, byte>();
            Image<Gray, float> imgSobel = new Image<Gray, float>(picStream.Width, picStream.Height, new Gray(0));

            imgSobel = grayScaleImage.Sobel(0, 1, 3).Add(grayScaleImage.Sobel(1, 0, 3)).AbsDiff(new Gray(0.0)); ;
            var bmp = imgSobel.Bitmap;
            picStream.Image = bmp;
        }

        private void StreamLaplas(object sender, System.EventArgs e)
        {
            var img = _capture.QueryFrame().ToImage<Bgr, Byte>().Flip(FlipType.Horizontal);
            var grayScaleImage = img.Convert<Gray, byte>();
            Image<Gray, float> imgLaplas = new Image<Gray, float>(picStream.Width, picStream.Height, new Gray(0));

            imgLaplas = grayScaleImage.Laplace(5).Add(grayScaleImage.Laplace(5).AbsDiff(new Gray(0.0)));
            var bmp = imgLaplas.Bitmap;
            picStream.Image = bmp;
        }
    }
}
