using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public partial class DataStatisticsControl : UserControl
    {
        public DataStatisticsControl()
        {
            InitializeComponent();
        }

        private int _ok;
        private int _ng;
        private int _total;

        [Description("OK"), Category("自定义")]
        public int Ok
        {
            get
            {
                return this._ok;
            }

            set
            {
                this._ok = value;
                _total = _ng + _ok;
                label4.Text = _ok.ToString();
                label5.Text = _ng.ToString();
                label6.Text = _total.ToString();
            }
        }

        [Description("NG"), Category("自定义")]
        public int Ng
        {
            get
            {
                return this._ng;
            }

            set
            {
                this._ng = value;
                _total = _ng + _ok;
                label4.Text = _ok.ToString();
                label5.Text = _ng.ToString();
                label6.Text = _total.ToString();
            }
        }

        [Description("TOTAL"), Category("自定义")]
        public int Total
        {
            get
            {
                return this._total;
            }
        }

        private void DataStatisticsControl_FontChanged(object sender, EventArgs e)
        {
            label1.Font = this.Font;
            label2.Font = this.Font;
            label3.Font = this.Font;
            label4.Font = this.Font;
            label5.Font = this.Font;
            label6.Font = this.Font;
            label1.Refresh();
            label2.Refresh();
            label3.Refresh();
            label4.Refresh();
            label5.Refresh();
            label6.Refresh();
        }

        private void 清空ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Ok = 0;
            Ng = 0;
        }

        public void Clear()
        {
            Ok = 0;
            Ng = 0;
        }

        //private Font m_font = new Font("Arial Unicode MS", 12);
        //[Description("文字字体"), Category("自定义")]
        //public override Font Font
        //{
        //    get
        //    {
        //        return m_font;
        //    }
        //    set
        //    {
        //        m_font = value;
        //        //label1.Font = value;
        //        //label2.Font = value;
        //        //label3.Font = value;
        //        //label4.Font = value;
        //        //label5.Font = value;
        //        //label6.Font = value;
        //        //label1.Refresh();
        //        //label2.Refresh();
        //        //label3.Refresh();
        //        //label4.Refresh();
        //        //label5.Refresh();
        //        //label6.Refresh();
        //        Refresh();
        //    }
        //}
    }
}