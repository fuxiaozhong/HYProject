
namespace ToolKit.HYControls.HYForm
{
    partial class Form_Waiting
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.processEllipse1 = new ToolKit.HYControls.ProcessEllipse();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("宋体", 30F);
            this.label1.Location = new System.Drawing.Point(367, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 45);
            this.label1.TabIndex = 0;
            this.label1.Text = "×";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("宋体", 13F);
            this.label2.Location = new System.Drawing.Point(139, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(262, 66);
            this.label2.TabIndex = 2;
            this.label2.Text = "加载中...";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("微软雅黑", 15F);
            this.label3.ForeColor = System.Drawing.Color.DarkGray;
            this.label3.Location = new System.Drawing.Point(142, 2);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 36);
            this.label3.TabIndex = 3;
            this.label3.Text = "Loading......";
            // 
            // processEllipse1
            // 
            this.processEllipse1.BackEllipseColor = System.Drawing.Color.Transparent;
            this.processEllipse1.CoreEllipseColor = System.Drawing.Color.Transparent;
            this.processEllipse1.IsShowCoreEllipseBorder = false;
            this.processEllipse1.Location = new System.Drawing.Point(6, 5);
            this.processEllipse1.Margin = new System.Windows.Forms.Padding(5);
            this.processEllipse1.MaxValue = 100;
            this.processEllipse1.Name = "processEllipse1";
            this.processEllipse1.Padding = new System.Windows.Forms.Padding(5);
            this.processEllipse1.ShowType = ToolKit.HYControls.ShowType.Ring;
            this.processEllipse1.Size = new System.Drawing.Size(116, 107);
            this.processEllipse1.TabIndex = 4;
            this.processEllipse1.Value = 50;
            this.processEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.processEllipse1.ValueMargin = 0;
            this.processEllipse1.ValueType = ToolKit.HYControls.ValueType.Absolute;
            this.processEllipse1.ValueWidth = 20;
            // 
            // Form_Waiting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 120);
            this.Controls.Add(this.processEllipse1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form_Waiting";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Waiting";
            this.Shown += new System.EventHandler(this.FrmWaitingBox_Shown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label3;
        private ProcessEllipse processEllipse1;
    }
}