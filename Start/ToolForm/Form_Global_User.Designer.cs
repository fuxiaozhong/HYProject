
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
            this.globalVariable = new ToolKit.HYControls.HYGlobalVariable();
            this.SuspendLayout();
            // 
            // globalVariable
            // 
            this.globalVariable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.globalVariable.Location = new System.Drawing.Point(0, 27);
            this.globalVariable.Name = "globalVariable";
            this.globalVariable.Size = new System.Drawing.Size(800, 423);
            this.globalVariable.TabIndex = 0;
            // 
            // Form_GlobalOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.globalVariable);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideOrClose = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_GlobalOptions";
            this.Text = "全局参数";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_GlobalOptions_FormClosing);
            this.Controls.SetChildIndex(this.globalVariable, 0);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolKit.HYControls.HYGlobalVariable globalVariable;
    }
}