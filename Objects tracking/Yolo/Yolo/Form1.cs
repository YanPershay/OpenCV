using Alturos.Yolo;
using Alturos.Yolo.Model;
using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yolo
{
    public partial class Form1 : Form
    {
        VideoCapture capture = new VideoCapture();
        public Form1()
        {
            InitializeComponent();
            
        }

        private void Run()
        {
            //try
            //{
            //    capture = new VideoCapture();
            //}
            //catch(Exception ex) 
            //{
            //    MessageBox.Show(ex.Message);
            //    return;
            //}
            Application.Idle += ProcessFrame;
        }

        private void ProcessFrame(object sender, EventArgs e)
        {
            var img = capture.QueryFrame().ToImage<Bgr, Byte>();
            pictureBox1.Image = img.Bitmap;
            Detect();
        }

        private void Detect()
        {
            var configurationDetector = new YoloConfigurationDetector();
            var config = configurationDetector.Detect();
            var yolo = new YoloWrapper(config);
            var memoryStream = new MemoryStream();
            pictureBox1.Image.Save(memoryStream, ImageFormat.Png);
            var items = yolo.Detect(memoryStream.ToArray()).ToList();
            AddDetailsToPictureBox(pictureBox1, items);
        }

        private void AddDetailsToPictureBox(PictureBox pictureBox1, List<YoloItem> items)
        {
            var img = pictureBox1.Image;
            var font = new Font("Arial", 18, FontStyle.Bold);
            var brush = new SolidBrush(Color.Red);
            var graphics = Graphics.FromImage(img);
            foreach(var item in items)
            {
                var x = item.X;
                var y = item.Y;
                var width = item.Width;
                var height = item.Height;
                var tung = item.Type;
                var rect = new Rectangle(x, y, width, height);
                var pen = new Pen(Color.LightGreen, 6);
                var point = new Point(x, y);

                graphics.DrawRectangle(pen, rect);
                graphics.DrawString(item.Type, font, brush, point);
            }
            pictureBox1.Image = img;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Run();
        }
    }
}
