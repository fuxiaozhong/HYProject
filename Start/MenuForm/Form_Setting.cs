using System;
using System.Threading;
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
            CheckForIllegalCrossThreadCalls = false;
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
            AppParam.Instance.IsSaveImage = checkBox5.Checked;
            AppParam.Instance.IsSaveImage_OK = checkBox6.Checked;
            AppParam.Instance.IsSaveImage_NG = checkBox7.Checked;
            AppParam.Instance.IsSaveImage_BmpImage = checkBox8.Checked;
            AppParam.Instance.IsSaveImage_DumpImage = checkBox9.Checked;
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
            checkBox5.Checked = AppParam.Instance.IsSaveImage;
            checkBox6.Checked = AppParam.Instance.IsSaveImage_OK;
            checkBox7.Checked = AppParam.Instance.IsSaveImage_NG;
            checkBox8.Checked = AppParam.Instance.IsSaveImage_BmpImage;
            checkBox9.Checked = AppParam.Instance.IsSaveImage_DumpImage;
            Thread thread = new Thread(DiskRefresh)
            {
                IsBackground = true
            };
            thread.Start();
        }

        public static long GetHardDiskFreeSpace(string str_HardDiskName) //磁盘号
        {
            long freeSpace = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    freeSpace = drive.TotalFreeSpace;//剩余容量
                    freeSpace = drive.TotalSize; //总容量
                }
            }
            return freeSpace;
        }

        /// <summary>
        /// 图像、数据保存磁盘检测
        /// </summary>
        private void DiskRefresh()
        {
            while (true)
            {
                try
                {
                    long TotalFreeSpace = new long();
                    long TotalSize = new long();
                    string sidkName = AppParam.Instance.Save_Image_Path.Substring(0, 1) + ":\\";
                    System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
                    foreach (System.IO.DriveInfo drive in drives)
                    {
                        if (drive.Name == sidkName)
                        {
                            TotalFreeSpace = drive.TotalFreeSpace / 1024 / 1024 / 1024;//剩余容量
                            TotalSize = drive.TotalSize / 1024 / 1024 / 1024; //总容量
                            label7.Text = "剩余：" + TotalFreeSpace + "/总：" + TotalSize;
                            progressBar1.Value = 100 - (int)((double)TotalFreeSpace / (double)TotalSize * 100);
                            break;
                        }
                    }
                    sidkName = AppParam.Instance.Save_Data_Path.Substring(0, 1) + ":\\";
                    foreach (System.IO.DriveInfo drive in drives)
                    {
                        if (drive.Name == sidkName)
                        {
                            TotalFreeSpace = drive.TotalFreeSpace / 1024 / 1024 / 1024;//剩余容量
                            TotalSize = drive.TotalSize / 1024 / 1024 / 1024; //总容量
                            label8.Text = "剩余：" + TotalFreeSpace + "/总：" + TotalSize;
                            progressBar2.Value = 100 - (int)((double)TotalFreeSpace / (double)TotalSize * 100);
                            break;
                        }
                    }
                }
                catch (Exception)
                {
                }
                Thread.Sleep(100);
            }
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
                DialogResult dialogResult = MessageBox.Show("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录管理员账户,在进行操作", "权限提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                if (dialogResult == DialogResult.OK)
                {
                    Form_User form_User = new Form_User();
                    if (form_User.ShowDialog() == DialogResult.OK)
                    {
                        AppParam.Instance.Power = form_User.Power;
                        Log.RunLog("切换用户:" + AppParam.Instance.Power);
                        MainForm.Instance.Text = "视觉软件 -- " + AppParam.Instance.Power;
                    }
                }
            }
        }

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox5.Checked;
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Form_Communication_Test form_Communication_Test = new Form_Communication_Test();
            form_Communication_Test.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Form_Measure measure = new Form_Measure();
            measure.ShowDialog();
        }
    }
}