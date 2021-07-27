using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace ToolKit.DisplayWindow
{
    public partial class AutoAddDisplayWindowControl : UserControl
    {
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        public AutoAddDisplayWindowControl()
        {
            InitializeComponent();
        }

        public DisplayWindow this[int key]
        {
            get
            {
                bool isExis = false;
                foreach (var item in HWindows.Keys)
                {
                    if (item == key)
                    {
                        isExis = true;
                        break;
                    }
                    isExis = false;
                }
                if (isExis)
                {
                    return HWindows[key];
                }
                else
                {
                    return HWindows[0];
                }
            }
        }

        private Dictionary<int, DisplayWindow> HWindows = new Dictionary<int, DisplayWindow>();
        private int count;

        /// <summary>
        /// 窗口个数
        /// </summary>
        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                if (value > 12)
                    this.count = 12;
                else
                    this.count = value;

                lock (HWindows) { Init(); }
            }
        }

        private void Init()
        {
            lock (HWindows)
            {
                foreach (DisplayWindow item in HWindows.Values)
                {
                    item.HalconWindow.Dispose();
                    item.Dispose();
                }
                HWindows.Clear();
                flowLayoutPanel1.Controls.Clear();

                switch (count)
                {
                    case 1:
                        row = 1;
                        col = 1;
                        count = 1;
                        break;

                    case 2:
                        row = 1;
                        col = 2;
                        count = 2;
                        break;

                    case 3:
                        row = 1;
                        col = 3;
                        count = 4;
                        break;

                    case 4:
                        row = 2;
                        col = 2;
                        count = 4;
                        break;

                    case 5:
                    case 6:
                        row = 2;
                        col = 3;
                        count = 6;
                        break;

                    case 7:
                    case 8:
                        row = 2;
                        col = 4;
                        count = 8;
                        break;

                    case 9:
                        row = 3;
                        col = 3;
                        count = 9;
                        break;

                    case 10:
                    case 11:
                    case 12:
                        row = 3;
                        col = 4;
                        count = 12;
                        break;
                }
                for (int i = 0; i < count; i++)
                {
                    Panel panel = new Panel()
                    {
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(1, 1, 1, 1),
                        Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / col) : Math.Floor(this.Width / col)) - 1, (int)(this.Height / row))
                    };
                    DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
                    panel.Controls.Add(hWinControl);
                    flowLayoutPanel1.Controls.Add(panel);

                    HWindows.Add(i, hWinControl);
                }
            }
        }

        private double row = 1.0, col = 1.0;

        private void AutoAddDisplayWindowControl_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
            {
                flowLayoutPanel1.Controls[i].Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / col) : Math.Floor(this.Width / col)) - 1, (int)(this.Height / row));
            }
        }
    }
}