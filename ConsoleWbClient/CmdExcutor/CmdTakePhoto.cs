/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 4:24 PM
 * 
 */
using System;
using System.Threading;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdTakePhoto.
    /// </summary>
    public class CmdTakePhoto : AbstractMachineCmd
    {
        private static readonly string TAKING_PHOTO = "正在拍照，瞧好吧，您呐！";
        public static readonly string TAKING_PHOTO_FAILED = "拍照出问题了:(";

        protected override string ThreadTag { get { return "CmdTakePhoto"; } }

        public CmdTakePhoto(string content, bool isContinue, ManualResetEvent exitSignal)
            : base(content, isContinue, exitSignal)
        {
        }

        public override void ExecuteMethod()
        {
            iMessage.SendComments(WbId, TAKING_PHOTO, false);
            CapturePhotoForm form = new CapturePhotoForm();
            form.Show();

            try
            {
                form.CapturePhoto();
            }
            catch (Exception)
            {
                iMessage.SendComments(WbId, TAKING_PHOTO_FAILED, true);
            }
        }
    }
}
