using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToolKit.HYControls.Properties;

namespace ToolKit.HYControls
{
    [DefaultEvent("Click")]
    public partial class ProductInfo : UserControl
    {


        public ProductInfo()
        {
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProductInfo));
            ProductImage = ((System.Drawing.Image)(resources.GetObject("pictureBox_Image.Image")));
            CreateTime = DateTime.Now;
        }

        private bool _ShowBorder = false;
        private Image _ProductImage;
        private string _ProductName = "";
        private DateTime _CreateTime;


        /// <summary>
        /// 显示边框
        /// </summary>
        public bool ShowBorder
        {
            get
            {
                if (this.BackColor == System.Drawing.SystemColors.Control)
                {
                    this._ShowBorder = false;
                    return false;
                }
                else
                {
                    this._ShowBorder = true;
                    return true;
                }
            }
            set
            {
                this._ShowBorder = value;
                if (this._ShowBorder)
                {
                    this.BackColor = System.Drawing.Color.DodgerBlue;

                }
                else
                {
                    this.BackColor = System.Drawing.SystemColors.Control;
                }
            }
        }

        /// <summary>
        /// 产品图片
        /// </summary>
        public Image ProductImage
        {
            get
            {
                return this._ProductImage;
            }

            set
            {
                this._ProductImage = value;
                pictureBox_Image.Image = value;
            }
        }

        /// <summary>
        /// 产品名称
        /// </summary>
        public string ProductName
        {
            get
            {
                return this._ProductName;
            }

            set
            {
                this._ProductName = value;
                linkLabel_Name.Text = value;
            }
        }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime
        {
            get
            {
                return this._CreateTime;
            }

            set
            {
                this._CreateTime = value;
                linkLabel_CreateTime.Text = value.ToString("yyyy-MM-dd HH:mm");
            }
        }

        public event EventHandler<EventArgs> Click;
        public event EventHandler<EventArgs> DblClick;

        private void Panel1_Click(object sender, EventArgs e)
        {
            Click?.BeginInvoke(this, e, null, null);
        }

        private void Panel1_DoubleClick(object sender, EventArgs e)
        {
            DblClick?.BeginInvoke(this, e, null, null);
        }
    }
}
