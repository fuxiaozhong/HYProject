
namespace ToolKit.HYControls
{
    partial class ProductInfo
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfo));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox_Image = new System.Windows.Forms.PictureBox();
            this.linkLabel_CreateTime = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.linkLabel_Name = new System.Windows.Forms.LinkLabel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.pictureBox_Image);
            this.panel1.Controls.Add(this.linkLabel_CreateTime);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.linkLabel_Name);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(1, 1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 104);
            this.panel1.TabIndex = 0;
            this.panel1.Click += new System.EventHandler(this.Panel1_Click);
            this.panel1.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // pictureBox_Image
            // 
            this.pictureBox_Image.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox_Image.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox_Image.Image")));
            this.pictureBox_Image.Location = new System.Drawing.Point(2, 1);
            this.pictureBox_Image.Name = "pictureBox_Image";
            this.pictureBox_Image.Size = new System.Drawing.Size(100, 100);
            this.pictureBox_Image.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox_Image.TabIndex = 12;
            this.pictureBox_Image.TabStop = false;
            this.pictureBox_Image.Click += new System.EventHandler(this.Panel1_Click);
            this.pictureBox_Image.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // linkLabel_CreateTime
            // 
            this.linkLabel_CreateTime.AutoSize = true;
            this.linkLabel_CreateTime.Enabled = false;
            this.linkLabel_CreateTime.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.linkLabel_CreateTime.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_CreateTime.Location = new System.Drawing.Point(110, 78);
            this.linkLabel_CreateTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel_CreateTime.Name = "linkLabel_CreateTime";
            this.linkLabel_CreateTime.Size = new System.Drawing.Size(123, 21);
            this.linkLabel_CreateTime.TabIndex = 11;
            this.linkLabel_CreateTime.TabStop = true;
            this.linkLabel_CreateTime.Text = "2020-8-4 09:45";
            this.linkLabel_CreateTime.Click += new System.EventHandler(this.Panel1_Click);
            this.linkLabel_CreateTime.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label3.Location = new System.Drawing.Point(109, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 21);
            this.label3.TabIndex = 10;
            this.label3.Text = "创建时间:";
            this.label3.Click += new System.EventHandler(this.Panel1_Click);
            this.label3.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // linkLabel_Name
            // 
            this.linkLabel_Name.AutoSize = true;
            this.linkLabel_Name.Enabled = false;
            this.linkLabel_Name.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.linkLabel_Name.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.linkLabel_Name.Location = new System.Drawing.Point(110, 28);
            this.linkLabel_Name.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabel_Name.Name = "linkLabel_Name";
            this.linkLabel_Name.Size = new System.Drawing.Size(46, 21);
            this.linkLabel_Name.TabIndex = 9;
            this.linkLabel_Name.TabStop = true;
            this.linkLabel_Name.Text = "TEST";
            this.linkLabel_Name.Click += new System.EventHandler(this.Panel1_Click);
            this.linkLabel_Name.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.label1.Location = new System.Drawing.Point(109, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 21);
            this.label1.TabIndex = 8;
            this.label1.Text = "名称:";
            this.label1.Click += new System.EventHandler(this.Panel1_Click);
            this.label1.DoubleClick += new System.EventHandler(this.Panel1_DoubleClick);
            // 
            // ProductInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("宋体", 9F);
            this.MaximumSize = new System.Drawing.Size(269, 108);
            this.MinimumSize = new System.Drawing.Size(269, 108);
            this.Name = "ProductInfo";
            this.Padding = new System.Windows.Forms.Padding(1);
            this.Size = new System.Drawing.Size(267, 106);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_Image)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox_Image;
        private System.Windows.Forms.LinkLabel linkLabel_CreateTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.LinkLabel linkLabel_Name;
        private System.Windows.Forms.Label label1;
    }
}
