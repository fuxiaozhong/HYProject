
namespace ToolKit.HYControls.HYForm
{
    partial class HYBaseForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYBaseForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label_help = new System.Windows.Forms.Label();
            this.label_min = new System.Windows.Forms.Label();
            this.label_max = new System.Windows.Forms.Label();
            this.label_close = new System.Windows.Forms.Label();
            this.label_User = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.label_help);
            this.panel3.Controls.Add(this.label_min);
            this.panel3.Controls.Add(this.label_max);
            this.panel3.Controls.Add(this.label_close);
            this.panel3.Controls.Add(this.label_User);
            this.panel3.Controls.Add(this.label_Title);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(885, 67);
            this.panel3.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label1.Font = new System.Drawing.Font("宋体", 9F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(771, 0);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(0, 0, 0, 3);
            this.label1.Size = new System.Drawing.Size(23, 23);
            this.label1.TabIndex = 7;
            this.label1.Text = "∨";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label_help
            // 
            this.label_help.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_help.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label_help.Font = new System.Drawing.Font("宋体", 15F);
            this.label_help.ForeColor = System.Drawing.Color.White;
            this.label_help.Location = new System.Drawing.Point(742, 0);
            this.label_help.Name = "label_help";
            this.label_help.Size = new System.Drawing.Size(23, 23);
            this.label_help.TabIndex = 6;
            this.label_help.Text = "?";
            this.label_help.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_help.Click += new System.EventHandler(this.Label_help_Click);
            // 
            // label_min
            // 
            this.label_min.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_min.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label_min.Font = new System.Drawing.Font("宋体", 15F);
            this.label_min.ForeColor = System.Drawing.Color.White;
            this.label_min.Location = new System.Drawing.Point(800, 0);
            this.label_min.Name = "label_min";
            this.label_min.Size = new System.Drawing.Size(23, 23);
            this.label_min.TabIndex = 5;
            this.label_min.Text = "-";
            this.label_min.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label_min.Click += new System.EventHandler(this.Label_min_Click);
            // 
            // label_max
            // 
            this.label_max.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_max.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label_max.Font = new System.Drawing.Font("宋体", 15F);
            this.label_max.ForeColor = System.Drawing.Color.White;
            this.label_max.Location = new System.Drawing.Point(829, 0);
            this.label_max.Name = "label_max";
            this.label_max.Size = new System.Drawing.Size(23, 23);
            this.label_max.TabIndex = 4;
            this.label_max.Text = "□";
            this.label_max.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label_max.Click += new System.EventHandler(this.Label_max_Click);
            // 
            // label_close
            // 
            this.label_close.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label_close.Font = new System.Drawing.Font("宋体", 15F);
            this.label_close.ForeColor = System.Drawing.Color.White;
            this.label_close.Location = new System.Drawing.Point(858, 0);
            this.label_close.Name = "label_close";
            this.label_close.Size = new System.Drawing.Size(23, 23);
            this.label_close.TabIndex = 3;
            this.label_close.Text = "×";
            this.label_close.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label_close.Click += new System.EventHandler(this.Label_close_Click);
            // 
            // label_User
            // 
            this.label_User.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_User.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label_User.Font = new System.Drawing.Font("仿宋", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))));
            this.label_User.ForeColor = System.Drawing.Color.White;
            this.label_User.Location = new System.Drawing.Point(644, 1);
            this.label_User.Name = "label_User";
            this.label_User.Size = new System.Drawing.Size(92, 23);
            this.label_User.TabIndex = 2;
            this.label_User.Text = "未登录";
            this.label_User.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_User.Click += new System.EventHandler(this.Label_User_Click);
            // 
            // label_Title
            // 
            this.label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(55)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            this.label_Title.Font = new System.Drawing.Font("楷体", 25F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(67, 27);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(817, 38);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "视觉检测软件";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(0, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(30, 0, 0, 0);
            this.label3.Size = new System.Drawing.Size(883, 27);
            this.label3.TabIndex = 0;
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseDown);
            // 
            // BaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(885, 412);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "BaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.TextChanged += new System.EventHandler(this.Label4_TextChanged);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_help;
        private System.Windows.Forms.Label label_min;
        private System.Windows.Forms.Label label_max;
        private System.Windows.Forms.Label label_close;
        private System.Windows.Forms.Label label_User;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel3;
    }
}