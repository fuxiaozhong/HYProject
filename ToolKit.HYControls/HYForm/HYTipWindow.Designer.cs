
namespace ToolKit.HYControls.HYForm
{
    partial class HYTipWindow
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
            this.label_message = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_title = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_message
            // 
            this.label_message.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_message.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label_message.ForeColor = System.Drawing.Color.White;
            this.label_message.Location = new System.Drawing.Point(4, 28);
            this.label_message.Name = "label_message";
            this.label_message.Padding = new System.Windows.Forms.Padding(10);
            this.label_message.Size = new System.Drawing.Size(298, 125);
            this.label_message.TabIndex = 7;
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(265, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "×";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_title.Size = new System.Drawing.Size(304, 28);
            this.label_title.TabIndex = 5;
            this.label_title.Text = "提示";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label_title_MouseDown);
            // 
            // MessageTipWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(304, 155);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_title);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageTipWindow";
            this.ShowInTaskbar = false;
            this.Text = "MessageTipWindow";
            this.Load += new System.EventHandler(this.MessageTipWindow_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_title;
    }
}