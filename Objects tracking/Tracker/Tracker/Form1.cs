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

namespace Tracker
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        VideoCapture videoCapture = new VideoCapture();
        MCvTermCriteria cvTermCriteria = new MCvTermCriteria();
        Rectangle FollowedRectangle = new Rectangle(0, 0, 10, 10);
        RotatedRect CamShiftResult;
        private void button6_Click(object sender, EventArgs e)
        {
            cvTermCriteria.Type = TermCritType.Eps;
            Application.Idle += Process;
        }

        Image<Bgr, Byte> backgroundFrame;
        Image<Bgr, Byte> nextFrame;
        Mat absDiffResult = new Mat();
        void Process(object sender, EventArgs e)
        {
            using (backgroundFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>())
            {
                using (nextFrame = videoCapture.QueryFrame().ToImage<Bgr, Byte>())
                {
                    CvInvoke.AbsDiff(backgroundFrame, nextFrame, absDiffResult);

                    CvInvoke.Polylines(backgroundFrame, Array.ConvertAll(CamShiftResult.GetVertices(), Point.Round), true, new Bgr(Color.Red).MCvScalar, 2);

                    CamShiftResult = CvInvoke.CamShift(absDiffResult.ToImage<Gray, Byte>(), ref FollowedRectangle, cvTermCriteria);

                    pictureBox1.Image = backgroundFrame.Bitmap;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
