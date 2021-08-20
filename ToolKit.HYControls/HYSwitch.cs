﻿using System;
using System.Drawing;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public enum CheckStyle
    {
        style1, style2, style3, style4, style5, style6
    }

    public partial class HYSwitch : UserControl
    {
        public HYSwitch()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            this.BackColor = Color.Transparent;
            this.Cursor = Cursors.Hand;
            this.Size = new Size(87, 27);
        }

        private bool isCheck = false;

        /// <summary>
        /// 是否选中
        /// </summary>
        public bool Checked

        {
            set { isCheck = value; this.Invalidate(); }

            get { return isCheck; }
        }

        private CheckStyle checkStyle;

        protected override void OnPaint(PaintEventArgs e)

        {
            Bitmap bitMapOn = null;

            Bitmap bitMapOff = null;

            if (checkStyle == CheckStyle.style1)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }
            else if (checkStyle == CheckStyle.style2)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }
            else if (checkStyle == CheckStyle.style3)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }
            else if (checkStyle == CheckStyle.style4)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }
            else if (checkStyle == CheckStyle.style5)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }
            else if (checkStyle == CheckStyle.style6)
            {
                bitMapOn = global::ToolKit.HYControls.Properties.Resources.Close;
                bitMapOff = global::ToolKit.HYControls.Properties.Resources.Open;
            }

            Graphics g = e.Graphics;

            Rectangle rec = new Rectangle(0, 0, this.Size.Width, this.Size.Height);

            if (!isCheck)

            {
                g.DrawImage(bitMapOn, rec);
            }
            else

            {
                g.DrawImage(bitMapOff, rec);
            }
        }

        private void Switch_Click(object sender, EventArgs e)
        {
            isCheck = !isCheck;
            this.Invalidate();
        }
    }
}