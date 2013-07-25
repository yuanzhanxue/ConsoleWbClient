/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/25/2013
 * 时间: 1:55 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ConsoleWbClient.Domain;
using ConsoleWbClient.Utilities;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CapturePhotoForm.
    /// </summary>
    public partial class CapturePhotoForm : Form
    {
        private static readonly string TAKED_PHOTO = "拍完了，快来看！";
        private string ImagePath { get; set; }

        private VideoWork vw = null;

        public CapturePhotoForm()
        {
            InitializeComponent();
        }

        private void CapturePhotoFormLoad(object sender, EventArgs e)
        {
            vw = new VideoWork(panelVideo.Handle, 0, 0, panelVideo.Width, panelVideo.Height);
            vw.Start();
        }

        public void CapturePhoto()
        {
            try
            {
                string fileName = String.Format(@"image{0}.bmp", DateTime.Now.ToString("yyyy-MM-HH-mmss"));
                if (!File.Exists(SystemParamSet.PhotoPath))
                {
                    Directory.CreateDirectory(SystemParamSet.PhotoPath);
                }
                ImagePath = Path.Combine(SystemParamSet.PhotoPath, fileName);
                vw.GrabImage(ImagePath);
                vw.Stop();
                SendImageWeibo();
                this.Close();
            }
            catch (Exception e)
            {
                Log.E("拍照出问题了：", e);
                throw e;
            }
        }

        #region 发图片微博
        private void SendImageWeibo()
        {

            if (!File.Exists(ImagePath))
            {
                throw new Exception("照片没生成");
            }

            string jpgImagePath = string.Empty;
            using (Image imageIn = Image.FromFile(ImagePath))
            {
                jpgImagePath = ImagePath.Replace("bmp", "jpeg");
                imageIn.Save(jpgImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            File.Delete(ImagePath);

            var sina = Login.getSina();
            StringBuilder msg = new StringBuilder();

            foreach (var name in SystemParamSet.ScreenNames)
            {
                msg.Append("@");
                msg.Append(name);
                msg.Append(" ");
            }

            msg.Append(TAKED_PHOTO);
            sina.API.Entity.Statuses.Upload(msg.ToString(), GetImageBytes(jpgImagePath));
        }

        private byte[] GetImageBytes(string jpgImagePath)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                using (Image imageIn = Image.FromFile(jpgImagePath))
                {
                    using (System.Drawing.Bitmap bmp = new Bitmap(imageIn))
                    {
                        bmp.Save(ms, imageIn.RawFormat);
                    }
                }
                return ms.ToArray();
            }
        }
        #endregion
    }

    /// <summary>
    ///  一个C#摄像头控制类
    /// </summary>
    internal class VideoWork
    {
        private const int WM_USER = 0x400;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CAP_START = WM_USER;
        private const int WM_CAP_STOP = WM_CAP_START + 68;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        private const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
        private const int WM_CAP_GRAB_FRAME = WM_CAP_START + 60;
        private const int WM_CAP_SEQUENCE = WM_CAP_START + 62;
        private const int WM_CAP_FILE_SET_CAPTURE_FILEA = WM_CAP_START + 20;
        private const int WM_CAP_SEQUENCE_NOFILE = WM_CAP_START + 63;
        private const int WM_CAP_SET_OVERLAY = WM_CAP_START + 51;
        private const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
        private const int WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6;
        private const int WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2;
        private const int WM_CAP_SET_CALLBACK_STATUSA = WM_CAP_START + 3;
        private const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
        private const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
        private IntPtr hWndC;
        private bool bWorkStart = false;
        private IntPtr mControlPtr;
        private int mWidth;
        private int mHeight;
        private int mLeft;
        private int mTop;

        /// 
        /// 初始化显示图像
        /// 
        /// 控件的句柄
        /// 开始显示的左边距
        /// 开始显示的上边距
        /// 要显示的宽度
        /// 要显示的长度
        public VideoWork(IntPtr handle, int left, int top, int width, int height)
        {
            mControlPtr = handle;
            mWidth = width;
            mHeight = height;
            mLeft = left;
            mTop = top;
        }
        [DllImport("avicap32.dll")]
        private static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);
        [DllImport("avicap32.dll")]
        private static extern int capGetVideoFormat(IntPtr hWnd, IntPtr psVideoFormat, int wSize);
        [DllImport("User32.dll")]
        private static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);
        ///
        /// 开始显示图像
        ///
        public void Start()
        {
            if (bWorkStart) return;

            bWorkStart = true;
            byte[] lpszName = new byte[100];
            hWndC = capCreateCaptureWindowA(lpszName, WS_CHILD | WS_VISIBLE, mLeft, mTop, mWidth, mHeight, mControlPtr, 0);
            if (hWndC.ToInt32() != 0)
            {
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_VIDEOSTREAM, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_ERROR, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_CALLBACK_STATUSA, 0, 0);
                SendMessage(hWndC, WM_CAP_DRIVER_CONNECT, 0, 0);
                SendMessage(hWndC, WM_CAP_SET_SCALE, 1, 0);
                SendMessage(hWndC, WM_CAP_SET_PREVIEWRATE, 66, 0);
                SendMessage(hWndC, WM_CAP_SET_OVERLAY, 1, 0);
                SendMessage(hWndC, WM_CAP_SET_PREVIEW, 1, 0);
            }
            return;
        }
        ///
        /// 停止显示
        ///
        public void Stop()
        {
            SendMessage(hWndC, WM_CAP_DRIVER_DISCONNECT, 0, 0);
            bWorkStart = false;
        }
        ///
        /// 抓图
        ///   
        /// 要保存bmp文件的路径
        public void GrabImage(string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            SendMessage(hWndC, WM_CAP_SAVEDIB, 0, hBmp.ToInt32());
        }
    }
}
