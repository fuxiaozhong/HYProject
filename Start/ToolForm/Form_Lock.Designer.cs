
namespace HYProject.ToolForm
{
    partial class Form_Lock
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_Lock));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.materialLabel1 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.tbx_password = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(6, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(46, 38);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(58, 4);
            this.materialLabel1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(81, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "锁定中......";
            // 
            // tbx_password
            // 
            this.tbx_password.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbx_password.Font = new System.Drawing.Font("宋体", 12F);
            this.tbx_password.Location = new System.Drawing.Point(12, 60);
            this.tbx_password.Multiline = true;
            this.tbx_password.Name = "tbx_password";
            this.tbx_password.PasswordChar = '*';
            this.tbx_password.Size = new System.Drawing.Size(176, 29);
            this.tbx_password.TabIndex = 6;
            this.tbx_password.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbx_password.Click += new System.EventHandler(this.Tbx_password_Click);
            this.tbx_password.TextChanged += new System.EventHandler(this.Tbx_password_TextChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(195, 60);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(62, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "解锁";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form_Lock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(269, 101);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tbx_password);
            this.Controls.Add(this.materialLabel1);
            this.Controls.Add(this.pictureBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.Name = "Form_Lock";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form_Lock";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_Lock_FormClosing);
            this.Load += new System.EventHandler(this.Form_Lock_Load);
            this.Shown += new System.EventHandler(this.Form_Lock_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_Lock_KeyDown);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.setForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.setForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.setForm_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel1;
        private System.Windows.Forms.TextBox tbx_password;
        private System.Windows.Forms.Button button1;
    }
}