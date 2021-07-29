
namespace HYProject.ToolForm
{
    partial class Form_Communication_Test
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Communication_Test));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tcpSocketControl1 = new ToolKit.HYControls.TCPSocketControl();
            this.tcpSocketControl2 = new ToolKit.HYControls.TCPSocketControl();
            this.tcpSocketControl3 = new ToolKit.HYControls.TCPSocketControl();
            this.tcpSocketControl4 = new ToolKit.HYControls.TCPSocketControl();
            this.serialPortControl1 = new ToolKit.HYControls.SerialPortControl();
            this.serialPortControl2 = new ToolKit.HYControls.SerialPortControl();
            this.serialPortControl3 = new ToolKit.HYControls.SerialPortControl();
            this.serialPortControl4 = new ToolKit.HYControls.SerialPortControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(863, 455);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.serialPortControl3);
            this.tabPage1.Controls.Add(this.serialPortControl4);
            this.tabPage1.Controls.Add(this.serialPortControl2);
            this.tabPage1.Controls.Add(this.serialPortControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(855, 429);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "串口";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tcpSocketControl3);
            this.tabPage2.Controls.Add(this.tcpSocketControl4);
            this.tabPage2.Controls.Add(this.tcpSocketControl2);
            this.tabPage2.Controls.Add(this.tcpSocketControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(855, 429);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "TCP";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tcpSocketControl1
            // 
            this.tcpSocketControl1.Location = new System.Drawing.Point(6, 6);
            this.tcpSocketControl1.MinimumSize = new System.Drawing.Size(417, 206);
            this.tcpSocketControl1.Name = "tcpSocketControl1";
            this.tcpSocketControl1.Size = new System.Drawing.Size(417, 206);
            this.tcpSocketControl1.TabIndex = 0;
            // 
            // tcpSocketControl2
            // 
            this.tcpSocketControl2.Location = new System.Drawing.Point(429, 6);
            this.tcpSocketControl2.MinimumSize = new System.Drawing.Size(417, 206);
            this.tcpSocketControl2.Name = "tcpSocketControl2";
            this.tcpSocketControl2.Size = new System.Drawing.Size(417, 206);
            this.tcpSocketControl2.TabIndex = 1;
            // 
            // tcpSocketControl3
            // 
            this.tcpSocketControl3.Location = new System.Drawing.Point(429, 218);
            this.tcpSocketControl3.MinimumSize = new System.Drawing.Size(417, 206);
            this.tcpSocketControl3.Name = "tcpSocketControl3";
            this.tcpSocketControl3.Size = new System.Drawing.Size(417, 206);
            this.tcpSocketControl3.TabIndex = 3;
            // 
            // tcpSocketControl4
            // 
            this.tcpSocketControl4.Location = new System.Drawing.Point(6, 218);
            this.tcpSocketControl4.MinimumSize = new System.Drawing.Size(417, 206);
            this.tcpSocketControl4.Name = "tcpSocketControl4";
            this.tcpSocketControl4.Size = new System.Drawing.Size(417, 206);
            this.tcpSocketControl4.TabIndex = 2;
            // 
            // serialPortControl1
            // 
            this.serialPortControl1.Location = new System.Drawing.Point(46, 6);
            this.serialPortControl1.MinimumSize = new System.Drawing.Size(359, 170);
            this.serialPortControl1.Name = "serialPortControl1";
            this.serialPortControl1.Size = new System.Drawing.Size(359, 170);
            this.serialPortControl1.TabIndex = 0;
            // 
            // serialPortControl2
            // 
            this.serialPortControl2.Location = new System.Drawing.Point(451, 6);
            this.serialPortControl2.MinimumSize = new System.Drawing.Size(359, 170);
            this.serialPortControl2.Name = "serialPortControl2";
            this.serialPortControl2.Size = new System.Drawing.Size(359, 170);
            this.serialPortControl2.TabIndex = 1;
            // 
            // serialPortControl3
            // 
            this.serialPortControl3.Location = new System.Drawing.Point(451, 219);
            this.serialPortControl3.MinimumSize = new System.Drawing.Size(359, 170);
            this.serialPortControl3.Name = "serialPortControl3";
            this.serialPortControl3.Size = new System.Drawing.Size(359, 170);
            this.serialPortControl3.TabIndex = 3;
            // 
            // serialPortControl4
            // 
            this.serialPortControl4.Location = new System.Drawing.Point(46, 219);
            this.serialPortControl4.MinimumSize = new System.Drawing.Size(359, 170);
            this.serialPortControl4.Name = "serialPortControl4";
            this.serialPortControl4.Size = new System.Drawing.Size(359, 170);
            this.serialPortControl4.TabIndex = 2;
            // 
            // Form_Communication_Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 455);
            this.Controls.Add(this.tabControl1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(879, 494);
            this.MinimumSize = new System.Drawing.Size(879, 494);
            this.Name = "Form_Communication_Test";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "通讯测试";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private ToolKit.HYControls.TCPSocketControl tcpSocketControl3;
        private ToolKit.HYControls.TCPSocketControl tcpSocketControl4;
        private ToolKit.HYControls.TCPSocketControl tcpSocketControl2;
        private ToolKit.HYControls.TCPSocketControl tcpSocketControl1;
        private ToolKit.HYControls.SerialPortControl serialPortControl3;
        private ToolKit.HYControls.SerialPortControl serialPortControl4;
        private ToolKit.HYControls.SerialPortControl serialPortControl2;
        private ToolKit.HYControls.SerialPortControl serialPortControl1;
    }
}