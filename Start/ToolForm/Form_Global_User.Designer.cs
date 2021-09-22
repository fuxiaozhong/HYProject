
namespace HYProject.ToolForm
{
    partial class Form_Global_User
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Global_User));
            this.Global_Parameter_User = new ToolKit.HYControls.HYGlobalVariable();
            this.SuspendLayout();
            // 
            // Global_Parameter_User
            // 
            this.Global_Parameter_User.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Global_Parameter_User.Location = new System.Drawing.Point(0, 26);
            this.Global_Parameter_User.Name = "Global_Parameter_User";
            this.Global_Parameter_User.Size = new System.Drawing.Size(700, 374);
            this.Global_Parameter_User.TabIndex = 0;
            // 
            // Form_Global_User
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 400);
            this.Controls.Add(this.Global_Parameter_User);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_Global_User";
            this.Text = "全局参数 - 用户变量";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_GlobalOptions_FormClosing);
            this.Controls.SetChildIndex(this.Global_Parameter_User, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolKit.HYControls.HYGlobalVariable Global_Parameter_User;
    }
}