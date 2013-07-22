/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 4:24 PM
 * 
 */
using System;
using System.Threading;
using System.Threading.Tasks;

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

        public CmdTakePhoto(string content, bool isContinue, ManualResetEvent exitSignal)
            : base(content, isContinue, exitSignal)
        {
        }

        public override void ExecuteMethod()
        {
            iMessage.SendComments(WbId, TAKING_PHOTO, false);
            iMessage.SendComments(WbId, TAKED_PHOTO, true);
        }
    }
}
