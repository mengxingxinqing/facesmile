using Emgu.CV;
using Emgu.CV.Structure;
using System;
using System.Drawing;
using System.Windows.Forms;
using Emgu.CV.CvEnum;
using Emgu.Util;
using System.Diagnostics;
using Emgu.CV.UI;

namespace SmileFace
{
    public partial class TrainForm : Form
    {
        Capture capture;
        static int flag = 0;
        private CascadeClassifier faceClassifier;

        private string haarXmlPath = "lbpcascade_frontalface.xml";
        public TrainForm()
        {
            InitializeComponent();
            capture = new Capture(0);
            faceClassifier = new CascadeClassifier(haarXmlPath);
            capture.ImageGrabbed += Capture_ImageGrabbed;
            capture.Start();
        }

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {

            Mat frame = new Mat();
            capture.Retrieve(frame, 0);    //接收数据
            var showFrame = frame.Clone();
            FrameRect face, smile, selectArea;
            face = getFace(frame);
            saveFace(frame,face);
            imageBox1.Image = showFrame;       //显示图像

        }

        private FrameRect getFace(Mat frame)
        {
            FrameRect face = null;
            using (UMat ugray = new UMat())
            {
                CvInvoke.CvtColor(frame, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);//灰度化图片  
                CvInvoke.EqualizeHist(ugray, ugray);//均衡化灰度图片  

                Rectangle[] facesDetected = faceClassifier.DetectMultiScale(ugray, 1.1, 10, new System.Drawing.Size(20, 20));
                if (facesDetected != null && facesDetected.Length > 0)
                {
                    face = new FrameRect(getMaxRectangle(facesDetected).rect);
                }
            }
            return face;
        }
        int index = 0;
        bool status = false;
        private void saveFace(Mat frame, FrameRect face)
        {
            if (face == null) return;
            if (!status) return;
            if (index >= 10)
            {
                status = false;
                MessageBox.Show("完成");
                return;
            }
            Image<Gray, byte> tempImg = frame.ToImage<Gray, byte>();
            Image<Gray, byte> grayFace = tempImg.Copy(face.rect).Resize(200,200,Inter.Linear);
            grayFace.Save("./face_train/" + textBox1.Text + "_" + index + ".jpg");
            index++;
            
        }

        private FrameRect getMaxRectangle(Rectangle[] list)
        {
            if (list == null) return null;
            int max = 0;
            Rectangle maxRectangle = new Rectangle(0, 0, 0, 0);
            foreach (Rectangle r in list)
            {
                if (r.Width * r.Height > max)
                {
                    max = r.Width * r.Height;
                    maxRectangle = r;
                }
            }
            return new FrameRect(maxRectangle);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            status = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Image<Gray, byte> x1 = new Image<Gray, byte>("03.jpg");
            Image<Gray, byte> x2 = new Image<Gray, byte>("04.jpg");
            Image<Gray, byte> x3 = new Image<Gray, byte>("05.jpg");
            Image<Gray, byte> x4 = new Image<Gray, byte>("06.jpg");
            Image<Gray, byte> x5 = new Image<Gray, byte>("07.jpg");

            Image<Gray, byte> y1 = new Image<Gray, byte>("11.jpg");
            Image<Gray, byte> y2 = new Image<Gray, byte>("12.jpg");
            Image<Gray, byte> y3 = new Image<Gray, byte>("13.jpg");
            Image<Gray, byte> y4 = new Image<Gray, byte>("14.jpg");
            Image<Gray, byte> y5 = new Image<Gray, byte>("15.jpg");

            Image<Gray, byte> z1 = new Image<Gray, byte>("21.jpg");
            Image<Gray, byte> z2 = new Image<Gray, byte>("22.jpg");
            Image<Gray, byte> z3 = new Image<Gray, byte>("23.jpg");
            Image<Gray, byte> z4 = new Image<Gray, byte>("24.jpg");
            Image<Gray, byte> z5 = new Image<Gray, byte>("25.jpg");

            var images = new Image<Gray, byte>[] { x1, x2, x3, x4, x5, y1, y2, y3, y4, y5, z1, z2, z3, z4, z5 };
            int[] labels = new int[] { 0, 0, 0, 0, 0, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2 };
        }
    }
}
