using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        public int Count
        {
            get
            {
                return this.count;
            }

            set
            {
                this.count = value;
                lock (HWindows) { Init(); }

            }
        }

        private void Init()
        {
            foreach (DisplayWindow item in HWindows.Values)
            {
                item.HalconWindow.Dispose();
                item.Dispose();
            }
            HWindows.Clear();
            flowLayoutPanel1.Controls.Clear();

            if (count == 1)
            {
                Panel panel = new Panel()
                {
                    Margin = new Padding(0, 0, 0, 0),
                    Padding = new Padding(1, 1, 1, 1),
                    Size = new Size(this.Width, this.Height)
                };
                DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
                hWinControl.Size = new Size(panel.Width, panel.Height);
                panel.Controls.Add(hWinControl);
                flowLayoutPanel1.Controls.Add(panel);
                HWindows.Add(0, hWinControl);
            }
            else if (count == 2)
            {

                for (int i = 0; i < 2; i++)
                {
                    Panel panel = new Panel()
                    {
                        Margin = new Padding(0, 0, 0, 0),
                        Padding = new Padding(1, 1, 1, 1),
                        Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / 2.0) : Math.Floor(this.Width / 2.0)), this.Height)
                    };
                    DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
                    panel.Controls.Add(hWinControl);
                    flowLayoutPanel1.Controls.Add(panel);
                    HWindows.Add(i, hWinControl);
                }
            }










            //if (count == 1)
            //{
            //    Panel panel = new Panel()
            //    {
            //        Margin = new Padding(0, 0, 0, 0),
            //        Padding = new Padding(1, 1, 1, 1),
            //        Size = new Size(this.Width, this.Height)
            //    };
            //    DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "1" };
            //    int col = (int)Math.Ceiling(count / 2.0);
            //    hWinControl.Size = new Size(this.Width, this.Height);
            //    panel.Controls.Add(hWinControl);
            //    flowLayoutPanel1.Controls.Add(panel);
            //    HWindows.Add(0, hWinControl);
            //}
            //else if (count == 2)
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        Panel panel = new Panel()
            //        {
            //            Margin = new Padding(0, 0, 0, 0),
            //            Padding = new Padding(1, 1, 1, 1),
            //            Size = new Size(flowLayoutPanel1.Width / 2 - 1, this.Height - 1)
            //        };
            //        DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "" + i };
            //        int col = (int)Math.Ceiling(count / 2.0);
            //        hWinControl.Size = new Size(flowLayoutPanel1.Width / 2, this.Height);
            //        panel.Controls.Add(hWinControl);
            //        flowLayoutPanel1.Controls.Add(panel);
            //        HWindows.Add(i, hWinControl);
            //    }
            //}
            //else
            //{
            //    for (int i = 0; i < count; i++)
            //    {
            //        int row = 2;
            //        if (count >= 9)
            //        {
            //            row = 3;
            //        }
            //        if (count >= 16)
            //        {
            //            row = 4;
            //        }
            //        int col = (int)Math.Ceiling(count / (double)row);
            //        Panel panel = new Panel()
            //        {
            //            Margin = new Padding(0, 0, 0, 0),
            //            Padding = new Padding(1, 1, 1, 1),
            //            Size = new Size(flowLayoutPanel1.Width / col - 1, this.Height / row - 1),
            //        };
            //        DisplayWindow hWinControl = new DisplayWindow() { Margin = new Padding(0, 0, 0, 0), Dock = DockStyle.Fill, Name = "" + i };
            //        hWinControl.Size = new Size(flowLayoutPanel1.Width / col, this.Height / row);
            //        panel.Controls.Add(hWinControl);
            //        flowLayoutPanel1.Controls.Add(panel);
            //        HWindows.Add(i, hWinControl);
            //    }
            //}
        }

        private void AutoAddDisplayWindowControl_Resize(object sender, EventArgs e)
        {
            if (count == 1)
            {
                foreach (Control item in flowLayoutPanel1.Controls)
                {
                    item.Size = new Size(this.Width, this.Height);
                }

            }
            else if (count == 2)
            {
                for (int i = 0; i < flowLayoutPanel1.Controls.Count; i++)
                {

                    flowLayoutPanel1.Controls[i].Size = new Size((int)(i % 2 == 0 ? Math.Ceiling(this.Width / 2.0) : Math.Floor(this.Width / 2.0)), this.Height);
                }

            }



            //if (count == 1)
            //{
            //    foreach (Control item in flowLayoutPanel1.Controls)
            //    {
            //        item.Size = new Size(this.Width, this.Height);
            //    }
            //}
            //else if (count == 2)
            //{
            //    foreach (Control item in flowLayoutPanel1.Controls)
            //    {
            //        item.Size = new Size(flowLayoutPanel1.Width / 2 - 1, this.Height - 1);
            //    }
            //}
            //else
            //{
            //    int row = 2;
            //    if (count >= 9)
            //    {
            //        row = 3;
            //    }
            //    if (count >= 16)
            //    {
            //        row = 4;
            //    }
            //    double col = Math.Ceiling(count / (double)row);
            //    int index = 1;

            //    foreach (Control item in flowLayoutPanel1.Controls)
            //    {
            //        int width = 0;
            //        if (index % 2 == 0 ? true : false)
            //        {//偶数
            //            width = (int)Math.Ceiling(((double)this.flowLayoutPanel1.Width / col));
            //        }
            //        else
            //        {//奇数
            //            width = (int)Math.Floor(((double)this.flowLayoutPanel1.Width / col));
            //        }

            //        if (index == col)
            //        {
            //            index = 0;
            //        }
            //        index++;


            //        item.Size = new Size(width - 1, this.Height / row - 1);
            //    }
            //}



        }
    }
}
