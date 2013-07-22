/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:09 PM
 * 
 */
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdDownloadFile.
    /// </summary>
    public class CmdDownloadFile : AbstractMachineCmd
    {
        public static readonly string DOWNLOAD_BEGIN = "开始下载，请稍候！";
        public static readonly string DOWNLOADED_FILE = "文件下载已完成！";

        protected override string ThreadTag { get { return "CmdDownloadFile"; } }

        public CmdDownloadFile(string content, bool isContinue, ManualResetEvent exitSignal) : base(content, isContinue, exitSignal) { }

        public override void ExecuteMethod()
        {
        	iMessage.SendComments(WbId, DOWNLOAD_BEGIN, false);
        	
            DoDownload();

            iMessage.SendComments(WbId, DOWNLOADED_FILE, true);
        }

        private void DoDownload()
        {
        }
    }
}
