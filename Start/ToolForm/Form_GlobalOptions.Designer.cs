
namespace HYProject.ToolForm
{
    partial class Form_GlobalOptions
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_GlobalOptions));
            this.globalVariable = new ToolKit.HYControls.GlobalVariable();
            this.SuspendLayout();
            // 
            // globalVariable
            // 
            this.globalVariable.Dock = System.Windows.Forms.DockStyle.Fill;
            this.globalVariable.Location = new System.Drawing.Point(0, 0);
            this.globalVariable.Name = "globalVariable";
            this.globalVariable.Size = new System.Drawing.Size(800, 450);
            this.globalVariable.TabIndex = 0;
            // 
            // Form_GlobalOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.globalVariable);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_GlobalOptions";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "全局参数";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_GlobalOptions_FormClosing);
            this.ResumeLayout(false);

        }

        #endregion

        public ToolKit.HYControls.GlobalVariable globalVariable;
    }
}