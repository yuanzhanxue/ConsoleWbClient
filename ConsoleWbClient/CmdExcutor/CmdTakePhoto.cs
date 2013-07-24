/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 4:24 PM
 * 
 */
using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ConsoleWbClient.Domain;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdTakePhoto.
    /// </summary>
    public class CmdTakePhoto : AbstractMachineCmd
    {
        public static readonly string TAKING_PHOTO = "正在拍照，瞧好吧，您呐！";
        public static readonly string TAKED_PHOTO = "拍完了，快来看！";

        protected override string ThreadTag { get { return "CmdTakePhoto"; } }

        private string ImagePath { get; set; }

        public CmdTakePhoto(string content, bool isContinue, ManualResetEvent exitSignal)
            : base(content, isContinue, exitSignal)
        {
        }

        public override void ExecuteMethod()
        {
            iMessage.SendComments(WbId, TAKING_PHOTO, false);
            // TODO: take photo, then post weibo.
            // SendImageWeibo();
        }

        private void SendImageWeibo()
        {
            var sina = Login.getSina();
            StringBuilder msg = new StringBuilder();

            foreach (var name in SystemParamSet.ScreenNames)
            {
                msg.Append("@");
                msg.Append(name);
                msg.Append(" ");
            }

            msg.Append(TAKED_PHOTO);
            sina.API.Entity.Statuses.Upload(msg.ToString(), GetImageBytes());
        }

        private byte[] GetImageBytes()
        {
            using(MemoryStream ms = new MemoryStream())
            {
                using(Image imageIn = Image.FromFile(ImagePath))
                {
                    using(Bitmap bmp = new Bitmap(imageIn))
                    {
                        bmp.Save(ms, imageIn.RawFormat);
                    }
                }
                return ms.ToArray();
            }
        }
    }
}
