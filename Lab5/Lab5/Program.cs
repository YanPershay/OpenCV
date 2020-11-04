using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Features2D;
using Emgu.CV.Structure;
using Emgu.CV.Util;
using System;
using System.Drawing;

namespace Lab5
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            var img = new Image<Bgr, Byte>("E:/corners.jpg");
            var gray = img.Convert<Gray, byte>();

            var corners = new Mat();
            CvInvoke.CornerHarris(gray, corners, 2);
            CvInvoke.Normalize(corners, corners, 255, 0, NormType.MinMax);

            Matrix<float> matrix = new Matrix<float>(corners.Rows, corners.Cols);
            corners.CopyTo(matrix);

            int threshold = 90;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Cols; j++)
                {
                    if (matrix[i, j] > threshold)
                    {
                        CvInvoke.Circle(img, new Point(j, i), 5, new MCvScalar(0, 0, 255), 3);
                    }
                }
            }

            img.Save("E:/harrisOut.jpg");

            var img2 = new Image<Bgr, Byte>("E:/corners.jpg");
            var gray2 = img2.Convert<Gray, byte>();

            GFTTDetector detector = new GFTTDetector(2000, 0.06);
            var corners2 = detector.Detect(gray2);

            Mat outimg = new Mat();
            Features2DToolbox.DrawKeypoints(img2, new VectorOfKeyPoint(corners2), outimg, new Bgr(0, 0, 255), Features2DToolbox.KeypointDrawType.Default);

            outimg.Save("E:/cornersFeatures.jpg");

            PointF[] srcCorners = new PointF[] {
                new PointF(897, 694),
                new PointF(890, 896),
                new PointF(1119, 899)
                };

            PointF[] destCorners = new PointF[] {
                new PointF(1995, 2977),
                new PointF(1245, 3496),
                new PointF(1899, 3999)
                };

            Mat srcImg = CvInvoke.Imread("E:/book.jpg", LoadImageType.Color);
            Mat destImg = new Mat();

            Mat warpMatrix = CvInvoke.GetAffineTransform(srcCorners, destCorners);

            CvInvoke.WarpAffine(srcImg, destImg, warpMatrix, new Size(4800, 6000),
                Inter.Linear, Warp.Default, BorderType.Transparent);

            destImg.Save("E:/outbook.jpg");
        }
    }
}
