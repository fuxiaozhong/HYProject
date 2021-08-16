using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class MessageWindow : Form
    {
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

        private string title = "提示";
        private string message = "";

        public string Title
        {
            get
            {
                return this.title;
            }

            set
            {
                label_title.Text = value;
                this.title = value;
            }
        }

        public string Message
        {
            get
            {
                return this.message;
            }

            set
            {
                label_message.Text = value;
                this.message = value;
            }
        }

        public MessageWindow()
        {
            InitializeComponent();
        }

        private void Label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks <= 1)
            {
                //拖动窗体
                ReleaseCapture();//释放label1对鼠标的捕捉
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
        }

        private void Label2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Label_ng_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void Label_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        public static DialogResult Show(string message, string title = "提示")
        {
            MessageWindow messageWindow = new MessageWindow();
            messageWindow.Title = title;
            messageWindow.Message = message;
            messageWindow.style("");
            return messageWindow.ShowDialog();
        }

        public static DialogResult ShowNormal(string message, string title = "提示")
        {
            MessageWindow messageWindow = new MessageWindow();
            messageWindow.Title = title;
            messageWindow.Message = message;
            messageWindow.style("Normal");
            return messageWindow.ShowDialog();
        }
        public static DialogResult ShowError(string message, string title = "提示")
        {
            MessageWindow messageWindow = new MessageWindow();
            messageWindow.Title = title;
            messageWindow.Message = message;
            messageWindow.style("Error");
            return messageWindow.ShowDialog();
        }
        public static DialogResult ShowWarn(string message, string title = "提示")
        {
            MessageWindow messageWindow = new MessageWindow();
            messageWindow.Title = title;
            messageWindow.Message = message;
            messageWindow.style("Warn");
            return messageWindow.ShowDialog();
        }

        public void style(string value)
        {
            if (value == "Normal")
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(56)))), ((int)(((byte)(142)))), ((int)(((byte)(60)))));
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(67)))), ((int)(((byte)(160)))), ((int)(((byte)(71)))));
                label2.ForeColor = Color.White;
                label_message.ForeColor = Color.White;
                label_ng.ForeColor = Color.White;
                label_OK.ForeColor = Color.White;
                label_title.ForeColor = Color.White;
            }
            else if (value == "Error")
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.BackColor = System.Drawing.Color.Red;
                label2.ForeColor = Color.White;
                label_message.ForeColor = Color.White;
                label_ng.ForeColor = Color.White;
                label_OK.ForeColor = Color.White;
                label_title.ForeColor = Color.White;
            }
            else if (value == "Warn")
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
                this.BackColor = System.Drawing.Color.Gold;
                label2.ForeColor = Color.Black;
                label_message.ForeColor = Color.Black;
                label_ng.ForeColor = Color.Black;
                label_OK.ForeColor = Color.Black;
                label_title.ForeColor = Color.Black;
            }
            else
            {
                this.label_title.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(50)))), ((int)(((byte)(56)))));
                this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(71)))), ((int)(((byte)(79)))));
                label2.ForeColor = Color.White;
                label_message.ForeColor = Color.White;
                label_ng.ForeColor = Color.White;
                label_OK.ForeColor = Color.White;
                label_title.ForeColor = Color.White;
            }



        }
    }
}
