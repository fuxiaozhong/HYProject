
namespace HYProject.ToolForm
{
    partial class Form_Global_System
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Global_System));
            this.Global_Parameter_System = new ToolKit.HYControls.HYGlobalVariable();
            this.SuspendLayout();
            // 
            // Global_Parameter_System
            // 
            this.Global_Parameter_System.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Global_Parameter_System.Location = new System.Drawing.Point(0, 26);
            this.Global_Parameter_System.Name = "Global_Parameter_System";
            this.Global_Parameter_System.Size = new System.Drawing.Size(772, 327);
            this.Global_Parameter_System.TabIndex = 5;
            // 
            // Form_Global_System
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 353);
            this.Controls.Add(this.Global_Parameter_System);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = global::HYProject.Properties.Resources.logo;
            this.Name = "Form_Global_System";
            this.Text = "全局参数 - 系统变量";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Global_System_FormClosing);
            this.Load += new System.EventHandler(this.Form_Global_System_Load);
            this.Controls.SetChildIndex(this.Global_Parameter_System, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private ToolKit.HYControls.HYGlobalVariable Global_Parameter_System;
    }
}