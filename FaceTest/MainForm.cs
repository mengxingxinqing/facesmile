using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using SpeechLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FaceTest
{
    public partial class MainForm : Form
    {
        Capture capture;
        static int flag = 0;

        private string haarXmlPath = "lbpcascade_frontalface.xml";
        private string smileXmlPath = "haarcascade_smile.xml";
        private CascadeClassifier faceClassifier;
        private CascadeClassifier smileClassifier;
        private string ftpIp;
        private string ftpUser;
        private string ftpPwd;

        private int imgWidth;
        private int imgHeigth;

        public MainForm()
        {
            InitializeComponent();
            // 加入这行
            Control.CheckForIllegalCrossThreadCalls = false;
            try
            {
                capture = new Capture(0);
                capture.ImageGrabbed += Capture_ImageGrabbed;
                capture.Start();

                faceClassifier = new CascadeClassifier(haarXmlPath);
                smileClassifier = new CascadeClassifier(smileXmlPath);
                ftpIp = ConfigurationManager.AppSettings["FtpIp"];
                ftpUser = ConfigurationManager.AppSettings["FtpUser"];
                ftpPwd = ConfigurationManager.AppSettings["FtpPwd"];
                tb_tel.Focus();
                ReadConfig(ConfigurationManager.AppSettings["UserListPath"]);
                imgWidth = int.Parse(ConfigurationManager.AppSettings["ImgWidth"]);
                imgHeigth = int.Parse(ConfigurationManager.AppSettings["ImgHeight"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private Image<Rgb, byte> rgbImg;
        private Rectangle faceRect;
        private Rectangle smileRect;
        private Rectangle selectRect;
        private int showRate = 4;
        private int showRateIndex = 0;
        private Rectangle preFace;
        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            
            Mat frame = new Mat();
            capture.Retrieve(frame, 0);    //接收数据  
            //Mat frame = capture.QueryFrame();
                
            Image<Gray, byte> tempImg = frame.ToImage<Gray, byte>();
            Image<Rgba, byte> rgbaImg = frame.ToImage<Rgba, byte>();
            var rgbFrameImg = frame.ToImage<Rgb, byte>();
            Graphics g = Graphics.FromImage(frame.Bitmap);
           
            //face detection   
            using (UMat ugray = new UMat())
            {
                CvInvoke.CvtColor(frame, ugray, Emgu.CV.CvEnum.ColorConversion.Bgr2Gray);//灰度化图片  
                CvInvoke.EqualizeHist(ugray, ugray);//均衡化灰度图片  

                Rectangle[] facesDetected = faceClassifier.DetectMultiScale(ugray, 1.1, 10, new System.Drawing.Size(20, 20));
                if (facesDetected.Length > 0)
                {
                    
                    var face = getMaxRectangle(facesDetected);
                    faceRect = face;
                    g.DrawRectangle(new Pen(Color.Red, 2), face);

                    Rectangle halfFace = new Rectangle(face.X, face.Y + face.Height*3 / 5, face.Width, face.Height*2 / 5);
                    Image<Gray, byte> grayFace = tempImg.Copy(halfFace);

                    //imageBox2.Image = grayFace;
                    Rectangle[] smileDetected = smileClassifier.DetectMultiScale(grayFace, 1.16, 35, new System.Drawing.Size(25, 25));
                    if (smileDetected.Length > 0)
                    {
                        var smile = getMaxRectangle(smileDetected);
                        smile.X += halfFace.X;
                        smile.Y += halfFace.Y;
                        g.DrawRectangle(new Pen(Color.Blue, 2), smile);

                        if(flag == 0)
                        {
                            int leftRightWidth = (imgWidth - face.Width) / 2;
                            int topWidth = (imgHeigth - face.Height) / 2;
                            int x, y = 0;
                            x = face.X - leftRightWidth < 0 ? 0 : face.X - leftRightWidth;
                            y = face.Y - topWidth < 0 ? 0 : face.Y - topWidth;
                            x = x + imgWidth > rgbaImg.Width ? rgbaImg.Width - imgWidth : x;
                            y = y + imgHeigth > rgbaImg.Height ? rgbaImg.Height - imgHeigth : y;

                            Rectangle imgFace = new Rectangle(x, y, imgWidth, imgHeigth);
                            imageBox2.Image = rgbaImg.Copy(imgFace);
                            rgbImg = rgbFrameImg.Copy(imgFace);
                            flag = 1;
                            lb_tip.Text = "请输入手机号码";
                        }
                    }
                }
            }
                

                imageBox1.Image = frame;       //显示图像 
           
            
        }

        private Rectangle getMaxRectangle(Rectangle[] list)
        {
            int max = 0;
            Rectangle maxRectangle = new Rectangle(0,0,0,0);
            foreach(Rectangle r in list)
            {
                if (r.Width * r.Height > max)
                {
                    max = r.Width * r.Height;
                    maxRectangle = r;
                }
            }
            return maxRectangle;
        }

       

        private void btn_save_Click(object sender, EventArgs e)
        {
            var tel = tb_tel.Text.Trim();
            User u = GetUserByTel(tel);
            lb_name.Text = u.name;
            lb_company.Text = u.company;
            lb_depart.Text = u.depart;
            
            if (SaveImg())
            {
                Thread t = new Thread(new ParameterizedThreadStart(speak));
                t.Start(u.name + "同学，欢迎光临,有有有有有有有有请下一位");
                
                lb_tip.Text = "微笑打卡，不然打不上";
                tb_tel.Focus();
                tb_tel.Text = "";
            }
            else
            {

            }
        }

        public bool SaveImg()
        {
            var tel = tb_tel.Text.Trim();
            if (selectRect != null)
            {
                rgbImg.Save(tel + ".jpg");
                return true;
            }
            return false;
        }

        public static void speak(object str)
        {
            SpVoice voice = new SpVoice();
            voice.Rate = 2; //语速,[-10,10]
            voice.Volume = 100; //音量,[0,100]
            voice.Voice = voice.GetVoices().Item(0); //语音库
            voice.Speak(str.ToString());

            flag = 0;
        }

        /// <summary>  
        /// Method to upload the specified file to the specified FTP Server  
        /// </summary>  
        /// <param name="filename">file full name to be uploaded</param>  
        private bool Upload(string filePath, string filename)
        {
            FileInfo fileInf = new FileInfo(filename);
            string uri = "ftp://" + ftpIp + "/" + filePath + "/" + fileInf.Name;
            FtpWebRequest reqFTP;

            // Create FtpWebRequest object from the Uri provided  
            reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpIp + "/" + filePath + "/" + fileInf.Name));

            // Provide the WebPermission Credintials  
            reqFTP.Credentials = new NetworkCredential(ftpUser, ftpPwd);

            // By default KeepAlive is true, where the control connection is not closed  
            // after a command is executed.  
            reqFTP.KeepAlive = false;

            // Specify the command to be executed.  
            reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

            // Specify the data transfer type.  
            reqFTP.UseBinary = true;

            // Notify the server about the size of the uploaded file  
            reqFTP.ContentLength = fileInf.Length;

            // The buffer size is set to 2kb  
            int buffLength = 2048;
            byte[] buff = new byte[buffLength];
            int contentLen;

            // Opens a file stream (System.IO.FileStream) to read the file to be uploaded  
            using (FileStream fs = fileInf.OpenRead())
            {

                try
                {
                    // Stream to which the file to be upload is written  
                    using (Stream strm = reqFTP.GetRequestStream())
                    {

                        // Read from the file stream 2kb at a time  
                        contentLen = fs.Read(buff, 0, buffLength);

                        // Till Stream content ends  
                        while (contentLen != 0)
                        {
                            // Write Content from the file stream to the FTP Upload Stream  
                            strm.Write(buff, 0, contentLen);
                            contentLen = fs.Read(buff, 0, buffLength);
                        }

                        // Close the file stream and the Request Stream  
                        strm.Close();  
                        fs.Close();
                    }
                }
                catch (Exception ex)
                {
                    //fs.Close();  
                    
                    return false;
                }
            }

            return true;

        }

        private List<User> userList;
        public void ReadConfig(string path)
        {
            userList = new List<User>();
            StreamReader sr = new StreamReader(path, Encoding.UTF8);
            String line;
            while ((line = sr.ReadLine()) != null)
            {
                var info = line.Split(' ');
                var user = new User();
                user.name = info[0];
                user.tel = info[1];
                user.company = info[2];
                user.depart = info[3];
                userList.Add(user);
            }
        }

        public User GetUserByTel(string tel)
        {
            User maxLike = userList[0];
            decimal rate = 0;
            foreach(var user in userList)
            {
                StringCompute compute = new StringCompute(tel, user.tel);
                compute.SpeedyCompute();
                if (compute.ComputeResult.Rate > rate)
                {
                    rate = compute.ComputeResult.Rate;
                    maxLike = user;
                }
            }
            return maxLike;
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            flag = 0;
            
        }
    }
}
