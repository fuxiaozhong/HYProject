using System;
using System.Threading;
using System.Windows.Forms;

using HYProject.Helper;

using ToolKit.HYControls.HYForm;

namespace HYProject.MenuForm
{
    public partial class Form_Setting : HYBaseForm
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
            AppParam.Instance.Log_Save_Days = (int)hyNumericUpDown1.Value;
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
            hyNumericUpDown1.Value = AppParam.Instance.Log_Save_Days;
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

        private void CheckBox5_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Visible = checkBox5.Checked;
        }
    }
}