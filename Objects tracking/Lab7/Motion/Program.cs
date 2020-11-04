using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Motion
{
    class Program
    {
        public static Mat DiffImage(Mat t0, Mat t1, Mat t2)
        {
            Mat d1 = new Mat();
            Cv2.Absdiff(t2, t1, d1);

            Mat d2 = new Mat();
            Cv2.Absdiff(t1, t0, d2);

            Mat diff = new Mat();
            Cv2.BitwiseOr(d1, d2, diff);

            return diff;
        }
        static void Main(string[] args)
        {
            FrameSource cam = Cv2.CreateFrameSource_Camera(0);
            Cv2.NamedWindow("Camera", WindowMode.FullScreen);

            Mat t0 = new Mat();
            Mat t1 = new Mat();
            Mat t2 = new Mat();

            while (true)
            {
                cam.NextFrame(t0);
                cam.NextFrame(t1);
                cam.NextFrame(t2);

                Cv2.CvtColor(t0, t0, ColorConversionCodes.BGR2GRAY);
                Cv2.CvtColor(t1, t1, ColorConversionCodes.BGR2GRAY);
                Cv2.CvtColor(t2, t2, ColorConversionCodes.BGR2GRAY);

                Cv2.ImShow("Camera", DiffImage(t0, t1, t2));


                if (Cv2.WaitKey(1) == (int)ConsoleKey.Enter)
                    break;
            }
        }
    }
}
