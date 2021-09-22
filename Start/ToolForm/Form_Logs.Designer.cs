
namespace HYProject.ToolForm
{
    partial class Form_Logs
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Logs));
            this.hyLogs1 = new ToolKit.HYControls.HYLogs();
            this.SuspendLayout();
            // 
            // hyLogs1
            // 
            this.hyLogs1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hyLogs1.Location = new System.Drawing.Point(0, 0);
            this.hyLogs1.Name = "hyLogs1";
            this.hyLogs1.Size = new System.Drawing.Size(617, 222);
            this.hyLogs1.TabIndex = 5;
            // 
            // Form_Logs
            // 
            this.ClientSize = new System.Drawing.Size(617, 222);
            this.Controls.Add(this.hyLogs1);
            this.HideAll = true;
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_Logs";
            this.Text = "日志";
            this.Controls.SetChildIndex(this.hyLogs1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolKit.HYControls.HYLogs hyLogs1;
    }
}
