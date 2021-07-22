using System;
using System.Windows.Forms;

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

        private void Button3_Click(object sender, EventArgs e)
        {
            AppParam.Instance.Save_Image_Path = textBox1.Text;
            AppParam.Instance.Save_Data_Path = textBox2.Text;
            AppParam.Instance.Save_Image_Days = (int)numericUpDown1.Value;
            AppParam.Instance.DesktopShortcut = checkBox1.Checked;
            AppParam.Instance.PowerBoot = checkBox2.Checked;
            AppParam.Instance.RunStateMax = checkBox3.Checked;
            AppParam.Instance.StartBeforeLogin = checkBox4.Checked;
        }

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
    }
}