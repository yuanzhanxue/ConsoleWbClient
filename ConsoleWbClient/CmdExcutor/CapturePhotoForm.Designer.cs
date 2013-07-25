/*
 * 由SharpDevelop创建。
 * 用户： 28850619
 * 日期: 7/25/2013
 * 时间: 1:55 PM
 * 
 * 要改变这种模板请点击 工具|选项|代码编写|编辑标准头文件
 */
namespace ConsoleWbClient.CmdExcutor
{
    partial class CapturePhotoForm
    {
        /// <summary>
        /// Designer variable used to keep track of non-visual components.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Disposes resources used by the form.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing) {
                if (components != null) {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }
        
        /// <summary>
        /// This method is required for Windows Forms designer support.
        /// Do not change the method contents inside the source code editor. The Forms designer might
        /// not be able to load this method if it was changed manually.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelVideo = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panelVideo
            // 
            this.panelVideo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelVideo.Location = new System.Drawing.Point(0, 0);
            this.panelVideo.Name = "panelVideo";
            this.panelVideo.Size = new System.Drawing.Size(292, 262);
            this.panelVideo.TabIndex = 0;
            // 
            // CapturePhotoForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 262);
            this.Controls.Add(this.panelVideo);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CapturePhotoForm";
            this.ShowInTaskbar = false;
            this.Text = "抓图";
            this.Load += new System.EventHandler(this.CapturePhotoFormLoad);
            this.ResumeLayout(false);
        }
        private System.Windows.Forms.Panel panelVideo;
    }
}
