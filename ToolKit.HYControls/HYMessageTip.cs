﻿using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public static class HYMessageTip
    {
        private static readonly Image _iconOk;
        private static readonly Image _iconWarning;
        private static readonly Image _iconError;

        /// <summary>
        /// 全局停留时长（毫秒），影响后续弹出的tip。默认500
        /// </summary>
        public static int DefaultDelay { get; set; }

        /// <summary>
        /// 是否允许上浮动画。默认true
        /// </summary>
        public static bool AllowFloating { get; set; }

        static HYMessageTip()
        {
            DefaultDelay = 500;
            AllowFloating = true;

            Bitmap spriteImage;
            using (var ms = new MemoryStream(Convert.FromBase64String(DefaultIconData)))
            {
                //不能直接用Img.FromMs得到的对象，怀疑因该方法得到的对象与源ms有瓜葛
                //ms释放后会导致莫名问题，比如下面的Clone会引发内存不足异常
                //而new Bitmap(Image)相当于基于Image重造了一个全新的bmp
                spriteImage = new Bitmap(Image.FromStream(ms));
            }

            _iconOk = spriteImage.Clone(new Rectangle(0, 0, 32, 32), spriteImage.PixelFormat);
            _iconWarning = spriteImage.Clone(new RectangleF(32, 0, 32, 32), spriteImage.PixelFormat);
            _iconError = spriteImage.Clone(new RectangleF(64, 0, 32, 32), spriteImage.PixelFormat);
        }

        /// <summary>
        /// 显示良好消息，图标为绿勾 √
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长（毫秒）。指定负数则使用 DefaultDelay</param>
        public static void ShowOk(string text = null, int delay = -1)
        {
            Show(text, _iconOk, delay);
        }

        /// <summary>
        /// 显示警告消息，图标为黄色感叹号 ！
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长（毫秒）。指定负数则使用 DefaultDelay</param>
        public static void ShowWarning(string text = null, int delay = -1)
        {
            Show(text, _iconWarning, delay);
        }

        /// <summary>
        /// 显示出错消息，图标为红叉 X
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="delay">消息停留时长（毫秒）。指定负数则使用 DefaultDelay</param>
        public static void ShowError(string text = null, int delay = -1)
        {
            Show(text, _iconError, delay);
        }

        /// <summary>
        /// 显示消息
        /// </summary>
        /// <param name="text">消息文本</param>
        /// <param name="icon">图标。不会进行缩放</param>
        /// <param name="delay">消息停留时长（毫秒）。指定负数则使用 DefaultDelay</param>
        public static void Show(string text, Image icon, int delay = -1)
        {
            ThreadPool.QueueUserWorkItem(obj => new TipForm
            {
                TipText = text,
                TipIcon = icon,
                Delay = delay < 0 ? DefaultDelay : delay,
                Floating = AllowFloating,
                BasePoint = Control.MousePosition //在鼠标点击的附近弹出
            }.ShowDialog());//要让创建浮动窗体的线程具有消息循环，所以要用ShowDialog
        }

        /// <summary>
        /// 内置图标数据：√ ! X
        /// </summary>
        private const string DefaultIconData = @"R0lGODlhYAAgANUAAOrcJ9LORebm5tJKShPLJLczM/z3s/XrkNfSOhS2JKaYMezeaMoREfhwcNS3
t7IREVSkWpWQZjCpPfz8+zS4RN3PZdTU1EjLWG9uaO/w7/Dke1HVYfHsx5UzM8Q8PLjYuqmmn8bl
yeO3txsbD+fck9DAUeDaVV1cHuHXMDGTOO3iSeHy4+BYWDvGTPn25O/hN5PIl8K1Pbfhu/z78nW/
fPb39lbeZ5/WpIAzM2HpcqITExGiIjV/N8S9luLbqf///yH5BAAAAAAALAAAAABgACAAAAb/wJ9w
SCwaj8ikcslsOp/QKFNUEEGpVqm2OQtUZlJqo+oUk7fHFUWmJWk0pKi4Mc4qxaw6uli7bNZRMxUG
BhUuT3gseWdIc4p6e0I0Fzk5EmxPboQHcU2Jiot2RZ+PjFs3LTk2G5aYTC6DBweFh0wFDaC5kERi
Ayy+v4oFeyEUNqsbrJdNmm8GcJ63A9PUA7s/VL/V0yymUWobNhfj4xsSTByxb7MVHNEN29xn2fG+
3lB9F+LkfstLFbMWaBAoq0KZWx4SJhzgoZuIbB4YLox4DwqNFuJaaGxxgQIMdIM0RMCAIYKGQu6a
OCjAQqHLAQUKSHSZsOKTG8YubNRIgUYT/4AHFpAkqaHghIMtPRRQuhAm06VQHSiRAQhJCAl/JCSQ
wJUChBogDQgcimHBggPtnqyEGbOt27c2hciQYMNfkRUSOu7Yu1fCVyYTAA5cMJKk2aJfEHVgC9et
UqlJqNowZlfIBAgULvDtK2FFEx+DzArFcCKCaLQ+rixVCpd1B1FG5k6mQNnVDxoUNmzewTUElxIH
BhMeMeJEiQBeFpQAo7YDa9YPdEiP+0M27evmMN2QQCNBgs0SbjgBHXSBCQQniJ9AjnxBhU4H2Uqf
L/21ErrXrydoIeHD1Q3e7eDdVh814QJwGpjAngLEKcBeeyWA5cli9FVYH2xEzPUHBS0MuP+fBClc
4KGA3B3FTAUaBICAigEocMIJCqy4ohcBwHeHczpEZyF99iGhIQUeetfCH0H6lYETByaIwJJLxvBi
DEwyaUIJtSThQAcFPBCdljl2uWV0PR7xQV4EDFhmAmWe6R0EnjlRQQULRLmkCW+cJ6eCBiUhApZa
9unnn312AJmYErRAwKFopplmAin45gQHJWgg56SUTpmSEVcyAKiWHXSwKaeDGjGmooeWemgKHzwR
mAkmoODqqygwOIICsL66Yp6j4KDpA7vuKuiVWu7KK6hJfJCCqcimUOCjJSxQ66vEEffsqyVcKoQD
umqqrbY4QJYprwxs+4CgxR6LLAEp+KT/agkmqAArANBG+yy8KARQgok/YBvuvvx2S4S+4PLLgL9I
GIvsDhDg+1kM7gLgMLwPR0BcBA8/jMLDMaQmRLYCh0vwvxx3jIMSBiMKwZGqxmDCCxW3rIIsKrTc
MgIxmKivyKGC3PHAOf8wQQ0ZZCAACObyYIEAQWdQw9ITNH2EDwzLLPXUFWc8xM37fnwE1h73/APQ
AlggNgg88NCD2EcLgLTSThtB6wsqvCD33HIDwDLLVDsc678dZO11EZl2jcTPQattuNpJK11D020T
MUEPCkQu+eSUV255DwrrS65Kum4eyRJNAy304aSXXrriTk8wOgg4gIB22okbjjbrICC9E/jnuEcR
+uiHB73076KT7rvTQQAAOw==";

        /// <summary>
        /// 浮动消息层
        /// </summary>
        private class TipForm : Form
        {
            /// <summary>
            /// 图标和文本之间的间距（像素）
            /// </summary>
            private const int IconTextSpacing = 3;

            /// <summary>
            /// 基准点。用于指导本窗体显示位置
            /// </summary>
            public Point BasePoint { get; set; }

            private string _tipText;

            /// <summary>
            /// 提示图标
            /// </summary>
            public Image TipIcon { get; set; }

            /// <summary>
            /// 提示文本
            /// </summary>
            public string TipText
            {
                get { return _tipText ?? string.Empty; }
                set { _tipText = value; }
            }

            /// <summary>
            /// 停留时长（毫秒）
            /// </summary>
            [DefaultValue(500)]
            public int Delay { get; set; }

            /// <summary>
            /// 是否允许浮动
            /// </summary>
            [DefaultValue(true)]
            public bool Floating { get; set; }

            //显示后不激活，即不抢焦点
            protected override bool ShowWithoutActivation
            {
                get { return true; }
            }

            public TipForm()
            {
                //双缓冲。有必要
                SetStyle(ControlStyles.UserPaint, true);
                DoubleBuffered = true;

                InitializeComponent();

                Delay = 500;
                Floating = true;

                this._timer.Tick += Timer_Tick;
                this.Load += TipForm_Load;
                this.Shown += TipForm_Shown;
                this.FormClosing += TipForm_FormClosing;
            }

            /// <summary>
            /// 根据图标和文字处理窗体尺寸
            /// </summary>
            private void ProcessClientSize()
            {
                Size size = Size.Empty;
                if (TipIcon != null)
                {
                    size += TipIcon.Size;
                }
                if (TipText.Length != 0)
                {
                    if (TipIcon != null)
                    {
                        size.Width += IconTextSpacing;//图标与文字的间距
                    }
                    var textSize = TextRenderer.MeasureText(TipText, this.Font);
                    size.Width += textSize.Width;
                    if (size.Height < textSize.Height) { size.Height = textSize.Height; }
                }
                this.ClientSize = size + Padding.Size;
            }

            /// <summary>
            /// 根据基准点处理窗体显示位置
            /// </summary>
            private void ProcessLocation()
            {
                var p = BasePoint;
                p.X -= this.Width / 2;

                //横向处理。距离屏幕左右两边太近时的处理
                int screenWidth;
                if (p.X < 10)
                {
                    p.X = 10;
                }
                else if (p.X + this.Width > (screenWidth = Screen.PrimaryScreen.Bounds.Width) - 10)
                {
                    p.X = screenWidth - 10 - this.Width;
                }

                //纵向处理。在鼠标上方显示
                p.Y -= this.Height + 20;

                this.Location = p;
            }

            private void TipForm_Load(object sender, EventArgs e)
            {
                ProcessClientSize();
                ProcessLocation();

                //上浮窗体动画。采用异步，以不阻塞透明渐变动画的进行
                if (Floating)
                {
                    ThreadPool.QueueUserWorkItem(obj =>
                    {
                        while (this.IsHandleCreated)
                        {
                            this.BeginInvoke(new Action<object>(arg =>
                            {
                                this.Top--;
                                Application.DoEvents();
                            }), (object)null);

                            Thread.Sleep(30);
                        }
                    });
                }

                //透明渐入动画。之所以不用异步是为了在完全显示后再开始Delay的计时
                //不然如果Delay设置过低，还没等看清就渐隐了
                this.Opacity = 0;
                while (this.Opacity < 1)
                {
                    this.Opacity += 0.1;
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
            }

            private void TipForm_Shown(object sender, EventArgs e)
            {
                //因为timer.Interval不能为0
                if (Delay > 0)
                {
                    _timer.Interval = Delay;
                    _timer.Start();
                }
                else
                {
                    this.Close();
                }
            }

            private void Timer_Tick(object sender, EventArgs e)
            {
                _timer.Stop();
                this.Close();
            }

            private void TipForm_FormClosing(object sender, FormClosingEventArgs e)
            {
                //透明渐隐动画
                while (this.Opacity > 0)
                {
                    this.Opacity -= 0.1;
                    Application.DoEvents();
                    Thread.Sleep(20);
                }
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);

                var clip = GetPaddedRectangle();//得到作图区域
                var g = e.Graphics;
                //g.DrawRectangle(Pens.Red, clip);//debug

                //画图标
                if (TipIcon != null)
                {
                    g.DrawImageUnscaled(TipIcon, clip.Location);
                }
                //画文本
                if (TipText.Length != 0)
                {
                    if (TipIcon != null)
                    {
                        clip.X += TipIcon.Width + IconTextSpacing;
                    }
                    TextRenderer.DrawText(g, TipText, this.Font, clip, this.ForeColor, TextFormatFlags.VerticalCenter);
                }
            }

            protected override void OnPaintBackground(PaintEventArgs e)
            {
                base.OnPaintBackground(e);

                //画边框
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, SystemColors.ControlDark, ButtonBorderStyle.Solid);
            }

            /// <summary>
            /// 获取刨去Padding的内容区
            /// </summary>
            private Rectangle GetPaddedRectangle()
            {
                Rectangle r = this.ClientRectangle;
                r.X += this.Padding.Left;
                r.Y += this.Padding.Top;
                r.Width -= this.Padding.Horizontal;
                r.Height -= this.Padding.Vertical;
                return r;
            }

            #region 设计器内容

            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    _timer.Dispose();//这货必须显示释放
                }
                base.Dispose(disposing);
            }

            private void InitializeComponent()
            {
                this._timer = new System.Windows.Forms.Timer();
                this.SuspendLayout();

                this.AutoScaleMode = AutoScaleMode.None;
                //this.ClientSize = new System.Drawing.Size(100, 100);
                this.BackColor = Color.White;
                this.Font = new Font(SystemFonts.MessageBoxFont.FontFamily, 12);
                this.FormBorderStyle = FormBorderStyle.None;
                this.Padding = new Padding(20, 10, 20, 10);
                this.Name = "TipForm";
                this.ShowInTaskbar = false;

                this.ResumeLayout(false);
            }

            private System.Windows.Forms.Timer _timer;

            #endregion 设计器内容
        }
    }
}