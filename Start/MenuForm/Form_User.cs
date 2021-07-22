using System;
using System.Windows.Forms;

using ToolKit.HYControls;

namespace HYProject.MenuForm
{
    public partial class Form_User : Form
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
            if (comboBox1.Text == "操作员")
            {
                if (textBox1.Text == "123456")
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
            else if (comboBox1.Text == "管理员")
            {
                if (textBox1.Text == "admin")
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
            comboBox1.Text = AppParam.Instance.Power == "管理员" ? "管理员" : "操作员";
        }
    }
}