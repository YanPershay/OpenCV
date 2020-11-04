using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Text.RegularExpressions;

namespace OpenCVStart
{
    class Program
    {
        static void Main(string[] args)
        {
            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>("E:/kit.jpg");
            Image<Gray, Single> img2 = img1.Convert<Gray, Single>();
            //img2.Save("E:/kitout.jpg");

            CvInvoke.Threshold(img2, img2, 120, 255, ThresholdType.Binary);
            img2.Save("E:/kitblack.jpg");
        }
    }
}