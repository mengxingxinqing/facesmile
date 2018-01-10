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
/**
 * 需要将libs中的文件拷贝到生成路径下
 **/

namespace SmileFace
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
        private string imgPath;
        private Image<Bgr, Byte> initFace;
        private int openFtp = 0;
        private Image<Bgra, Byte> hatImg;
        private List<Image<Bgra, Byte>> hatList = new List<Image<Bgra, byte>>();
        private string hatPath;
        
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
                imgPath = ConfigurationManager.AppSettings["ImgSavePath"];
                hatPath = ConfigurationManager.AppSettings["HatPath"];
                initFace = new Image<Bgr, byte>("initFace.jpg");
                getAllHat();
                openFtp = int.Parse(ConfigurationManager.AppSettings["OpenFtp"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void getAllHat()
        {
            var files = Directory.GetFiles(hatPath, "*.png");

            foreach (var file in files) { 
                hatImg = new Image<Bgra, byte>(file).Resize(250, 130, Inter.Linear);
                hatList.Add(hatImg);
            }
        }
        private void getRandHat()
        {
            int len = hatList.Count();
            Random rd = new Random();
            hatImg = hatList[rd.Next(0, len)];
        }


        private int showRate = 10;
        private int showRateIndex = 0;
        private FrameRect preFace = null;
        private FrameRect preSmile = null;
        private FrameRect preSelectArea = null;
        private Mat resFrame = null;
        private FrameRect resSelectArea = null;
        private FrameRect resSelectFace = null;
        private bool smileStart = false;
        private bool isSelect = false;
        private int peopleSpan = 10;
        private int currSpan = 10;
        private bool isPeopleSpan = false;

        private void Capture_ImageGrabbed(object sender, EventArgs e)
        {
            
            Mat frame = new Mat();
            capture.Retrieve(frame, 0);    //接收数据
            var showFrame = frame.Clone();
            FrameRect face, smile, selectArea;
            if (showRateIndex == 0 || showRateIndex % showRate == 0)
            {
                face = getFace(frame);
                selectArea = getSelectArea(frame, face);
                smile = getSmile(frame, face);
                if(face != null)
                {
                    preFace = face;
                }
                preSmile = smile;
                preSelectArea = selectArea;
            }
            else
            {
                face = preFace;
                selectArea = preSelectArea;
                smile = preSmile; 
            }
            face = face == null ? preFace : face;
            
            Graphics g = Graphics.FromImage(showFrame.Bitmap);
            
            if (face != null)
            {
                DrawHat(preFace.rect, g);
                g.DrawRectangle(new Pen(Color.Red, 3), face.rect);
                
            }
            if (smile != null)
            {
                showRateIndex++;
                OnSmileAction(frame, face, smile, selectArea);
                if (isSelect)
                {
                    resFrame = frame;
                    resSelectArea = selectArea;
                    resSelectFace = face;
                    
                    Image<Rgba, byte> rgbaImg = frame.ToImage<Rgba, byte>().Copy(selectArea.rect);
                    Graphics g_pic = Graphics.FromImage(rgbaImg.Bitmap);
                    //DrawHat(new Rectangle(face.rect.X - selectArea.rect.X, face.rect.Y - selectArea.rect.Y, face.rect.Width, face.rect.Height), g_pic);
                    imageBox_pic.Image = rgbaImg;
                }
                g.DrawRectangle(new Pen(Color.Blue, 3), smile.rect);
            }
            imageBox_cap.Image = showFrame;       //显示图像
            
        }

        private void DrawHat(Rectangle face, Graphics g)
        {
            int x = face.X + (face.Width - hatImg.Width) / 2;
            int y = face.Y - hatImg.Height * 4 / 5;
            g.DrawImage(hatImg.Bitmap, new Point(x, y));
        }

        private void OnSmileAction(Mat frame,FrameRect face,FrameRect smile,FrameRect selectArea)
        {
            if(!smileStart && isSelect)
            {
                smileStart = true;
            }
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

        private FrameRect getSmile(Mat frame,FrameRect face)
        {
            if (face == null) return null;
            Image<Gray, byte> tempImg = frame.ToImage<Gray, byte>();
            Rectangle halfFace = new Rectangle(face.rect.X + face.rect.Width/5, face.rect.Y + face.rect.Height * 3 / 5, face.rect.Width*3/5, face.rect.Height * 2 / 5);
            Image<Gray, byte> grayFace = tempImg.Copy(halfFace);
            //imageBox2.Image = grayFace;
            FrameRect smile = null;
            Rectangle[] smileDetected = smileClassifier.DetectMultiScale(grayFace, 1.16, 35, new System.Drawing.Size(25, 25));
            if (smileDetected != null && smileDetected.Length > 0)
            {
                smile = new FrameRect(getMaxRectangle(smileDetected).rect);
                smile.rect.X += halfFace.X;
                smile.rect.Y += halfFace.Y;
            }
            return smile;
        }

        private FrameRect getSelectArea(Mat frame,FrameRect face)
        {
            if (face == null) return null;
            int leftRightWidth = (imgWidth - face.rect.Width) / 2;
            int topWidth = (imgHeigth - face.rect.Height) / 2;
            int x, y = 0;
            x = face.rect.X - leftRightWidth < 0 ? 0 : face.rect.X - leftRightWidth;
            y = face.rect.Y - topWidth < 0 ? 0 : face.rect.Y - topWidth;
            x = x + imgWidth > frame.Width ? frame.Width - imgWidth : x;
            y = y + imgHeigth > frame.Height ? frame.Height - imgHeigth : y;
            FrameRect rect = new FrameRect(new Rectangle(x, y, imgWidth, imgHeigth));
            return rect;
        }

        private FrameRect getMaxRectangle(Rectangle[] list)
        {
            if (list == null) return null;
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
            return new FrameRect(maxRectangle);
        }

       

        private void btn_save_Click(object sender, EventArgs e)
        {
            var tel = tb_tel.Text.Trim();
            if(tel.Length !=11 && tel.Length != 1)
            {
                speak("小伙子，手机号输错了");
                return;
            }
            User u = GetUserByTel(tel);
            getRandHat();
            if (u == null)
            {
                speak("小伙子，手机号输错了,检查一下吧");
                return;
            }
            lb_name.Text = u.name;
            lb_company.Text = u.company;
            lb_depart.Text = u.depart;
            string fileName = u.company + "_" + u.depart + "_" + u.name + ".jpg";
            if(resFrame != null && resSelectArea != null && SaveSelectAreaImg(tel, resFrame, resSelectArea, fileName))
            {
                string word = u.name + "同学,欢迎光临，乌拉拉拉拉";
                if (u.tel == "1") word = "董事长您好，欢迎光临";
                if (u.tel == "2") word = "董事长夫人您好，欢迎光临";
                speak(word);
                tb_tel.Text = "";
                isPeopleSpan = true;
            }
        }

        public bool SaveSelectAreaImg(string tel,Mat frame,FrameRect selectArea,string name)
        {
            var rgbFrameImg = frame.ToImage<Rgba, byte>();
            string strencode = "";
            byte[] utf8 = Encoding.UTF8.GetBytes(name);
            name = Encoding.UTF8.GetString(utf8);
            if (selectArea != null)
            {
                var selectImg = rgbFrameImg.Copy(selectArea.rect).Bitmap;
                string path = imgPath + "/" + name;
                //selectImg.Save(path);
                selectImg.Save(path, System.Drawing.Imaging.ImageFormat.Jpeg);
                if (openFtp != 0)
                {
                    UploadFtp("UserFace", path);
                }

                return true;
            }
            return false;
        }

        public static void speak(string str)
        {
            Thread t = new Thread(new ParameterizedThreadStart(speakThread));
            t.Start(str);
        }

        public static void speakThread(object str)
        {
            SpVoice voice = new SpVoice();
            voice.Rate = 1; //语速,[-10,10]
            voice.Volume = 100; //音量,[0,100]
            voice.Voice = voice.GetVoices().Item(0); //语音库
            voice.Speak(str.ToString());
        }

        /// <summary>  
        /// Method to upload the specified file to the specified FTP Server  
        /// </summary>  
        /// <param name="filename">file full name to be uploaded</param>  
        private bool UploadFtp(string filePath, string filename)
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
                line = line.Trim();
                var info = line.Split(' ');
                var user = new User();
                user.name = info[3];
                user.tel = info[0];
                user.company = info[1];
                user.depart = info[2];
                userList.Add(user);
            }
        }

        public User GetUserByTel(string tel)
        {
            //User maxLike = null;
            //decimal rate = 0;
            foreach(var user in userList)
            {
                //StringCompute compute = new StringCompute(tel, user.tel);
                //compute.SpeedyCompute();
                //if (compute.ComputeResult.Rate > rate)
                //{
                //    rate = compute.ComputeResult.Rate;
                //    maxLike = user;
                //}
                if(user.tel == tel.Trim())
                {
                    return user;
                }
            }
            return null;
        }

        private void btn_restart_Click(object sender, EventArgs e)
        {
            isSelect = true;
            lb_name.Text = "";
            lb_depart.Text = "";
            lb_company.Text = "";
            imageBox_pic.Image = initFace;

        }


        /// <summary>  
        /// 获取时间戳  
        /// </summary>  
        /// <returns></returns>  
        private long GetTimeStamp()
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            return Convert.ToInt64(ts.TotalSeconds);
        }

        public void onSmileTick()
        {
            if(smileStart)
            {
                var num = int.Parse(lb_num.Text);
                lb_num.Text = (num - 1).ToString();
                lb_num.Show();
                if (num == 3)
                {
                    speak("3 2 1 裤衩咔嚓裤衩，请输入手机号码，回车结束");
                    pb_mengban.Show();
                }
                if(num == 2)
                {
                    pb_mengban.Hide();
                }
                if(num == 1)
                {
                    pb_mengban.Show();
                }
                if (num == 0)
                {
                    lb_num.Text = "3";
                    lb_num.Hide();
                    smileStart = false;
                    isSelect = false;
                    pb_mengban.Hide();
                }
            }
                
        }

        public void onPeopleSpan()
        {
            if (isPeopleSpan)
            {
                if(currSpan > 0)
                {
                    currSpan--;
                }
                if(currSpan == 0)
                {
                    currSpan = peopleSpan;
                    //isSelect = true;
                    isPeopleSpan = false;
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            onSmileTick();
            onPeopleSpan();
        }

        private void tb_tel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                btn_save_Click(null, null);
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            imageBox_pic.Image = initFace;
            pb_mengban.Location = new Point(15, 15);
            pb_mengban.Parent = imageBox_cap;
            //pb_mengban.Show();
        }
    }
}
