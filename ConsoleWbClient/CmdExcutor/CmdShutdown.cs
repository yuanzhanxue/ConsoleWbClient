/*
 * 由Yuan,Zhanxue创建。
 * 用户： 28850619
 * 日期: 7/19/2013
 * 时间: 2:00 PM
 * 
 */
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleWbClient.CmdExcutor
{
    /// <summary>
    /// Description of CmdShutdown.
    /// </summary>
    public class CmdShutdown : AbstractMachineCmd
    {
        public static readonly string POWER_OFF = "正在强行关机，请稍候！";

        protected override string ThreadTag { get { return "CmdShutdown"; } }

        public CmdShutdown(string content, bool isContinue, ManualResetEvent exitSignal) : base(content, isContinue, exitSignal) { }

        public override void ExecuteMethod()
        {
        	iMessage.SendComments(WbId, POWER_OFF, false);
            Cmd("shutdown -s");
        }

        /// <summary>
        /// 执行命令行
        /// </summary>
        /// <param name="cmd"></param>
        /// <returns></returns>
        private string Cmd(string command)
        {
            string output = ""; //输出字符串  
            if (command != null && !command.Equals(""))
            {
                Process process = new Process();
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "cmd.exe";
                startInfo.Arguments = "/C " + command;   //“/C”表示执行完命令后马上退出  
                startInfo.UseShellExecute = false;       //不使用系统外壳程序启动  
                startInfo.RedirectStandardInput = false; //不重定向输入  
                startInfo.RedirectStandardOutput = true; //重定向输出  
                startInfo.CreateNoWindow = true;         //不创建窗口  
                process.StartInfo = startInfo;
                try
                {
                    if (process.Start())
                    {
                        //这里无限等待进程结束 
                        process.WaitForExit();
                        //读取进程的输出 
                        output = process.StandardOutput.ReadToEnd();
                    }
                }
                catch
                {
                }
                finally
                {
                    if (process != null) process.Close();
                }
            }

            return output;
        }
    }
}
