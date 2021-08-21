
namespace HYProject.ToolForm
{
    partial class DisplayForm
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
            this.autoAddDisplayWindowControl1 = new ToolKit.DisplayWindow.AutoHalconWindow();
            this.SuspendLayout();
            // 
            // autoAddDisplayWindowControl1
            // 
            this.autoAddDisplayWindowControl1.CameraNames = new string[0];
            this.autoAddDisplayWindowControl1.Count = 0;
            this.autoAddDisplayWindowControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.autoAddDisplayWindowControl1.Location = new System.Drawing.Point(0, 0);
            this.autoAddDisplayWindowControl1.Margin = new System.Windows.Forms.Padding(0);
            this.autoAddDisplayWindowControl1.Name = "autoAddDisplayWindowControl1";
            this.autoAddDisplayWindowControl1.Size = new System.Drawing.Size(800, 450);
            this.autoAddDisplayWindowControl1.TabIndex = 0;
            // 
            // DisplayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.autoAddDisplayWindowControl1);
            this.Name = "DisplayForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DisplayForm";
            this.ResumeLayout(false);

        }

        #endregion

        private ToolKit.DisplayWindow.AutoHalconWindow autoAddDisplayWindowControl1;
    }
}