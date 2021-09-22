using System;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Helper;
using HYProject.MenuForm;
using HYProject.Model;
using HYProject.Plugin;
using HYProject.ToolForm;

using ToolKit.HYControls.HYForm;

namespace HYProject
{
    public partial class MainForm : HYBaseForm
    {
        private static MainForm instance;

        public static MainForm Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new MainForm();
                }
                return instance;
            }
        }

        private MainForm()
        {
            InitializeComponent();
            HOperatorSet.SetSystem("clip_region", "false");
            CheckForIllegalCrossThreadCalls = false;
            //系统线程
            SystemThread.Start();

            //this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ////设定字体大小为12px
            //this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel, ((byte)(134)));
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (AppParam.Instance.RunStateMax)
                this.WindowState = FormWindowState.Maximized;
            else
                this.WindowState = FormWindowState.Normal;
            //添加主页面显示窗口
            //
            splitContainer_Main.Panel1.Controls.Add(DisplayForm.Instance);
            //split_Main.Panel2.Controls.Add(Form_DateVsualization.Instance);

            //通过数量生产 窗口数
            //DisplayForm.Instance.DisplayWindowCount = AppParam.Instance.CameraInitStr.Count == 0 ? 1 : AppParam.Instance.CameraInitStr.Count;
            //通过相机名称生产窗口
            //DisplayForm.Instance.DisplayWindowNames = Cameras.Instance.GetCameras.Keys.ToArray<string>();
            ////如果没有相机名称  默认一个相机窗口
            //if (Cameras.Instance.GetCameras.Keys.ToArray<string>().Length == 0)
            //{
            //    DisplayForm.Instance.DisplayWindowCount = 1;
            //}
            DisplayForm.Instance.DisplayWindowCount = (int)Form_Global_System.Instance["显示数量"];

            //添加日志窗口
            panel_Log.Controls.Add(Form_Logs.Instance);
            Form_Logs.Instance.Show();
            //开启图像储存到期检测
            Thread AutoDeleteImage = new Thread(AutoCheckImage.DeleteFile);
            AutoDeleteImage.IsBackground = true;
            AutoDeleteImage.Name = "DeleteFile";
            AutoDeleteImage.Start();
            //数据/图像磁盘检测
            Thread disk = new Thread(DiskRefresh);
            disk.IsBackground = true;
            disk.Name = "disk";
            disk.Start();
            //开启拍照信号检测线程
            //RunThread.Start();

            if (AppParam.Instance.StartAutoRun)
            {
                Button_Run_Click(运行ToolStripMenuItem, e);
            }
        }

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
                            if ((int)(((double)TotalSize - (double)TotalFreeSpace) / (double)TotalSize * 100) >= 95)
                            {
                                Log.WriteWarnLog("图像保存磁盘空间不足，空间剩余量低于5%，请清理磁盘");
                                Thread.Sleep(5 * 60 * 1000);
                            }
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
                            if ((int)(((double)TotalSize - (double)TotalFreeSpace) / (double)TotalSize * 100) >= 95)
                            {
                                Log.WriteWarnLog("数据保存磁盘空间不足，空间剩余量低于5%，请清理磁盘");
                                Thread.Sleep(5 * 60 * 1000);
                            }
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

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (ShowMessage("确认退出系统?", "提示") == DialogResult.OK)
            {
                HYForm_Waiting form_Waiting = new HYForm_Waiting(CloseEvent, "正在保存相关数据,请稍等!");
                if (form_Waiting.ShowDialog(this) == DialogResult.OK)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                }
                else
                {
                    e.Cancel = true;
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void CloseEvent(object sender, EventArgs e)
        {
            //全局系统变量保存
            Form_Global_System.Instance.Save();
            //全局用户变量保存
            Form_Global_User.Instance.Save();
            //运行标志 关闭
            AppParam.Instance.Runing = false;
            //关闭相机
            Cameras.Instance.CloseCamera();
            //保存配置文件
            AppParam.Instance.Save_To_File();
            //TCP服务器关闭
            AppParam.Instance.TCPSocketServer_Cam1?.Close();
            AppParam.Instance.TCPSocketServer_Cam2?.Close();
            AppParam.Instance.TCPSocketServer_Cam3?.Close();
            //TCP客户端关闭
            AppParam.Instance.TCPSocketClient?.Close();
            //数据保存
            DataLimit.Instance.Save();
            //标定数据保存
            Serialization.Save(CalibrationData.Instance, "CalibrationData");
            //光源关闭
            AppParam.Instance.lightSource?.CloseLightSource();
            //PLC关闭
            AppParam.Instance.Fx3uPLC?.ConnectClose();
            Thread.Sleep(1000);
        }

        private void Button_Run_Click(object sender, EventArgs e)
        {
            if (运行ToolStripMenuItem.ForeColor == Color.Red)
            {
                this.运行ToolStripMenuItem.Image = ((System.Drawing.Image)(new System.ComponentModel.ComponentResourceManager(typeof(MainForm)).GetObject("toolStripMenuItem1.Image")));
                运行ToolStripMenuItem.ForeColor = Color.Green;
                AppParam.Instance.Runing = true;
                运行ToolStripMenuItem.Text = "停    止";
                Log.WriteRunLog("开始运行...");
            }
            else
            {
                运行ToolStripMenuItem.ForeColor = Color.Red;
                运行ToolStripMenuItem.Text = "运    行";
                this.运行ToolStripMenuItem.Image = ((System.Drawing.Image)(new System.ComponentModel.ComponentResourceManager(typeof(MainForm)).GetObject("运行ToolStripMenuItem.Image")));
                AppParam.Instance.Runing = false;
                Log.WriteRunLog("停止运行...");
            }
        }

        private void Button_Camera_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Runing)
            {
                ShowMessage("当前正在运行中,请先停止运行。", "提示");
                return;
            }

            if (Cameras.Instance.GetCameras.Count == 0)
            {
                if (ShowMessage("无相机连接!点击确认重新初始化相机.", "提示") == DialogResult.OK)
                {
                    Cameras.Instance.ReInitializeCamera();
                }
                return;
            }
            Form_Camera form_Camera = new Form_Camera();
            form_Camera.Show();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            //F5运行
            if (e.KeyCode == Keys.F5)
            {
                Button_Run_Click(运行ToolStripMenuItem, e);
            }
            //Alt + C 打开相机操作窗口
            else if (ModifierKeys == Keys.Alt && e.KeyCode == Keys.C)
            {
                Button_Camera_Click(相机ToolStripMenuItem, e);
            }
            //Alt + S 打开设置窗口
            else if (ModifierKeys == Keys.Alt && e.KeyCode == Keys.S)
            {
                系统设置ToolStripMenuItem_Click(设置ToolStripMenuItem, e);
            }
            //Ctrl + E 退出
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Button_Exit_Click(sender, e);
            }
            //Ctrl + Enter 登陆
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Enter)
            {
                Form_User_Login form_User = new Form_User_Login();
                if (form_User.ShowDialog() == DialogResult.OK)
                {
                    AppParam.Instance.Power = form_User.Power;
                    Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                    Text = "视觉软件 -- " + AppParam.Instance.Power;
                    this.UserName = AppParam.Instance.Power;
                }
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            //Form_ProjectLibrary.Instance.Show();

            new Form_Product_Set().ShowDialog();
        }

        private void MainForm_UserClick(object sender, EventArgs e)
        {
            Form_User_Login form_User = new Form_User_Login();
            if (form_User.ShowDialog() == DialogResult.OK)
            {
                AppParam.Instance.Power = form_User.Power;
                Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                Text = "视觉软件 -- " + AppParam.Instance.Power;
                (sender as System.Windows.Forms.Label).Text = AppParam.Instance.Power;
            }
        }

        private void 锁定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Lock form_Lock = new Form_Lock();
            form_Lock.ShowDialog();
        }

        private void 相机配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_CameraInit form_CameraInit = new Form_CameraInit();
            form_CameraInit.ShowDialog();
        }

        private void 光源配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_LightSource form_LightSource = new Form_LightSource();
            form_LightSource.Show();
        }

        private void 全局变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 屏幕键盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\osk.exe");
        }

        private void 用户变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Power == "管理员" || AppParam.Instance.Power == "开发人员")
            {
                Form_Global_User.Instance.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = ShowMessage("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录 管理员/开发人员 账户,在进行操作", "权限提示");
                if (dialogResult == DialogResult.OK)
                {
                    Form_User_Login form_User = new Form_User_Login();
                    if (form_User.ShowDialog() == DialogResult.OK)
                    {
                        AppParam.Instance.Power = form_User.Power;
                        Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                        Form_Global_User.Instance.ShowDialog();
                    }
                }
            }
        }

        private void 系统变量ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        Login:
            if (AppParam.Instance.Power == "开发人员")
            {
                Form_Global_System.Instance.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = ShowMessage("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录 开发人员 账户,在进行操作", "权限提示");
                if (dialogResult == DialogResult.OK)
                {
                    Form_User_Login form_User = new Form_User_Login();
                    if (form_User.ShowDialog() == DialogResult.OK)
                    {
                        AppParam.Instance.Power = form_User.Power;
                        Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                        if (AppParam.Instance.Power != "开发人员")
                        {
                            goto Login;
                        }
                        Form_Global_System.Instance.ShowDialog();
                    }
                }
            }
        }

        private void PLC配置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PLC form_PLC = new Form_PLC();
            form_PLC.Show();
        }

        private void 备份ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            HYForm_Waiting form_Waiting = new HYForm_Waiting(BackUp, "正在备份,请稍等!");
            if (form_Waiting.ShowDialog(this) == DialogResult.OK)
            {
            }
        }

        private void BackUp(object sender, EventArgs e)
        {
            //Directory.SetCurrentDirectory(Directory.GetParent(System.Windows.Forms.Application.StartupPath).FullName);
            string parentPath = Directory.GetCurrentDirectory();
            if (!Directory.Exists(parentPath + "\\BackUp"))
            {
                Directory.CreateDirectory(parentPath + "\\BackUp");
            }
            ZipClass zipClass = new ZipClass();
            zipClass.ZipFileFromDirectory(System.Windows.Forms.Application.StartupPath, parentPath + "\\BackUp\\视觉软件" + DateTime.Now.ToString("yyyy-MM-dd") + "备份.zip", 9);
            ShowNormal("备份成功," + parentPath + "\\BackUp\\视觉软件" + DateTime.Now.ToString("yyyy-MM-dd") + "备份.zip");
        }

        private void 重启ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseEvent(null, null); Thread.Sleep(500);
            System.Diagnostics.Process.Start(Application.ExecutablePath);
            //关闭当前实例
            System.Diagnostics.Process.GetCurrentProcess().Kill();
        }

        private void 系统设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_System_Setting form_Setting = new Form_System_Setting();
            form_Setting.ShowDialog();
        }

        private void 用户设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_User_Setting form_User_Setting = new Form_User_Setting();
            form_User_Setting.ShowDialog();
        }

        private void TCP客户端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowNormal("暂未开发");
        }

        private void TCP服务端ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_TCPSocketSetting form_TCPSocketSetting = new Form_TCPSocketSetting();
            form_TCPSocketSetting.ShowDialog();
        }

        private void 系统操作ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Plugin.Form_OldLog form = new Plugin.Form_OldLog();
            form.Show();
        }

        private void 通讯设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void 相机标定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Robot_Calibration.Instance.Show();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }
    }
}