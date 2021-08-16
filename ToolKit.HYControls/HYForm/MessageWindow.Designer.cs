
namespace ToolKit.HYControls.HYForm
{
    partial class MessageWindow
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
            this.label_title = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label_message = new System.Windows.Forms.Label();
            this.label_OK = new System.Windows.Forms.Label();
            this.label_ng = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label_title
            // 
            this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.label_title.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_title.Font = new System.Drawing.Font("宋体", 15F);
            this.label_title.ForeColor = System.Drawing.Color.White;
            this.label_title.Location = new System.Drawing.Point(0, 0);
            this.label_title.Name = "label_title";
            this.label_title.Padding = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.label_title.Size = new System.Drawing.Size(658, 40);
            this.label_title.TabIndex = 0;
            this.label_title.Text = "提示";
            this.label_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label1_MouseDown);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
            this.label2.Font = new System.Drawing.Font("宋体", 20F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(620, 1);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 37);
            this.label2.TabIndex = 1;
            this.label2.Text = "×";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.Label2_Click);
            // 
            // label_message
            // 
            this.label_message.Font = new System.Drawing.Font("宋体", 20F);
            this.label_message.ForeColor = System.Drawing.Color.White;
            this.label_message.Location = new System.Drawing.Point(12, 40);
            this.label_message.Name = "label_message";
            this.label_message.Padding = new System.Windows.Forms.Padding(10);
            this.label_message.Size = new System.Drawing.Size(634, 216);
            this.label_message.TabIndex = 2;
            this.label_message.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_OK
            // 
            this.label_OK.Font = new System.Drawing.Font("宋体", 20F);
            this.label_OK.ForeColor = System.Drawing.Color.White;
            this.label_OK.Location = new System.Drawing.Point(12, 256);
            this.label_OK.Name = "label_OK";
            this.label_OK.Size = new System.Drawing.Size(295, 46);
            this.label_OK.TabIndex = 3;
            this.label_OK.Text = "确认";
            this.label_OK.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_OK.Click += new System.EventHandler(this.Label_OK_Click);
            // 
            // label_ng
            // 
            this.label_ng.Font = new System.Drawing.Font("宋体", 20F);
            this.label_ng.ForeColor = System.Drawing.Color.White;
            this.label_ng.Location = new System.Drawing.Point(351, 256);
            this.label_ng.Name = "label_ng";
            this.label_ng.Size = new System.Drawing.Size(295, 46);
            this.label_ng.TabIndex = 4;
            this.label_ng.Text = "取消";
            this.label_ng.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_ng.Click += new System.EventHandler(this.Label_ng_Click);
            // 
            // MessageWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            this.ClientSize = new System.Drawing.Size(658, 311);
            this.Controls.Add(this.label_ng);
            this.Controls.Add(this.label_OK);
            this.Controls.Add(this.label_message);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_title);
            this.ForeColor = System.Drawing.Color.Black;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "MessageWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MessageWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label_title;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label_message;
        private System.Windows.Forms.Label label_OK;
        private System.Windows.Forms.Label label_ng;
    }
}