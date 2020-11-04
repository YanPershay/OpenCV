using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

using Emgu.CV;
using Emgu.CV.Structure;

using DirectShowLib;
using System.Drawing.Imaging;
using Emgu.CV.Features2D;

namespace Lab1
{
    public partial class Form1 : Form
    {
        CascadeClassifier faceCascade = new CascadeClassifier(@"E:\7 opencv\Lab7\frontalface.xml");
       
        Mat Frame = new Mat();
        Mat Previous_Frame = new Mat();
        PointF[] Actual = new PointF[1000];


        #region Variables

        #region Camera Capture Variables
        private Emgu.CV.VideoCapture _capture = null;
        private bool _captureInProgress = false;
        int CameraDevice = 0; 
        VideoDevice[] WebCams;
        #endregion

        #region Camera Settings
        int Brightness_Store = 0;
        int Contrast_Store = 0;
        int Sharpness_Store = 0;
        #endregion

        #endregion

        public Form1()
        {
            InitializeComponent();

            DsDevice[] _SystemCamereas = DsDevice.GetDevicesOfCat(FilterCategory.VideoInputDevice);
            WebCams = new VideoDevice[_SystemCamereas.Length];
            for (int i = 0; i < _SystemCamereas.Length; i++)
            {
                WebCams[i] = new VideoDevice(i, _SystemCamereas[i].Name, _SystemCamereas[i].ClassID);
                CamSelect.Items.Add(WebCams[i].ToString());
            }
            if (CamSelect.Items.Count > 0)
            {
                CamSelect.SelectedIndex = 0; 
                Shot.Enabled = true;
            }
        }


        private void Shot_Click(object sender, EventArgs e)
        {
            if (_capture != null)
            {
                if (_captureInProgress)
                {
                    Shot.Text = "Start";
                    _capture.Pause();
                    _captureInProgress = false;
                }
                else
                {
                    Shot.Text = "Stop";
                    _capture.Start(); 
                    _captureInProgress = true;
                }

            }
            else
            {
                SetupCapture(CamSelect.SelectedIndex);
                Shot_Click(null, null);
            }
        }
        private void SetupCapture(int Camera_Identifier)
        {
            CameraDevice = Camera_Identifier;

            if (_capture != null) _capture.Dispose();
            try
            {
                _capture = new VideoCapture(CameraDevice);
                _capture.Retrieve(Frame);
                Frame.CopyTo(Previous_Frame);
                _capture.ImageGrabbed += ProcessFrame;
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }
        }

        private void ProcessFrame(object sender, EventArgs arg)
        {
            Mat frame = new Mat();
            _capture.Retrieve(frame);
            var imageToDisplay = frame.ToImage<Bgr, byte>();
            CvInvoke.MedianBlur(frame, frame, 5);

            if (Frame.GetData() == null)
            {
                _capture.Retrieve(Frame);
                Frame.CopyTo(Previous_Frame);
            }
            else
            {
                //var faces = faceCascade.DetectMultiScale(frame.ToImage<Gray, byte>(), 1.1, 10, Size.Empty);
                //foreach (var face in faces)
                //{
                //    imageToDisplay.Draw(face, new Bgr(Color.Red), 3);
                //}

                Image<Gray, byte> frame11 = Frame.ToImage<Gray, Byte>();
                //if (Frame.GetData() != null)
                //    CvInvoke.MedianBlur(frame11, frame11, 5);
                Image<Gray, byte> prev = Previous_Frame.ToImage<Gray, Byte>();
                //if(Previous_Frame.GetData() != null)
                //    CvInvoke.MedianBlur(prev, prev, 5);
                

                Byte[] status;
                Single[] trer;
                PointF[] nextFeature = new PointF[1000];
                if(prev.Height != 0 && frame11.Height != 0)
                {
                    var gftt = new GFTTDetector(1000, 0.1, 1, 10, true).Detect(frame);

                    for (int x = 0; x < gftt.Length; x++)
                    {
                        Actual[x] = new PointF(gftt[x].Point.X, gftt[x].Point.Y);
                    }

                    CvInvoke.CalcOpticalFlowPyrLK(prev, frame11, Actual, new Size(30, 30), 10, new MCvTermCriteria(400, 0.09d),
                             out nextFeature, out status, out trer);
                }

                for (int x = 0; x < nextFeature.Length; x++)
                {
                    imageToDisplay.Draw(new CircleF(new PointF(nextFeature[x].X, nextFeature[x].Y), 3f), new Bgr(Color.Blue), 2);
                }

                Actual = nextFeature;
                Previous_Frame = Frame.Clone();

                DisplayImage(imageToDisplay.ToBitmap());
            }

        }


        private delegate void DisplayImageDelegate(Bitmap Image);
        private void DisplayImage(Bitmap Image)
        {
            if (pictureBox1.InvokeRequired)
            {
                try
                {
                    DisplayImageDelegate DI = new DisplayImageDelegate(DisplayImage);
                    this.BeginInvoke(DI, new object[] { Image });
                }
                catch (Exception ex)
                {
                }
            }
            else
            {
                pictureBox1.Image = Image;
            }
        }
    }
}
