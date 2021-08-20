using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class HYTipWindow : Form
    {
        [DllImport("user32")]
        private static extern bool AnimateWindow(IntPtr hwnd, int dwTime, int dwFlags);

        //下面是可用的常量,按照不合的动画结果声明本身须要的
        private const int AW_VER_NEGATIVE = 0x0008;//自下向上显示窗口,该标记可以在迁移转变动画和滑动动画中应用。应用AW_CENTER标记时忽视该标记该标记

        private const int AW_HIDE = 0x10000;//隐蔽窗口
        private const int AW_ACTIVE = 0x20000;//激活窗口,在应用了AW_HIDE标记后不要应用这个标记
        private const int AW_SLIDE = 0x40000;//应用滑动类型动画结果,默认为迁移转变动画类型,当应用AW_CENTER标记时,这个标记就被忽视
        private const int AW_BLEND = 0x80000;//应用淡入淡出结果

        [DllImport("user32.dll")]//命名空间System.Runtime.InteropServices;
        public static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        public static extern bool SendMessage(IntPtr hwnd, int wMsg, int wParam, int lParam);

        public const int WM_SYSCOMMAND = 0x0112;
        public const int SC_MOVE = 0xF010;
        public const int HTCAPTION = 0x0002;
        public const int SC_MINIMIZE = 0xF020;
        public const int SC_MAXIMIZE = 0xF030;
        public const int SC_RESTORE = 0xF120;
        public const int SC_SIZE = 0xF000;

        //改变窗体大小，SC_SIZE+下面的值
        public const int LEFT = 0x0001;//光标在窗体左边缘

        public const int RIGHT = 0x0002;//右边缘
        public const int UP = 0x0003;//上边缘
        public const int LEFTUP = 0x0004;//左上角
        public const int RIGHTUP = 0x0005;//右上角
        public const int BOTTOM = 0x0006;//下边缘
        public const int LEFTBOTTOM = 0x0007;//左下角
        public const int RIGHTBOTTOM = 0x0008;//右下角

        public HYTipWindow(string message, string title = "正常 - 提示")
        {
            InitializeComponent();
            label_message.Text = message;
            label_title.Text = title;
        }

        private void MessageTipWindow_Load(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);//设置窗体在屏幕右下角显示
            AnimateWindow(this.Handle, 1000, AW_SLIDE | AW_ACTIVE | AW_VER_NEGATIVE);

            Thread thread = new Thread(Test);
            thread.IsBackground = true;
            thread.Start();
        }

        private bool state = true;

        private void Test()
        {
            Thread.Sleep(5000);
            while (state)
            {
                try
                {
                    if ((System.Windows.Forms.Control.MousePosition.X >= this.Location.X && System.Windows.Forms.Control.MousePosition.X <= this.Location.X + Width) &&
                        (System.Windows.Forms.Control.MousePosition.Y >= this.Location.Y && System.Windows.Forms.Control.MousePosition.Y <= this.Location.Y + Height))
                    {
                        this.Opacity = 1;
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        this.Opacity = this.Opacity - 0.1;//透明频度
                        if (this.Opacity == 0)
                        {
                            this.Close();
                            this.Dispose();
                        }
                        Thread.Sleep(100);
                    }
                }
                catch (Exception)
                {
                }
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            state = false;
            AnimateWindow(this.Handle, 1000, AW_BLEND | AW_HIDE);
        }

        private void Label_title_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();//释放label1对鼠标的捕捉
            SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
        }

        public void style(string value)
        {
            if (value == "OK")
            {
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
            }
            else if (value == "Error")
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.BackColor = System.Drawing.Color.Red;
            }
            else if (value == "Warn")
            {
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.BackColor = System.Drawing.Color.Gold;
            }
            else
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
            }
        }

        public static void ShowOKTip(string message, string title = "提示 - 正常")
        {
            HYTipWindow messageTipWindow = new HYTipWindow(message, title);
            messageTipWindow.style("OK");
            messageTipWindow.Show();
        }

        public static void ShowErrorTip(string message, string title = "提示 - 错误")
        {
            HYTipWindow messageTipWindow = new HYTipWindow(message, title);
            messageTipWindow.style("Error");
            messageTipWindow.Show();
        }

        public static void ShowWarnTip(string message, string title = "提示 - 警告")
        {
            HYTipWindow messageTipWindow = new HYTipWindow(message, title);
            messageTipWindow.style("Warn");
            messageTipWindow.Show();
        }
    }
}