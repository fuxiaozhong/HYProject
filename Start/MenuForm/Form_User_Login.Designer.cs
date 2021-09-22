
namespace HYProject.MenuForm
{
    partial class Form_User_Login
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User_Login));
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_Password = new System.Windows.Forms.TextBox();
            this.textBox_username = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.操作员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.adminToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开发人员ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(222, 127);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 22);
            this.label2.TabIndex = 1;
            this.label2.Text = "UserName";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("宋体", 12F);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(156, 268);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 35);
            this.button1.TabIndex = 5;
            this.button1.Text = "登陆";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(50)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("宋体", 12F);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(338, 268);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(142, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.label1.Font = new System.Drawing.Font("楷体", 15F);
            this.label1.Location = new System.Drawing.Point(0, 322);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(633, 26);
            this.label1.TabIndex = 8;
            this.label1.Text = "深圳市恒越自动化科技有限公司";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(154, 52);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(326, 36);
            this.label4.TabIndex = 9;
            this.label4.Text = "Welcome To LoginWin";
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Gray;
            this.label5.Location = new System.Drawing.Point(226, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(200, 2);
            this.label5.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(222, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 22);
            this.label6.TabIndex = 13;
            this.label6.Text = "Password";
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Gray;
            this.label7.Location = new System.Drawing.Point(226, 249);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(200, 2);
            this.label7.TabIndex = 15;
            // 
            // textBox_Password
            // 
            this.textBox_Password.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_Password.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.textBox_Password.Location = new System.Drawing.Point(226, 221);
            this.textBox_Password.Name = "textBox_Password";
            this.textBox_Password.PasswordChar = '*';
            this.textBox_Password.Size = new System.Drawing.Size(200, 27);
            this.textBox_Password.TabIndex = 14;
            this.textBox_Password.UseSystemPasswordChar = true;
            this.textBox_Password.WordWrap = false;
            // 
            // textBox_username
            // 
            this.textBox_username.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox_username.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.textBox_username.Location = new System.Drawing.Point(226, 152);
            this.textBox_username.Multiline = true;
            this.textBox_username.Name = "textBox_username";
            this.textBox_username.Size = new System.Drawing.Size(200, 25);
            this.textBox_username.TabIndex = 16;
            this.textBox_username.Text = "Admin";
            this.textBox_username.Click += new System.EventHandler(this.TextBox1_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.AutoSize = false;
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.操作员ToolStripMenuItem,
            this.adminToolStripMenuItem,
            this.开发人员ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.contextMenuStrip1.Size = new System.Drawing.Size(200, 130);
            // 
            // 操作员ToolStripMenuItem
            // 
            this.操作员ToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.操作员ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.操作员ToolStripMenuItem.Name = "操作员ToolStripMenuItem";
            this.操作员ToolStripMenuItem.Size = new System.Drawing.Size(160, 32);
            this.操作员ToolStripMenuItem.Text = "操作员";
            this.操作员ToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuStrip1_Click);
            // 
            // adminToolStripMenuItem
            // 
            this.adminToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.adminToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.adminToolStripMenuItem.Name = "adminToolStripMenuItem";
            this.adminToolStripMenuItem.Size = new System.Drawing.Size(160, 32);
            this.adminToolStripMenuItem.Text = "管理员";
            this.adminToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuStrip1_Click);
            // 
            // 开发人员ToolStripMenuItem
            // 
            this.开发人员ToolStripMenuItem.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold);
            this.开发人员ToolStripMenuItem.Name = "开发人员ToolStripMenuItem";
            this.开发人员ToolStripMenuItem.Size = new System.Drawing.Size(160, 32);
            this.开发人员ToolStripMenuItem.Text = "开发人员";
            this.开发人员ToolStripMenuItem.Click += new System.EventHandler(this.ContextMenuStrip1_Click);
            // 
            // Form_User_Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(633, 348);
            this.Controls.Add(this.textBox_username);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_Password);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideOrClose = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_User_Login";
            this.ShowInTaskbar = false;
            this.Text = "深圳市恒越自动化科技有限公司";
            this.Load += new System.EventHandler(this.Form_User_Load);
            this.Controls.SetChildIndex(this.label2, 0);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.label1, 0);
            this.Controls.SetChildIndex(this.label4, 0);
            this.Controls.SetChildIndex(this.label5, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBox_Password, 0);
            this.Controls.SetChildIndex(this.label7, 0);
            this.Controls.SetChildIndex(this.textBox_username, 0);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_Password;
        private System.Windows.Forms.TextBox textBox_username;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem adminToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 操作员ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 开发人员ToolStripMenuItem;
    }
}