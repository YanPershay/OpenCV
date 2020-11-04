using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System;
using System.Drawing;

namespace Lab2
{
    class Program
    {
        static void Main(string[] args)
        {
            Image<Bgr, Byte> img1 = new Image<Bgr, Byte>("E:/kit.jpg");

            Image<Bgr, Byte> img2 = new Image<Bgr, Byte>("E:/kit.jpg");
            Matrix<float> kernelData = new Matrix<float>(
              new float[,]
              {
                    {-1.0f, 0.2f, -0.1f},
                    {0.2f, 3.0f, 0.2f},
                    {-1.0f, 0.2f, -1.0f},
              });
            Point anchor = new Point(-1, -1);
            CvInvoke.Filter2D(img1, img2, kernelData, anchor);
            //img2.Save("E:/outConvolution.jpg");
            CvInvoke.Imwrite("E:/outConvolution.jpg", img1.ConcateHorizontal(img2));

            Image<Bgr, byte> blur = img1.SmoothBlur(10, 10, true);
            //blur.Save("E:/outBlur.jpg");
            CvInvoke.Imwrite("E:/outBlur.jpg", img1.ConcateHorizontal(blur));


            Image<Bgr, byte> gauss = img1.SmoothGaussian(9, 9, 34.3, 45.3);
            //gauss.Save("E:/outGaussian.jpg");
            CvInvoke.Imwrite("E:/outGauss.jpg", img1.ConcateHorizontal(gauss));

            Image<Bgr, byte> mediansmooth = img1.SmoothMedian(15);
            //mediansmooth.Save("E:/outMedian.jpg");
            CvInvoke.Imwrite("E:/outMedian.jpg", img1.ConcateHorizontal(mediansmooth));

            Image<Bgr, Byte> img3 = img1;
            CvInvoke.BoxFilter(img1, img3, DepthType.Default, new Size(200, 300), anchor);
            //img3.Save("E:/outBoxFilter.jpg");
            CvInvoke.Imwrite("E:/outBoxFilter.jpg", img1.ConcateHorizontal(img3));

            Image<Gray, Single> img4 = img1.Convert<Gray, Single>();
            CvInvoke.Threshold(img4, img4, 120, 255, ThresholdType.Binary);
            var img5 = img4;
            img4.Erode(10).Save("E:/outErode.jpg");
            img5.Dilate(10).Save("E:/outDilate.jpg");

            Image<Bgr, Byte> img6 = img1;
            var grayScaleImage = img6.Convert<Gray, byte>();
            var blurredImage = grayScaleImage.SmoothGaussian(5, 5, 0, 0);
            var cannyImage = new UMat();
            CvInvoke.Canny(blurredImage, cannyImage, 50, 150);
            //cannyImage.Save("E:/outCanny2_0.jpg");
            CvInvoke.Imwrite("E:/outCanny.jpg", img1.ConcateHorizontal(cannyImage.ToImage<Bgr, Byte>()));

            Image<Gray, Byte> image = new Image<Gray, Byte>("E:/kit.jpg");
            Image<Gray, Byte> result = new Image<Gray, byte>(image.Size);
            CvInvoke.CLAHE(image, 4, new Size(8, 8), result);
            CvInvoke.Imwrite("E:/outHistogram.jpg", image.ConcateHorizontal(result));
        }
    }
}
