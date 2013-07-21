using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ConsoleWbClient.Domain;
using ConsoleWbClient.Utilities;

namespace ConsoleWbClient.UI
{
    public partial class WeiboCtrlClient : Form
    {
        private delegate void DelegateWriteResult(string text, int s);

        private DateTime mStratTime { get; set; }

        public WeiboCtrlClient()
        {
            InitializeComponent();
        }

        public void RunStart()
        {
            LoadLogToListBox();
            Log.LogHandler += new LogWriteEventHandler(OnLogWriting);
            mStratTime = System.DateTime.Now;
            this.tbProcStart.Text = mStratTime.ToString("yyyy-MM-dd HH:mm:ss");
            Log.I("Weibo后台服务启动！");
            LoopTask.Instance.Start();
        }

        #region 窗体事件响应

        private void stripBtnPallet_Click(object sender, EventArgs e)
        {
            this.Hide();
            this.notifyIcon.Visible = true;
            notifyIcon.ShowBalloonTip(1);
        }

        private void notifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            this.notifyIcon.Visible = false;
        }

        private void stripBtnSetting_Click(object sender, EventArgs e)
        {
            //ConfigForm.ShowConfig();
        }

        private void stripBtnQuit_Click(object sender, EventArgs e)
        {
            ConfirmExit();
        }

        private void stripBtnAbout_Click(object sender, EventArgs e)
        {
        }

        private void toolStripMenuItemHide_Click(object sender, EventArgs e)
        {
            notifyIcon_MouseDoubleClick(null, null);
        }

        private void toolStripMenuItemSetting_Click(object sender, EventArgs e)
        {
            stripBtnSetting_Click(null, null);
        }

        private void toolStripMenuItemQuit_Click(object sender, EventArgs e)
        {
            stripBtnQuit_Click(null, null);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            TimeSpan tSpan = DateTime.Now - mStratTime;
            string te = tSpan.ToString();
            int i = te.LastIndexOf('.');
            te = te.Remove(i, te.Length - i);
            this.tbProcPerform.Text = te;
        }

        private void AutoControlForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!ConfirmExit())
            {
                e.Cancel = true;
            }
        }

        private void AutoControlForm_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                stripBtnPallet_Click(null, null);
            }
        }

        #endregion

        #region 私有方法

        private bool ConfirmExit()
        {
            if (MessageBox.Show("你确定要退出监控吗?", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LoopTask.Instance.Stop();
                Log.I("关闭监控程序! 总共运行时间：" + this.tbProcPerform.Text);
                this.notifyIcon.Visible = false;
                Environment.Exit(-1);
            }

            return false;
        }

        private void LoadLogToListBox()
        {
            this.listBoxLog.Items.Clear();
            string[] allLogs = Log.ReadAllLogs();

            if (allLogs != null)
            {
                for (int i = allLogs.Length - 1; i >= 0; i--)
                {
                    // listbox 中不需要太详细信息，解析一下再显示
                    string line = allLogs[i];
                    LogItem logItem = new LogItem(line);
                    if (logItem.IsMessage)
                    {
                        StringBuilder sb = new StringBuilder(logItem.LogTime.ToString(Log.TimeFormat));
                        sb.Append(" ");
                        sb.Append(logItem.Level);
                        sb.Append("  ");
                        sb.Append(logItem.MessageInfo);
                        this.listBoxLog.Items.Add(sb.ToString());
                    }
                    else
                    {
                        this.listBoxLog.Items.Add(line);
                    }
                }
            }
        }
        #endregion

        private delegate void ListBoxLogHandler(string log);
        public void OnLogWriting(string txt)
        {
            if (listBoxLog.InvokeRequired)
            {
                this.Invoke(new ListBoxLogHandler(OnLogWriting), new object[] { txt });
            }
            else
            {
                listBoxLog.Items.Insert(0, txt);
            }
        }
    }
}
