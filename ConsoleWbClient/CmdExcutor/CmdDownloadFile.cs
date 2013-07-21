/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:09 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
using System;
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
        public CmdDownloadFile(string content) : base(content) { }

        public override string PreExcute()
        {
            return DOWNLOAD_BEGIN;
        }

        public override async Task<string> ExecuteCmd()
        {
            return await Task.Run(() => DoDownload());
        }

        private string DoDownload()
        {
            return DOWNLOADED_FILE;
        }
    }
}
