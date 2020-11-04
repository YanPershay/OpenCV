using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contours
{
    class Program
    {
        static void Main(string[] args)
        {
            Image<Bgr, Byte> coins = new Image<Bgr, byte>("E:/coins.jpg");
            var coinsGray = coins.Convert<Gray, Byte>();
            CvInvoke.Threshold(coinsGray, coinsGray, 120, 255, ThresholdType.Binary);
            //var tresholdCoins = coinsGray;
            VectorOfVectorOfPoint contours = new VectorOfVectorOfPoint();
            Mat m = new Mat();
            CvInvoke.FindContours(coinsGray, contours, m, RetrType.Tree, ChainApproxMethod.ChainApproxSimple);
            coinsGray.Save("E:/coinsContours.jpg");
            Console.WriteLine($"Count of contours in coins is {contours.Size}");

            var img6 = new Image<Bgr, Byte>("E:/corners.jpg");
            var grayScaleImage = img6.Convert<Gray, byte>();
            var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            var cannyImage = new UMat();
            CvInvoke.Canny(blurredImage, cannyImage, 50, 150);
            cannyImage.Save("E:/canny.jpg");
            var cannyGray = cannyImage.ToImage<Gray, byte>();
            //Call HoughLinesBinary method
            LineSegment2D[] lines = cannyGray.HoughLinesBinary(1, Math.PI, 20, 30, 10)[0];
            //Draw lines
            Image<Bgr, Byte> imageLines = new Image<Bgr,
            byte>(cannyGray.Width, cannyGray.Height);
            foreach (LineSegment2D line in lines)
            {
                imageLines.Draw(line, new Bgr(Color.Gray), 1);
            }
            //Show result
            imageLines.Save("E:/houghLines.jpg");

            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>("E:/circ.jpg");
            //Convert the img1 to grayscale and then filter out the noise
            Image<Gray, Byte> gray1 = img1.Convert<Gray, Byte>().PyrDown().PyrUp();
            //Call HoughCircles (Canny included)
            CircleF[] circles = gray1.HoughCircles(
            new Gray(180), //cannyThreshold
            new Gray(120), //accumulatorThreshold
            2.0, //dp
            15.0, //minDist
            5, //minRadius
            0 //maxRadius
            )[0];
            //Draw circles
            Image<Bgr, Byte> imageCircles = img1.CopyBlank();
            foreach (CircleF circle in circles)
            {
                imageCircles.Draw(circle, new Bgr(Color.Yellow), 5);
            }
            //Show result
            imageCircles.Save("E:/outCircles.jpg");

        }

    }
}
