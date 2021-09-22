
namespace HYProject.MenuForm
{
    partial class Form_User_Setting
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_User_Setting));
            this.materialLabel1 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.materialLabel2 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.materialLabel3 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.materialLabel4 = new ToolKit.MaterialSkin.Controls.MaterialLabel();
            this.comboBox_user = new System.Windows.Forms.ComboBox();
            this.text_Old_Password = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.text_new_Password1 = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.text_new_Password2 = new ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.hyRoundButton1 = new ToolKit.HYControls.HYRoundButton();
            this.hyRoundButton2 = new ToolKit.HYControls.HYRoundButton();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.SuspendLayout();
            // 
            // materialLabel1
            // 
            this.materialLabel1.AutoSize = true;
            this.materialLabel1.Depth = 0;
            this.materialLabel1.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel1.Location = new System.Drawing.Point(132, 47);
            this.materialLabel1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel1.Name = "materialLabel1";
            this.materialLabel1.Size = new System.Drawing.Size(45, 19);
            this.materialLabel1.TabIndex = 5;
            this.materialLabel1.Text = "用户:";
            // 
            // materialLabel2
            // 
            this.materialLabel2.AutoSize = true;
            this.materialLabel2.Depth = 0;
            this.materialLabel2.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel2.Location = new System.Drawing.Point(116, 82);
            this.materialLabel2.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel2.Name = "materialLabel2";
            this.materialLabel2.Size = new System.Drawing.Size(61, 19);
            this.materialLabel2.TabIndex = 6;
            this.materialLabel2.Text = "旧密码:";
            // 
            // materialLabel3
            // 
            this.materialLabel3.AutoSize = true;
            this.materialLabel3.Depth = 0;
            this.materialLabel3.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel3.Location = new System.Drawing.Point(116, 118);
            this.materialLabel3.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel3.Name = "materialLabel3";
            this.materialLabel3.Size = new System.Drawing.Size(61, 19);
            this.materialLabel3.TabIndex = 7;
            this.materialLabel3.Text = "新密码:";
            // 
            // materialLabel4
            // 
            this.materialLabel4.AutoSize = true;
            this.materialLabel4.Depth = 0;
            this.materialLabel4.Font = new System.Drawing.Font("Roboto", 11F);
            this.materialLabel4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.materialLabel4.Location = new System.Drawing.Point(100, 154);
            this.materialLabel4.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.materialLabel4.Name = "materialLabel4";
            this.materialLabel4.Size = new System.Drawing.Size(77, 19);
            this.materialLabel4.TabIndex = 8;
            this.materialLabel4.Text = "确认密码:";
            // 
            // comboBox_user
            // 
            this.comboBox_user.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox_user.Font = new System.Drawing.Font("宋体", 12F);
            this.comboBox_user.FormattingEnabled = true;
            this.comboBox_user.Items.AddRange(new object[] {
            "操作员",
            "管理员",
            "开发人员"});
            this.comboBox_user.Location = new System.Drawing.Point(183, 42);
            this.comboBox_user.Name = "comboBox_user";
            this.comboBox_user.Size = new System.Drawing.Size(170, 24);
            this.comboBox_user.TabIndex = 9;
            // 
            // text_Old_Password
            // 
            this.text_Old_Password.Depth = 0;
            this.text_Old_Password.Hint = "";
            this.text_Old_Password.Location = new System.Drawing.Point(183, 78);
            this.text_Old_Password.MaxLength = 32767;
            this.text_Old_Password.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_Old_Password.Name = "text_Old_Password";
            this.text_Old_Password.PasswordChar = '*';
            this.text_Old_Password.SelectedText = "";
            this.text_Old_Password.SelectionLength = 0;
            this.text_Old_Password.SelectionStart = 0;
            this.text_Old_Password.Size = new System.Drawing.Size(170, 23);
            this.text_Old_Password.TabIndex = 10;
            this.text_Old_Password.TabStop = false;
            this.text_Old_Password.UseSystemPasswordChar = false;
            // 
            // text_new_Password1
            // 
            this.text_new_Password1.Depth = 0;
            this.text_new_Password1.Hint = "";
            this.text_new_Password1.Location = new System.Drawing.Point(183, 114);
            this.text_new_Password1.MaxLength = 32767;
            this.text_new_Password1.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_new_Password1.Name = "text_new_Password1";
            this.text_new_Password1.PasswordChar = '*';
            this.text_new_Password1.SelectedText = "";
            this.text_new_Password1.SelectionLength = 0;
            this.text_new_Password1.SelectionStart = 0;
            this.text_new_Password1.Size = new System.Drawing.Size(170, 23);
            this.text_new_Password1.TabIndex = 11;
            this.text_new_Password1.TabStop = false;
            this.text_new_Password1.UseSystemPasswordChar = false;
            // 
            // text_new_Password2
            // 
            this.text_new_Password2.Depth = 0;
            this.text_new_Password2.Hint = "";
            this.text_new_Password2.Location = new System.Drawing.Point(183, 150);
            this.text_new_Password2.MaxLength = 32767;
            this.text_new_Password2.MouseState = ToolKit.MaterialSkin.MouseState.HOVER;
            this.text_new_Password2.Name = "text_new_Password2";
            this.text_new_Password2.PasswordChar = '*';
            this.text_new_Password2.SelectedText = "";
            this.text_new_Password2.SelectionLength = 0;
            this.text_new_Password2.SelectionStart = 0;
            this.text_new_Password2.Size = new System.Drawing.Size(170, 23);
            this.text_new_Password2.TabIndex = 12;
            this.text_new_Password2.TabStop = false;
            this.text_new_Password2.UseSystemPasswordChar = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(359, 74);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(27, 27);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 13;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.PictureBox2_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(359, 110);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(27, 27);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 14;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.PictureBox3_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(359, 146);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(27, 27);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 15;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            this.pictureBox4.Click += new System.EventHandler(this.PictureBox4_Click);
            // 
            // hyRoundButton1
            // 
            this.hyRoundButton1.ControlState = ToolKit.HYControls.ControlState.Normal;
            this.hyRoundButton1.FlatAppearance.BorderSize = 0;
            this.hyRoundButton1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hyRoundButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.hyRoundButton1.HoverColor = System.Drawing.Color.Teal;
            this.hyRoundButton1.Location = new System.Drawing.Point(76, 206);
            this.hyRoundButton1.Name = "hyRoundButton1";
            this.hyRoundButton1.NormalColor = System.Drawing.Color.Teal;
            this.hyRoundButton1.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.hyRoundButton1.Radius = 15;
            this.hyRoundButton1.Size = new System.Drawing.Size(147, 34);
            this.hyRoundButton1.TabIndex = 16;
            this.hyRoundButton1.Text = "确    认";
            this.hyRoundButton1.UseVisualStyleBackColor = true;
            this.hyRoundButton1.Click += new System.EventHandler(this.HyRoundButton1_Click);
            // 
            // hyRoundButton2
            // 
            this.hyRoundButton2.ControlState = ToolKit.HYControls.ControlState.Normal;
            this.hyRoundButton2.FlatAppearance.BorderSize = 0;
            this.hyRoundButton2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.hyRoundButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold);
            this.hyRoundButton2.HoverColor = System.Drawing.Color.Teal;
            this.hyRoundButton2.Location = new System.Drawing.Point(267, 206);
            this.hyRoundButton2.Name = "hyRoundButton2";
            this.hyRoundButton2.NormalColor = System.Drawing.Color.Teal;
            this.hyRoundButton2.PressedColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(161)))), ((int)(((byte)(0)))));
            this.hyRoundButton2.Radius = 15;
            this.hyRoundButton2.Size = new System.Drawing.Size(147, 34);
            this.hyRoundButton2.TabIndex = 17;
            this.hyRoundButton2.Text = "取    消";
            this.hyRoundButton2.UseVisualStyleBackColor = true;
            this.hyRoundButton2.Click += new System.EventHandler(this.HyRoundButton2_Click);
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(359, 74);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(27, 27);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 20;
            this.pictureBox7.TabStop = false;
            this.pictureBox7.Click += new System.EventHandler(this.PictureBox7_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(359, 110);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(27, 27);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 21;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.PictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(359, 146);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(27, 27);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 22;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.PictureBox6_Click);
            // 
            // Form_User_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(495, 259);
            this.Controls.Add(this.pictureBox6);
            this.Controls.Add(this.pictureBox5);
            this.Controls.Add(this.pictureBox7);
            this.Controls.Add(this.hyRoundButton2);
            this.Controls.Add(this.hyRoundButton1);
            this.Controls.Add(this.pictureBox4);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.text_new_Password2);
            this.Controls.Add(this.text_new_Password1);
            this.Controls.Add(this.text_Old_Password);
            this.Controls.Add(this.comboBox_user);
            this.Controls.Add(this.materialLabel4);
            this.Controls.Add(this.materialLabel3);
            this.Controls.Add(this.materialLabel2);
            this.Controls.Add(this.materialLabel1);
            this.HideDropButtom = false;
            this.HideHelpButtom = false;
            this.HideMaxButtom = false;
            this.HideMinButtom = false;
            this.HideTitle = true;
            this.HideUserButtom = false;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IconImage = ((System.Drawing.Image)(resources.GetObject("$this.IconImage")));
            this.Name = "Form_User_Setting";
            this.Text = "用户设置";
            this.Load += new System.EventHandler(this.Form_User_Setting_Load);
            this.Controls.SetChildIndex(this.materialLabel1, 0);
            this.Controls.SetChildIndex(this.materialLabel2, 0);
            this.Controls.SetChildIndex(this.materialLabel3, 0);
            this.Controls.SetChildIndex(this.materialLabel4, 0);
            this.Controls.SetChildIndex(this.comboBox_user, 0);
            this.Controls.SetChildIndex(this.text_Old_Password, 0);
            this.Controls.SetChildIndex(this.text_new_Password1, 0);
            this.Controls.SetChildIndex(this.text_new_Password2, 0);
            this.Controls.SetChildIndex(this.pictureBox2, 0);
            this.Controls.SetChildIndex(this.pictureBox3, 0);
            this.Controls.SetChildIndex(this.pictureBox4, 0);
            this.Controls.SetChildIndex(this.hyRoundButton1, 0);
            this.Controls.SetChildIndex(this.hyRoundButton2, 0);
            this.Controls.SetChildIndex(this.pictureBox7, 0);
            this.Controls.SetChildIndex(this.pictureBox5, 0);
            this.Controls.SetChildIndex(this.pictureBox6, 0);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel1;
        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel2;
        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel3;
        private ToolKit.MaterialSkin.Controls.MaterialLabel materialLabel4;
        private System.Windows.Forms.ComboBox comboBox_user;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_Old_Password;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_new_Password1;
        private ToolKit.MaterialSkin.Controls.MaterialSingleLineTextField text_new_Password2;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox4;
        private ToolKit.HYControls.HYRoundButton hyRoundButton1;
        private ToolKit.HYControls.HYRoundButton hyRoundButton2;
        private System.Windows.Forms.PictureBox pictureBox7;
        private System.Windows.Forms.PictureBox pictureBox5;
        private System.Windows.Forms.PictureBox pictureBox6;
    }
}