﻿using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Resources;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Arithmetic;
using HYProject.Helper;
using HYProject.MenuForm;
using HYProject.Model;
using HYProject.Plugin;
using HYProject.Properties;
using HYProject.ToolForm;

using ToolKit.CamreaSDK;
using ToolKit.CommunicAtion;
using ToolKit.HYControls.HYForm;
using ToolKit.MaterialSkin;
using ToolKit.MaterialSkin.Controls;

using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static ToolKit.MaterialSkin.Controls.MaterialForm;

namespace HYProject
{
    public partial class MainForm : HYBaseForm
    {
        private static MainForm instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static MainForm Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new MainForm();
                        }
                    }
                }
                return instance;
            }
        }

        private MainForm()
        {
            InitializeComponent();
            HOperatorSet.SetSystem("clip_region", "false");
            CheckForIllegalCrossThreadCalls = false;
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
            DisplayForm.Instance.DisplayWindowCount = AppParam.Instance.CameraInitStr.Count;

            //添加日志窗口
            panel_Log.Controls.Add(HYForm_Log.Instance);
            HYForm_Log.Instance.Show();
            //开启图像储存到期检测
            Thread AutoDeleteImage = new Thread(AutoCheckImage.DeleteFile);
            AutoDeleteImage.IsBackground = true;
            AutoDeleteImage.Name = "DeleteFile";
            AutoDeleteImage.Start();
            //开启系统信息刷新
            Thread _Refresh_Work = new Thread(Refresh_Work);
            _Refresh_Work.IsBackground = true;
            _Refresh_Work.Name = "Refresh_Work";
            _Refresh_Work.Start();
            //数据/图像磁盘检测
            Thread disk = new Thread(DiskRefresh);
            disk.IsBackground = true;
            disk.Name = "disk";
            disk.Start();
            //开启拍照信号检测线程
            RunThread.Start();
        }

        //刷新界面
        private void Refresh_Work()
        {
            while (true)
            {
                try
                {
                    //label1.Text = Form_GlobalOptions.Instance["标题栏名称"].ToString();
                    tsl_nowtime.Text = DateTime.Now.ToString("yyyy-MM-dd  HH:mm:ss");
                    this.UserName = AppParam.Instance.Power;
                    SystemInfo systemInfo = new SystemInfo();
                    pro_memory.Value = (int)Math.Ceiling(((double)((systemInfo.PhysicalMemory - systemInfo.MemoryAvailable)) / (double)(systemInfo.PhysicalMemory) * 100));
                }
                catch { }
                Thread.Sleep(50);
                Application.DoEvents();
            }
        }

        /// <summary>
        /// 实时刷新磁盘剩余量报警检测
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
            AppParam.Instance.Runing = false;
            Cameras.Instance.CloseCamera();
            AppParam.Instance.Save_To_File();
            AppParam.Instance.lightSource.CloseLightSource();
            Log.WriteRunLog("光源关闭...");
            AppParam.Instance.Fx3uPLC.ConnectClose();
            Log.WriteRunLog("PLC关闭...");
            DataLimit.Instance.Save();
            Log.WriteRunLog("退出程序...");
            Thread.Sleep(1000);
        }

        private void Button_Setting_Click(object sender, EventArgs e)
        {
            Form_Setting form_Setting = new Form_Setting();
            form_Setting.ShowDialog();
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
            if (Cameras.Instance.GetCameras.Count == 0)
            {
                if (ShowMessage("无相机连接!点击确认重新初始化相机.", "提示") == DialogResult.OK)
                {
                    Cameras.Instance.ReInitializeCamera();
                }
                return;
            }
            Form_Camera form_Camera = new Form_Camera();
            form_Camera.ShowDialog();
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
                Button_Setting_Click(设置ToolStripMenuItem, e);
            }
            //Ctrl + E 退出
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Button_Exit_Click(sender, e);
            }
            //Ctrl + Enter 登陆
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Enter)
            {
                Form_User form_User = new Form_User();
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
            Form_ProjectLibrary.Instance.Show();
        }

        private void 光源控制ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_LightSource form_LightSource = new Form_LightSource();
            form_LightSource.Show();
        }

        private void 参数设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_Limit form_Limit = new Form_Limit();
            form_Limit.Show();
        }

        private void PLC通讯设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_PLC form_PLC = new Form_PLC();
            form_PLC.Show();
        }

        private void 参数设置ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.Power == "管理员")
            {
                Form_GlobalOptions.Instance.globalVariable.Read();
                Form_GlobalOptions.Instance.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = ShowMessage("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录管理员账户,在进行操作", "权限提示");
                if (dialogResult == DialogResult.OK)
                {
                    Form_User form_User = new Form_User();
                    if (form_User.ShowDialog() == DialogResult.OK)
                    {
                        AppParam.Instance.Power = form_User.Power;
                        Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                        MainForm.Instance.Text = "视觉软件 -- " + AppParam.Instance.Power;
                    }
                }
            }
        }

        private void 数据表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_DataSheet.Instance.Show();
        }

        private void MainForm_UserClick(object sender, EventArgs e)
        {
            Form_User form_User = new Form_User();
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
            if (AppParam.Instance.Power == "管理员")
            {
                Form_GlobalOptions.Instance.globalVariable.Read();
                Form_GlobalOptions.Instance.ShowDialog();
            }
            else
            {
                DialogResult dialogResult = ShowMessage("当前用户: " + AppParam.Instance.Power + ",无权限操作,请登录管理员账户,在进行操作", "权限提示");
                if (dialogResult == DialogResult.OK)
                {
                    Form_User form_User = new Form_User();
                    if (form_User.ShowDialog() == DialogResult.OK)
                    {
                        AppParam.Instance.Power = form_User.Power;
                        Log.WriteRunLog("切换用户:" + AppParam.Instance.Power);
                        MainForm.Instance.Text = "视觉软件 -- " + AppParam.Instance.Power;
                    }
                }
            }
        }

        private void 屏幕键盘ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\osk.exe");
        }

      
    }
}