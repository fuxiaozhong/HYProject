using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ToolKit.HYControls.HYForm
{
    public partial class HYBaseForm : Form
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

        private bool _HideOrClose = true;
        private bool _HideMinButtom = true;
        private bool _HideMaxButtom = true;
        private bool _HideCloseButtom = true;
        private bool _HideHelpButtom = true;
        private bool _HideUserButtom = true;
        private bool _HideDropButtom = true;
        private bool _HideTitle = false;
        private bool _HideAll = false;
        private string _userName = "未登录";
        private ContextMenuStrip _DropContextMenuStrip;
        private Color _BorderColor = Color.Gray;
        private bool _HideBorder = false;

        private Image _IconImage;

        [CategoryAttribute("其他"), DescriptionAttribute("关闭按钮是隐藏窗口  还是关闭窗口  true关闭  false隐藏")]
        public bool HideOrClose
        {
            get
            {
                return this._HideOrClose;
            }

            set
            {
                this._HideOrClose = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示最小化按钮")]
        public bool HideMinButtom
        {
            get
            {
                return this._HideMinButtom;
            }

            set
            {
                label_min.Visible = value;
                this._HideMinButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示最大化按钮")]
        public bool HideMaxButtom
        {
            get
            {
                return this._HideMaxButtom;
            }

            set
            {
                label_max.Visible = value;
                this._HideMaxButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示关闭按钮")]
        public bool HideCloseButtom
        {
            get
            {
                return this._HideCloseButtom;
            }

            set
            {
                label_close.Visible = value;
                this._HideCloseButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示帮助按钮")]
        public bool HideHelpButtom
        {
            get
            {
                return this._HideHelpButtom;
            }

            set
            {
                label_help.Visible = value;
                this._HideHelpButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示用户按钮")]
        public bool HideUserButtom
        {
            get
            {
                return this._HideUserButtom;
            }

            set
            {
                label_User.Visible = value;
                this._HideUserButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("用户名")]
        public string UserName
        {
            get
            {
                return this._userName;
            }

            set
            {
                this._userName = value;
                label_User.Text = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("图标")]
        public Image IconImage
        {
            get
            {
                return this._IconImage;
            }

            set
            {
                this._IconImage = value;
                pictureBox1.Image = value;
                this.Icon = ConvertToIcon(value);
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏标题栏")]
        public bool HideTitle
        {
            get
            {
                return this._HideTitle;
            }

            set
            {
                if (value)
                {
                    panel3.Height = 26;
                    pictureBox1.Size = new Size(27, 27);
                    label3.Text = label_Title.Text;
                }
                else
                {
                    pictureBox1.Size = new Size(67, 67);
                    panel3.Height = 67;
                    label3.Text = "";
                }
                this._HideTitle = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("按钮菜单")]
        public ContextMenuStrip DropContextMenuStrip
        {
            get
            {
                return this._DropContextMenuStrip;
            }

            set
            {
                label1.ContextMenuStrip = value;
                this._DropContextMenuStrip = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示菜单按钮")]
        public bool HideDropButtom
        {
            get
            {
                return this._HideDropButtom;
            }

            set
            {
                label1.Visible = value;
                this._HideDropButtom = value;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("边框颜色")]
        public Color BorderColor
        {
            get
            {
                return this._BorderColor;
            }

            set
            {
                this._BorderColor = value;
                this.Refresh();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (!_HideBorder)
            {
                //边框工作区
                Rectangle rect = this.ClientRectangle;
                GraphicsPath Rect = new GraphicsPath();
                Rect.AddRectangle(new RectangleF(rect.X, rect.Y, rect.Width - 1, rect.Height - 1));
                e.Graphics.DrawPath(new Pen(_BorderColor), Rect);
            }
        }

        /// <summary>
        /// 转换Image为Icon
        /// </summary>
        /// <param name="image">要转换为图标的Image对象</param>
        /// <param name="nullTonull">当image为null时是否返回null。false则抛空引用异常</param>
        /// <exception cref="ArgumentNullException" />
        public Icon ConvertToIcon(Image image, bool nullTonull = false)
        {
            if (image == null)
            {
                if (nullTonull) { return null; }
                throw new ArgumentNullException("image");
            }

            using (MemoryStream msImg = new MemoryStream(), msIco = new MemoryStream())
            {
                image.Save(msImg, ImageFormat.Png);

                using (var bin = new BinaryWriter(msIco))
                {
                    //写图标头部
                    bin.Write((short)0);           //0-1保留
                    bin.Write((short)1);           //2-3文件类型。1=图标, 2=光标
                    bin.Write((short)1);           //4-5图像数量（图标可以包含多个图像）

                    bin.Write((byte)image.Width);  //6图标宽度
                    bin.Write((byte)image.Height); //7图标高度
                    bin.Write((byte)0);            //8颜色数（若像素位深>=8，填0。这是显然的，达到8bpp的颜色数最少是256，byte不够表示）
                    bin.Write((byte)0);            //9保留。必须为0
                    bin.Write((short)0);           //10-11调色板
                    bin.Write((short)32);          //12-13位深
                    bin.Write((int)msImg.Length);  //14-17位图数据大小
                    bin.Write(22);                 //18-21位图数据起始字节

                    //写图像数据
                    bin.Write(msImg.ToArray());

                    bin.Flush();
                    bin.Seek(0, SeekOrigin.Begin);
                    return new Icon(msIco);
                }
            }
        }

        public event EventHandler UserClick;

        public event EventHandler HelpClick;

        public HYBaseForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true); //  禁止擦除背景.
            SetStyle(ControlStyles.DoubleBuffer, true); //  双缓冲
        }

        private void Label4_TextChanged(object sender, EventArgs e)
        {
            label_Title.Text = Text;
            if (_HideTitle)
            {
                panel3.Height = 26;
                pictureBox1.Size = new Size(27, 27);
                label3.Text = label_Title.Text;
            }
            else
            {
                pictureBox1.Size = new Size(67, 67);
                panel3.Height = 67;
                label3.Text = "";
            }
        }

        private void Label_min_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void Label_close_Click(object sender, EventArgs e)
        {
            if (HideOrClose)
            {
                this.Close();
            }
            else
            {
                this.Hide();
            }
        }

        private void Label_max_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
            {
                WindowState = FormWindowState.Normal;
            }
            else if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
        }

        private void Label_User_Click(object sender, EventArgs e)
        {
            UserClick?.Invoke(label_User, e);
        }

        private void Label_help_Click(object sender, EventArgs e)
        {
            HelpClick?.Invoke(this, e);
        }

        private void Label3_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Clicks <= 1)
            {
                //拖动窗体
                ReleaseCapture();//释放label1对鼠标的捕捉
                SendMessage(this.Handle, WM_SYSCOMMAND, SC_MOVE + HTCAPTION, 0);
            }
            else if (e.Clicks == 2)
            {
                if (!_HideMaxButtom)
                {
                    return;
                }
                if (this.WindowState == FormWindowState.Maximized)
                {
                    //还原窗体
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_SYSCOMMAND, SC_RESTORE, 0);
                }
                else if (this.WindowState == FormWindowState.Normal)
                {
                    //最大化窗体
                    ReleaseCapture();
                    SendMessage(this.Handle, WM_SYSCOMMAND, SC_MAXIMIZE, 0);
                }
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_NOCLOSE = 0x200;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle = cp.ClassStyle | CS_NOCLOSE;
                if (!DesignMode)
                {
                    cp.ExStyle |= 0x02000000;
                    return cp;
                }
                return cp;
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏或者显示边框")]
        public bool HideBorder
        {
            get
            {
                return this._HideBorder;
            }

            set
            {
                this._HideBorder = value;
                this.Refresh();
            }
        }

        [CategoryAttribute("其他"), DescriptionAttribute("隐藏所有")]
        public bool HideAll
        {
            get
            {
                return this._HideAll;
            }

            set
            {
                this._HideAll = value;
                panel3.Visible = value;
            }
        }

        /// <summary>
        /// 弹窗提示消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ShowMessage(string message, string title = "提示")
        {
            return HYMessageBox.Show(message, title);
        }

        /// <summary>
        /// 弹窗正常(绿色)消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ShowNormal(string message, string title = "提示")
        {
            return HYMessageBox.ShowNormal(message, title);
        }

        /// <summary>
        /// 弹窗错误(红色)消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ShowError(string message, string title = "提示")
        {
            return HYMessageBox.ShowError(message, title);
        }

        /// <summary>
        /// 弹窗警告(黄色)消息框
        /// </summary>
        /// <param name="message"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        public DialogResult ShowWarn(string message, string title = "提示")
        {
            return HYMessageBox.ShowWarn(message, title);
        }

        /// <summary>
        /// 输入字符串弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public bool InputStringDialog(ref string value, bool checkEmpty = true, string desc = "请输入字符串:", bool topMost = false)
        {
            return HYInputDialog.InputStringDialog(ref value, checkEmpty, desc, topMost);
        }

        /// <summary>
        /// 输入int类型弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public bool InputIntegerDialog(ref int value, bool checkEmpty = true, string desc = "请输入数字:", bool topMost = false)
        {
            return HYInputDialog.InputIntegerDialog(ref value, checkEmpty, desc, topMost);
        }

        /// <summary>
        /// 输入double类型弹窗
        /// </summary>
        /// <param name="value">弹窗输入的值</param>
        /// <param name="checkEmpty">检查是否为空</param>
        /// <param name="desc">提示</param>
        /// <param name="topMost">输入框是否置顶</param>
        /// <returns>输入状态</returns>
        public bool InputDoubleDialog(ref double value, bool checkEmpty = true, string desc = "请输入数字:", bool topMost = false)
        {
            return HYInputDialog.InputDoubleDialog(ref value, checkEmpty, desc, topMost);
        }

        /// <summary>
        /// 弹窗OK提醒消息框
        /// </summary>
        /// <param name="text">信息</param>
        /// <param name="delay">显示时间</param>
        public void ShowMessageTipOK(string text = null, int delay = -1)
        {
            HYMessageTip.ShowOk(text, delay);
        }

        /// <summary>
        /// 弹窗警告提醒消息框
        /// </summary>
        /// <param name="text">信息</param>
        /// <param name="delay">显示时间</param>
        public void ShowMessageTipWarning(string text = null, int delay = -1)
        {
            HYMessageTip.ShowWarning(text, delay);
        }

        /// <summary>
        /// 弹窗错误提醒消息框
        /// </summary>
        /// <param name="text">信息</param>
        /// <param name="delay">显示时间</param>
        public void ShowMessageTipError(string text = null, int delay = -1)
        {
            HYMessageTip.ShowError(text, delay);
        }

        /// <summary>
        /// 弹窗图片提醒消息框
        /// </summary>
        /// <param name="icon">图标</param>
        /// <param name="text">信息</param>
        /// <param name="delay">显示时间</param>
        public void ShowMessageTip(Image icon, string text, int delay = -1)
        {
            HYMessageTip.Show(text, icon, delay);
        }

        /// <summary>
        /// 左下角消息提示框(OK)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="title">标题</param>
        public static void ShowOKTip(string message, string title = "提示 - 正常")
        {
            HYTipWindow.ShowOKTip(message, title);
        }

        /// <summary>
        /// 左下角消息提示框(error)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="title">标题</param>
        public static void ShowErrorTip(string message, string title = "提示 - 错误")
        {
            HYTipWindow.ShowErrorTip(message, title);
        }

        /// <summary>
        /// 左下角消息提示框(警告)
        /// </summary>
        /// <param name="message">消息</param>
        /// <param name="title">标题</param>
        public static void ShowWarnTip(string message, string title = "提示 - 警告")
        {
            HYTipWindow.ShowWarnTip(message, title);
        }

        private void Label1_Click(object sender, EventArgs e)
        {
            _DropContextMenuStrip.Show(Cursor.Position);
        }

        private void HYBaseForm_Load(object sender, EventArgs e)
        {
        }
    }
}