using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Helper;
using HYProject.MenuForm;
using HYProject.Model;
using HYProject.ToolForm;

using ToolKit.HYControls.HYForm;

namespace HYProject
{
    public partial class MainForm : Form
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

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
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
            panel_Main.Controls.Add(DisplayForm.Instance);
            //初始化显示窗口个数
            DisplayForm.Instance.DisplayWindowCount = Cameras.Instance.GetCameras.Count;
            //添加日志窗口
            panel_Log.Controls.Add(Form_Log.Instance);
            Form_Log.Instance.Show();
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
        }

        private void Refresh_Work()
        {
            while (true)
            {
                try
                {
                    SystemInfo systemInfo = new SystemInfo();
                    processEllipse3.Value = (int)Math.Ceiling(((double)((systemInfo.PhysicalMemory - systemInfo.MemoryAvailable)) / (double)(systemInfo.PhysicalMemory) * 100));
                }
                catch { }
                Thread.Sleep(50);
            }
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Cameras.Instance.CloseCamera();
                AppParam.Instance.Save_To_File();
                Log.RunLog("退出程序...");
                System.Diagnostics.Process.GetCurrentProcess().Kill();
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void Button_UserLogin_Click(object sender, EventArgs e)
        {
            Form_User form_User = new Form_User();
            if (form_User.ShowDialog() == DialogResult.OK)
            {
                AppParam.Instance.Power = form_User.Power;
                Log.RunLog("切换用户:" + AppParam.Instance.Power);
                Text = "视觉软件 -- " + AppParam.Instance.Power;
            }
        }

        private void Button_Setting_Click(object sender, EventArgs e)
        {
            Form_Setting form_Setting = new Form_Setting();
            form_Setting.ShowDialog();
        }

        private void Button_Run_Click(object sender, EventArgs e)
        {
            if (button_Run.ForeColor == Color.Red)
            {
                button_Run.ForeColor = Color.Green;
                AppParam.Instance.Runing = true;
                button_Run.Text = "停    止";
                Log.RunLog("开始运行...");
            }
            else
            {
                button_Run.ForeColor = Color.Red;
                button_Run.Text = "运    行";
                AppParam.Instance.Runing = false;
                Log.RunLog("停止运行...");
            }
        }

        private void Button_Camera_Click(object sender, EventArgs e)
        {
            if (Cameras.Instance.GetCameras.Count == 0)
            {
                if (MessageBox.Show("无相机连接!点击确认重新初始化相机.", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
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
                Button_Run_Click(button_Run, e);
            }
            //Alt + C 打开相机操作窗口
            else if (ModifierKeys == Keys.Alt && e.KeyCode == Keys.C)
            {
                Button_Camera_Click(button_Camera, e);
            }
            //Alt + S 打开设置窗口
            else if (ModifierKeys == Keys.Alt && e.KeyCode == Keys.S)
            {
                Button_Setting_Click(button_Setting, e);
            }
            //Ctrl + E 退出
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.E)
            {
                Button_Exit_Click(sender, e);
            }
            //Ctrl + Enter 登陆
            else if (ModifierKeys == Keys.Control && e.KeyCode == Keys.Enter)
            {
                Button_UserLogin_Click(sender, e);
            }
        }

        private void 重新加载相机ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //DisplayForm.Instance.DisplayWindowCount = 0;
            //重新初始化相机
            Cameras.Instance.ReInitializeCamera();
            //重新初始化显示窗口个数
            DisplayForm.Instance.DisplayWindowCount = Cameras.Instance.GetCameras.Count;
        }
    }
}