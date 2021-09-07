
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HYBaseForm));
            this.panel3 = new System.Windows.Forms.Panel();
            this.label_User_1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label_Help_1 = new System.Windows.Forms.Label();
            this.label_Title = new System.Windows.Forms.Label();
            this.label_Menu_1 = new System.Windows.Forms.Label();
            this.label_Min_1 = new System.Windows.Forms.Label();
            this.label_Close_1 = new System.Windows.Forms.Label();
            this.label_Max_1 = new System.Windows.Forms.Label();
            this.label_minTitle = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Teal;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.label_User_1);
            this.panel3.Controls.Add(this.pictureBox1);
            this.panel3.Controls.Add(this.label_Help_1);
            this.panel3.Controls.Add(this.label_Title);
            this.panel3.Controls.Add(this.label_Menu_1);
            this.panel3.Controls.Add(this.label_Min_1);
            this.panel3.Controls.Add(this.label_Close_1);
            this.panel3.Controls.Add(this.label_Max_1);
            this.panel3.Controls.Add(this.label_minTitle);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1032, 67);
            this.panel3.TabIndex = 4;
            // 
            // label_User_1
            // 
            this.label_User_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_User_1.BackColor = System.Drawing.Color.Teal;
            this.label_User_1.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Underline);
            this.label_User_1.ForeColor = System.Drawing.Color.White;
            this.label_User_1.Location = new System.Drawing.Point(765, -1);
            this.label_User_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_User_1.Name = "label_User_1";
            this.label_User_1.Size = new System.Drawing.Size(130, 27);
            this.label_User_1.TabIndex = 3;
            this.label_User_1.Text = "未登录";
            this.label_User_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_User_1.Click += new System.EventHandler(this.Label_User_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Teal;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(-1, -1);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 67);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.toolTip1.SetToolTip(this.pictureBox1, "深圳市恒越自动化科技有限公司");
            // 
            // label_Help_1
            // 
            this.label_Help_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Help_1.BackColor = System.Drawing.Color.Teal;
            this.label_Help_1.Font = new System.Drawing.Font("仿宋", 12F, System.Drawing.FontStyle.Bold);
            this.label_Help_1.ForeColor = System.Drawing.Color.White;
            this.label_Help_1.Location = new System.Drawing.Point(895, 0);
            this.label_Help_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Help_1.Name = "label_Help_1";
            this.label_Help_1.Size = new System.Drawing.Size(27, 27);
            this.label_Help_1.TabIndex = 2;
            this.label_Help_1.Text = "?";
            this.label_Help_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Help_1.Click += new System.EventHandler(this.Label_help_Click);
            // 
            // label_Title
            // 
            this.label_Title.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(150)))));
            this.label_Title.Font = new System.Drawing.Font("楷体", 25F, System.Drawing.FontStyle.Bold);
            this.label_Title.ForeColor = System.Drawing.Color.White;
            this.label_Title.Location = new System.Drawing.Point(66, 27);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(966, 38);
            this.label_Title.TabIndex = 1;
            this.label_Title.Text = "视觉检测软件";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.toolTip1.SetToolTip(this.label_Title, "标题栏");
            this.label_Title.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseDown);
            // 
            // label_Menu_1
            // 
            this.label_Menu_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Menu_1.BackColor = System.Drawing.Color.Teal;
            this.label_Menu_1.Font = new System.Drawing.Font("宋体", 9F);
            this.label_Menu_1.ForeColor = System.Drawing.Color.White;
            this.label_Menu_1.Location = new System.Drawing.Point(922, -1);
            this.label_Menu_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Menu_1.Name = "label_Menu_1";
            this.label_Menu_1.Size = new System.Drawing.Size(27, 27);
            this.label_Menu_1.TabIndex = 7;
            this.label_Menu_1.Text = "∨";
            this.label_Menu_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Menu_1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label_Min_1
            // 
            this.label_Min_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Min_1.BackColor = System.Drawing.Color.Teal;
            this.label_Min_1.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Min_1.ForeColor = System.Drawing.Color.White;
            this.label_Min_1.Location = new System.Drawing.Point(949, 0);
            this.label_Min_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Min_1.Name = "label_Min_1";
            this.label_Min_1.Size = new System.Drawing.Size(27, 27);
            this.label_Min_1.TabIndex = 4;
            this.label_Min_1.Text = "-";
            this.label_Min_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Min_1.Click += new System.EventHandler(this.Label_min_Click);
            // 
            // label_Close_1
            // 
            this.label_Close_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Close_1.BackColor = System.Drawing.Color.Teal;
            this.label_Close_1.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Close_1.ForeColor = System.Drawing.Color.White;
            this.label_Close_1.Location = new System.Drawing.Point(1003, 0);
            this.label_Close_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Close_1.Name = "label_Close_1";
            this.label_Close_1.Size = new System.Drawing.Size(27, 27);
            this.label_Close_1.TabIndex = 5;
            this.label_Close_1.Text = "×";
            this.label_Close_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Close_1.Click += new System.EventHandler(this.Label_close_Click);
            // 
            // label_Max_1
            // 
            this.label_Max_1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label_Max_1.BackColor = System.Drawing.Color.Teal;
            this.label_Max_1.Font = new System.Drawing.Font("宋体", 15F);
            this.label_Max_1.ForeColor = System.Drawing.Color.White;
            this.label_Max_1.Location = new System.Drawing.Point(976, 0);
            this.label_Max_1.Margin = new System.Windows.Forms.Padding(0);
            this.label_Max_1.Name = "label_Max_1";
            this.label_Max_1.Size = new System.Drawing.Size(27, 27);
            this.label_Max_1.TabIndex = 6;
            this.label_Max_1.Text = "□";
            this.label_Max_1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label_Max_1.Click += new System.EventHandler(this.Label_max_Click);
            // 
            // label_minTitle
            // 
            this.label_minTitle.BackColor = System.Drawing.Color.Teal;
            this.label_minTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.label_minTitle.Font = new System.Drawing.Font("楷体", 15F, System.Drawing.FontStyle.Bold);
            this.label_minTitle.ForeColor = System.Drawing.Color.White;
            this.label_minTitle.Location = new System.Drawing.Point(0, 0);
            this.label_minTitle.Name = "label_minTitle";
            this.label_minTitle.Size = new System.Drawing.Size(1030, 27);
            this.label_minTitle.TabIndex = 0;
            this.label_minTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label_minTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Label3_MouseDown);
            // 
            // HYBaseForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1032, 556);
            this.ControlBox = false;
            this.Controls.Add(this.panel3);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Name = "HYBaseForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.HYBaseForm_Load);
            this.TextChanged += new System.EventHandler(this.Label4_TextChanged);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label_Max_1;
        private System.Windows.Forms.Label label_Close_1;
        private System.Windows.Forms.Label label_Min_1;
        private System.Windows.Forms.Label label_User_1;
        private System.Windows.Forms.Label label_Help_1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label_Menu_1;
        private System.Windows.Forms.Label label_Title;
        private System.Windows.Forms.Label label_minTitle;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}