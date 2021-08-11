using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
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

        /// <summary>
        /// 获取窗口
        /// </summary>
        /// <param name="key">下标0开始</param>
        /// <returns></returns>
        public HalconDisplayWindow this[string key]
        {
            get
            {
                foreach (string item in HWindows.Keys)
                {
                    if (item == key)
                    {
                        return HWindows[key];
                    }
                }
                return HWindows.Values.ElementAt(0);
            }
        } /// <summary>
          /// 获取窗口
          /// </summary>
          /// <param name="key">下标0开始</param>
          /// <returns></returns>
        public HalconDisplayWindow this[int index]
        {
            get
            {
                if (index < HWindows.Count && index >= 0)
                {
                    return HWindows.Values.ElementAt(index);
                }

                else
                {
                    return HWindows.Values.ElementAt(0);
                }
            }
        }

        private Dictionary<string, HalconDisplayWindow> HWindows = new Dictionary<string, HalconDisplayWindow>();
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

                lock (HWindows)
                {
                    Init();
                    for (int i = 0; i < count; i++)
                    {
                        Panel panel = new Panel()
                        {
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(1, 1, 1, 1),
                            Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / col) : Math.Floor(this.Width / col)) - 1, (int)(this.Height / row))
                        };
                        HalconDisplayWindow hWinControl = new HalconDisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
                        panel.Controls.Add(hWinControl);
                        flowLayoutPanel1.Controls.Add(panel);

                        HWindows.Add(i.ToString(), hWinControl);
                    }
                }
            }
        }


        public string[] CameraNames
        {
            get
            {
                string[] camerasName = new string[HWindows.Count];

                for (int i = 0; i < HWindows.Count; i++)
                {
                    camerasName[i] = HWindows.ElementAt(i).Key;
                }
                return camerasName;
            }

            set
            {
                if (value.Length > 12)
                    this.count = 12;
                else
                    this.count = value.Length;

                lock (HWindows)
                {
                    Init();
                    for (int i = 0; i < value.Length; i++)
                    {
                        Panel panel = new Panel()
                        {
                            Margin = new Padding(0, 0, 0, 0),
                            Padding = new Padding(1, 1, 1, 1),
                            Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / col) : Math.Floor(this.Width / col)) - 1, (int)(this.Height / row))
                        };
                        HalconDisplayWindow hWinControl = new HalconDisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
                        panel.Controls.Add(hWinControl);
                        flowLayoutPanel1.Controls.Add(panel);

                        HWindows.Add(value[i], hWinControl);
                    }
                }
            }
        }

        private void Init()
        {
            lock (HWindows)
            {
                foreach (HalconDisplayWindow item in HWindows.Values)
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