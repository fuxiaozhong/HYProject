using System;
using System.Windows.Forms;

using HYProject.Helper;
using HYProject.ToolForm;

namespace HYProject.MenuForm
{
    public partial class Form_Setting : Form
    {
        public Form_Setting()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = SelectPath();
        }

        /// <summary>
        /// 选择文件夹
        /// </summary>
        /// <returns></returns>
        public string SelectPath()
        {
            string path = string.Empty;
            System.Windows.Forms.FolderBrowserDialog fbd = new System.Windows.Forms.FolderBrowserDialog();
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                path = fbd.SelectedPath;
            }
            return path;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            textBox2.Text = SelectPath();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        /// <summary>
        /// 保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button3_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Save_Image_Path = textBox1.Text;
            AppParam.Instance.Save_Data_Path = textBox2.Text;
            AppParam.Instance.Save_Image_Days = (int)numericUpDown1.Value;
            AppParam.Instance.DesktopShortcut = checkBox1.Checked;
            AppParam.Instance.PowerBoot = checkBox2.Checked;
            AppParam.Instance.RunStateMax = checkBox3.Checked;
            AppParam.Instance.StartBeforeLogin = checkBox4.Checked;
            PowerBoot.SetMeAutoStart(AppParam.Instance.PowerBoot);
            PowerBoot.CreateDesktopShortcut(AppParam.Instance.DesktopShortcut);
            AppParam.Instance.Save_To_File();
        }

        /// <summary>
        /// 加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Setting_Load(object sender, EventArgs e)
        {
            textBox1.Text = AppParam.Instance.Save_Image_Path;
            textBox2.Text = AppParam.Instance.Save_Data_Path;
            numericUpDown1.Value = AppParam.Instance.Save_Image_Days;
            checkBox1.Checked = AppParam.Instance.DesktopShortcut;
            checkBox2.Checked = AppParam.Instance.PowerBoot;
            checkBox3.Checked = AppParam.Instance.RunStateMax;
            checkBox4.Checked = AppParam.Instance.StartBeforeLogin;
        }

        /// <summary>
        /// 操作全局变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button5_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Power == "管理员")
            {
                Form_GlobalOptions.Instance.globalVariable.Read();
                Form_GlobalOptions.Instance.ShowDialog();
            }
            else
            {
                MessageBox.Show("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录管理员账户,在进行操作", "权限提示", MessageBoxButtons.OK);
            }
        }
    }
}