using System;

using ToolKit.HYControls.HYForm;

namespace HYProject.MenuForm
{
    public partial class Form_User_Setting : HYBaseForm
    {
        public Form_User_Setting()
        {
            InitializeComponent();
        }

        private void Form_User_Setting_Load(object sender, EventArgs e)
        {
            comboBox_user.SelectedIndex = 0;
        }

        private void HyRoundButton1_Click(object sender, EventArgs e)
        {
            if (comboBox_user.Text == "操作员")
            {
                if (text_Old_Password.Text == AppParam.Instance.OperatorPassword)
                {
                    if (text_new_Password1.Text != "" && text_new_Password1.Text != null && text_new_Password1.Text == text_new_Password2.Text)
                    {
                        AppParam.Instance.OperatorPassword = text_new_Password2.Text;
                        text_new_Password1.Text = "";
                        text_new_Password2.Text = "";
                        text_Old_Password.Text = "";
                        ShowNormal("修改成功");
                    }
                    else
                    {
                        ShowWarn("两次密码输入不一致");
                        text_new_Password2.Focus();
                    }
                }
                else
                {
                    ShowWarn("旧密码错误");
                    text_Old_Password.Focus();
                }
            }
            else if (comboBox_user.Text == "管理员")
            {
                if (text_Old_Password.Text == AppParam.Instance.AdminPassword)
                {
                    if (text_new_Password1.Text != "" && text_new_Password1.Text != null && text_new_Password1.Text == text_new_Password2.Text)
                    {
                        AppParam.Instance.AdminPassword = text_new_Password2.Text;
                        text_new_Password1.Text = "";
                        text_new_Password2.Text = "";
                        text_Old_Password.Text = "";
                        ShowNormal("修改成功");
                    }
                    else
                    {
                        ShowWarn("两次密码输入不一致");
                        text_new_Password2.Focus();
                    }
                }
                else
                {
                    ShowWarn("旧密码错误");
                    text_Old_Password.Focus();
                }
            }
            else if (comboBox_user.Text == "开发人员")
            {
                if (text_Old_Password.Text == AppParam.Instance.DeveloperPassword)
                {
                    if (text_new_Password1.Text != "" && text_new_Password1.Text != null && text_new_Password1.Text == text_new_Password2.Text)
                    {
                        AppParam.Instance.DeveloperPassword = text_new_Password2.Text;
                        text_new_Password1.Text = "";
                        text_new_Password2.Text = "";
                        text_Old_Password.Text = "";
                        ShowNormal("修改成功");
                    }
                    else
                    {
                        ShowWarn("两次密码输入不一致");
                        text_new_Password2.Focus();
                    }
                }
                else
                {
                    ShowWarn("旧密码错误");
                    text_Old_Password.Focus();
                }
            }
        }

        private void PictureBox2_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = false;
            pictureBox7.Visible = true;
            text_Old_Password.PasswordChar = '*';
        }

        private void PictureBox5_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = true;
            pictureBox5.Visible = false;
            text_new_Password1.PasswordChar = new char();
        }

        private void PictureBox7_Click(object sender, EventArgs e)
        {
            pictureBox2.Visible = true;
            pictureBox7.Visible = false;
            text_Old_Password.PasswordChar = new char();
        }

        private void PictureBox3_Click(object sender, EventArgs e)
        {
            pictureBox3.Visible = false;
            pictureBox5.Visible = true;
            text_new_Password1.PasswordChar = '*';
        }

        private void PictureBox4_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = false;
            pictureBox6.Visible = true;
            text_new_Password2.PasswordChar = '*';
        }

        private void PictureBox6_Click(object sender, EventArgs e)
        {
            pictureBox4.Visible = true;
            pictureBox6.Visible = false;
            text_new_Password2.PasswordChar = new char();
        }

        private void HyRoundButton2_Click(object sender, EventArgs e)
        {
            text_new_Password1.Text = "";
            text_new_Password2.Text = "";
            text_Old_Password.Text = "";
        }
    }
}