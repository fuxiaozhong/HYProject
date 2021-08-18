using System;
using System.Collections.Generic;
using System.Windows.Forms;

using ToolKit.HYControls;
using ToolKit.HYControls.HYForm;
using ToolKit.MaterialSkin.Controls;

namespace HYProject.MenuForm
{
    public partial class Form_User : BaseForm
    {



        public Form_User()
        {
            InitializeComponent();

        }

        public string Power;

        private void Button2_Click(object sender, EventArgs e)
        {
            MessageTip.ShowWarning("取消登陆");
            DialogResult = DialogResult.Cancel;
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (textBox_username.Text == "操作员")
            {
                if (textBox_Password.Text == "123456")
                {
                    MessageTip.ShowOk("操作员,登陆成功");
                    Power = "操作员";
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageTip.ShowError("密码错误");
                }
            }
            else if (textBox_username.Text == "管理员")
            {
                if (textBox_Password.Text == "admin")
                {
                    MessageTip.ShowOk("管理员,登陆成功");
                    Power = "管理员";
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageTip.ShowError("密码错误");
                }
            }
        }

        private void Form_User_Load(object sender, EventArgs e)
        {
            textBox_username.Text = AppParam.Instance.Power == "管理员" ? "管理员" : "操作员";
        }

        private void TextBox1_Click(object sender, EventArgs e)
        {
            contextMenuStrip1.Show(label5, new System.Drawing.Point(0, 0));
        }

        private void ContextMenuStrip1_Click(object sender, EventArgs e)
        {
            ToolStripMenuItem toolStripMenuItem = sender as ToolStripMenuItem;
            textBox_username.Text = toolStripMenuItem.Text;
        }
    }
}