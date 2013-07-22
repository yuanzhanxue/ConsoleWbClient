using System;
using System.Threading;
using System.Windows.Forms;
using ConsoleWbClient.UI;

namespace ConsoleWbClient
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            AppDomain.CurrentDomain.UnhandledException += HandleUnhandledException;
            bool bNotRunning;
            Mutex run = new Mutex(true, "ConsoleWbClient", out bNotRunning);

            if (bNotRunning)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                WeiboCtrlClient frm = new WeiboCtrlClient();
                frm.RunStart();
                Application.Run(frm);
            }
            else
            {
                MessageBox.Show("不能启动重复实例！");
            }

            run.ReleaseMutex();
        }

        private static void HandleUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            Utilities.Log.F("新浪微博服务异常退出", e.ExceptionObject as Exception);
            Environment.Exit(-1);
        }
    }
}
