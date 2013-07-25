namespace ConsoleWbClient.UI
{
    partial class WeiboCtrlClient
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WeiboCtrlClient));
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSetting = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItemQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.labelProcPerform = new System.Windows.Forms.Label();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.tbProcPerform = new System.Windows.Forms.TextBox();
            this.labelProcStart = new System.Windows.Forms.Label();
            this.tbProcStart = new System.Windows.Forms.TextBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.listBoxLog = new System.Windows.Forms.ListBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.stripBtnQuit = new System.Windows.Forms.ToolStripButton();
            this.stripBtnSetting = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.stripBtnPallet = new System.Windows.Forms.ToolStripButton();
            this.stripBtnAbout = new System.Windows.Forms.ToolStripButton();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.gbLog.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolStripMenuItemHide,
                                    this.toolStripMenuItemSetting,
                                    this.toolStripMenuItem1,
                                    this.toolStripMenuItemQuit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(109, 82);
            // 
            // toolStripMenuItemHide
            // 
            this.toolStripMenuItemHide.Name = "toolStripMenuItemHide";
            this.toolStripMenuItemHide.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemHide.Text = "显示";
            this.toolStripMenuItemHide.Click += new System.EventHandler(this.toolStripMenuItemHide_Click);
            // 
            // toolStripMenuItemSetting
            // 
            this.toolStripMenuItemSetting.Name = "toolStripMenuItemSetting";
            this.toolStripMenuItemSetting.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemSetting.Text = "配置";
            this.toolStripMenuItemSetting.Click += new System.EventHandler(this.toolStripMenuItemSetting_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(105, 6);
            // 
            // toolStripMenuItemQuit
            // 
            this.toolStripMenuItemQuit.Name = "toolStripMenuItemQuit";
            this.toolStripMenuItemQuit.Size = new System.Drawing.Size(108, 24);
            this.toolStripMenuItemQuit.Text = "退出";
            this.toolStripMenuItemQuit.Click += new System.EventHandler(this.toolStripMenuItemQuit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.notifyIcon.BalloonTipText = "单击此处显示界面!";
            this.notifyIcon.BalloonTipTitle = "提示";
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon.Text = "新浪微博后台服务";
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // timer
            // 
            this.timer.Enabled = true;
            this.timer.Interval = 1000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // labelProcPerform
            // 
            this.labelProcPerform.AutoSize = true;
            this.labelProcPerform.Location = new System.Drawing.Point(279, 13);
            this.labelProcPerform.Name = "labelProcPerform";
            this.labelProcPerform.Size = new System.Drawing.Size(82, 13);
            this.labelProcPerform.TabIndex = 2;
            this.labelProcPerform.Text = "程序运行时间:";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer2.IsSplitterFixed = true;
            this.splitContainer2.Location = new System.Drawing.Point(0, 25);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.tbProcPerform);
            this.splitContainer2.Panel1.Controls.Add(this.labelProcPerform);
            this.splitContainer2.Panel1.Controls.Add(this.labelProcStart);
            this.splitContainer2.Panel1.Controls.Add(this.tbProcStart);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.gbLog);
            this.splitContainer2.Size = new System.Drawing.Size(635, 367);
            this.splitContainer2.SplitterDistance = 37;
            this.splitContainer2.TabIndex = 4;
            this.splitContainer2.TabStop = false;
            // 
            // tbProcPerform
            // 
            this.tbProcPerform.Location = new System.Drawing.Point(364, 9);
            this.tbProcPerform.Name = "tbProcPerform";
            this.tbProcPerform.ReadOnly = true;
            this.tbProcPerform.Size = new System.Drawing.Size(153, 20);
            this.tbProcPerform.TabIndex = 3;
            this.tbProcPerform.TabStop = false;
            // 
            // labelProcStart
            // 
            this.labelProcStart.AutoSize = true;
            this.labelProcStart.Location = new System.Drawing.Point(5, 13);
            this.labelProcStart.Name = "labelProcStart";
            this.labelProcStart.Size = new System.Drawing.Size(82, 13);
            this.labelProcStart.TabIndex = 0;
            this.labelProcStart.Text = "程序启动时间:";
            // 
            // tbProcStart
            // 
            this.tbProcStart.Location = new System.Drawing.Point(90, 9);
            this.tbProcStart.Name = "tbProcStart";
            this.tbProcStart.ReadOnly = true;
            this.tbProcStart.Size = new System.Drawing.Size(153, 20);
            this.tbProcStart.TabIndex = 1;
            this.tbProcStart.TabStop = false;
            this.tbProcStart.WordWrap = false;
            // 
            // gbLog
            // 
            this.gbLog.Controls.Add(this.listBoxLog);
            this.gbLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gbLog.Location = new System.Drawing.Point(0, 0);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(635, 326);
            this.gbLog.TabIndex = 0;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "日志";
            // 
            // listBoxLog
            // 
            this.listBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxLog.FormattingEnabled = true;
            this.listBoxLog.Location = new System.Drawing.Point(3, 16);
            this.listBoxLog.Name = "listBoxLog";
            this.listBoxLog.Size = new System.Drawing.Size(629, 307);
            this.listBoxLog.TabIndex = 0;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 392);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(635, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(243, 17);
            this.toolStripStatusLabel.Text = "运行状态:网络正常/数据库连接正常";
            // 
            // stripBtnQuit
            // 
            this.stripBtnQuit.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnQuit.Image")));
            this.stripBtnQuit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnQuit.Name = "stripBtnQuit";
            this.stripBtnQuit.Size = new System.Drawing.Size(58, 22);
            this.stripBtnQuit.Text = "退出";
            this.stripBtnQuit.Click += new System.EventHandler(this.stripBtnQuit_Click);
            // 
            // stripBtnSetting
            // 
            this.stripBtnSetting.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnSetting.Image")));
            this.stripBtnSetting.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnSetting.Name = "stripBtnSetting";
            this.stripBtnSetting.Size = new System.Drawing.Size(58, 22);
            this.stripBtnSetting.Text = "设置";
            this.stripBtnSetting.Click += new System.EventHandler(this.stripBtnSetting_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                                    this.stripBtnPallet,
                                    this.toolStripSeparator1,
                                    this.stripBtnSetting,
                                    this.toolStripSeparator2,
                                    this.stripBtnQuit,
                                    this.toolStripSeparator3,
                                    this.stripBtnAbout});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(635, 25);
            this.toolStrip1.TabIndex = 3;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // stripBtnPallet
            // 
            this.stripBtnPallet.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnPallet.Image")));
            this.stripBtnPallet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.stripBtnPallet.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnPallet.Name = "stripBtnPallet";
            this.stripBtnPallet.Size = new System.Drawing.Size(88, 22);
            this.stripBtnPallet.Text = "托盘显示";
            this.stripBtnPallet.Click += new System.EventHandler(this.stripBtnPallet_Click);
            // 
            // stripBtnAbout
            // 
            this.stripBtnAbout.Image = ((System.Drawing.Image)(resources.GetObject("stripBtnAbout.Image")));
            this.stripBtnAbout.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.stripBtnAbout.Name = "stripBtnAbout";
            this.stripBtnAbout.Size = new System.Drawing.Size(58, 22);
            this.stripBtnAbout.Text = "关于";
            this.stripBtnAbout.Click += new System.EventHandler(this.stripBtnAbout_Click);
            // 
            // WeiboCtrlClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 414);
            this.Controls.Add(this.splitContainer2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "WeiboCtrlClient";
            this.Text = "新浪微博后台服务";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.AutoControlForm_FormClosing);
            this.SizeChanged += new System.EventHandler(this.AutoControlForm_SizeChanged);
            this.contextMenuStrip1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel1.PerformLayout();
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.gbLog.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        #endregion

        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHide;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSetting;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemQuit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Label labelProcPerform;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.TextBox tbProcPerform;
        private System.Windows.Forms.Label labelProcStart;
        private System.Windows.Forms.TextBox tbProcStart;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.ListBox listBoxLog;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton stripBtnQuit;
        private System.Windows.Forms.ToolStripButton stripBtnSetting;
        private System.Windows.Forms.ToolStripButton stripBtnPallet;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton stripBtnAbout;

    }
}
