using System;
using System.Drawing;
using System.Windows.Forms;

using HalconDotNet;

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
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            panel_Main.Controls.Add(DisplayForm.Instance);
            DisplayForm.Instance.DisplayWindowCount = 4;
            panel_Log.Controls.Add(Form_Log.Instance);
            Form_Log.Instance.Show();
        }

        private void Button_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("确认退出系统?", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.OK)
            {
                Log.RunLog("退出程序...");
                AppParam.Instance.Save_To_File();
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
                button_Run.Text = "停    止";
                Log.RunLog("开始运行...");
            }
            else
            {
                button_Run.ForeColor = Color.Red;
                button_Run.Text = "运    行";
                Log.RunLog("停止运行...");
            }
        }
    }
}