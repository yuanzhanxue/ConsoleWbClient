/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:19 PM
 * 
 */
using System;
using System.Threading;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdFactory.
    /// </summary>
    public class CmdFactory
    {
        private string StrCmd { get; set; }
        public CmdFactory(string content)
        {
            StrCmd = ParseContent(content.Trim());
        }

        private string ParseContent(string con)
        {
            if (con.StartsWith("@") && con.Contains(" "))
            {
                return ParseContent(con.Substring(con.IndexOf(" ") + 1));
            }
            else
            {
                return con;
            }
        }

        public AbstractMachineCmd GetCommander(bool isContinue, ManualResetEvent eventSignal)
        {
            if (StrCmd.StartsWith("关机"))
            {
                return new CmdShutdown(StrCmd, isContinue, eventSignal);
            }
            else if (StrCmd.StartsWith("下载"))
            {
                return new CmdDownloadFile(StrCmd, isContinue, eventSignal);
            }
            else if (StrCmd.StartsWith("拍张照") || StrCmd.StartsWith("拍照"))
            {
                return new CmdTakePhoto(StrCmd, isContinue, eventSignal);
            }
            else
            {
                return new CmdUnavailable(StrCmd, isContinue, eventSignal);
            }
        }
    }
}
