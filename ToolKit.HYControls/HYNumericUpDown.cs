using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    [DefaultEvent("ValueChanged")]
    public partial class HYNumericUpDown : UserControl
    {
        public HYNumericUpDown()
        {
            InitializeComponent();
        }
        /// <summary>
        /// 值改变事件
        /// </summary>
        public event EventHandler ValueChanged;
        /// <summary>
        /// 点击一下值的变化量
        /// </summary>
        private decimal _incremeent = 1;
        [Description("点击一下值的变化量")]
        public decimal Incremeent
        {
            get { return _incremeent; }
            set { _incremeent = value; }
        }

        /// <summary>
        /// 小数位数
        /// </summary>
        /// 
        private int _decimalPlaces = 0;
        [Description("小数位数")]
        public int DecimalPlaces
        {
            get { return _decimalPlaces; }
            set
            {
                _decimalPlaces = value;
                nud_value.DecimalPlaces = value;
            }
        }

        /// <summary>
        /// 最小值
        /// </summary>
        private decimal _minValue = 0;
        [Description("最小值")]
        public decimal MinValue
        {
            get { return _minValue; }
            set
            {
                _minValue = value;
                nud_value.Minimum = value;
            }
        }

        /// <summary>
        /// 最大值
        /// </summary>
        private decimal _maxValue = 100;
        [Description("最大值")]
        public decimal MaxValue
        {
            get { return _maxValue; }
            set
            {
                _maxValue = value;
                nud_value.Maximum = value;
            }
        }

        /// <summary>
        /// 值
        /// </summary>
        private decimal _value = 0;
        [Description("值")]
        public decimal Value
        {
            get
            {
                return nud_value.Value;
            }
            set
            {
                _value = value;
                nud_value.Value = value;
            }
        }
        private void Numeric_SizeChanged(object sender, EventArgs e)
        {
            if (Height != 22)
            {
                Height = 22;
            }
        }

        private void Nud_value_ValueChanged(object sender, EventArgs e)
        {
            ValueChanged?.Invoke(sender, e);
        }

        private void Btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                nud_value.Value = nud_value.Value += _incremeent;
            }
            catch
            {
                nud_value.Value = nud_value.Maximum;
            }

        }

        private void Btn_sub_Click(object sender, EventArgs e)
        {
            try
            {
                nud_value.Value = nud_value.Value -= _incremeent;
            }
            catch 
            {
                nud_value.Value = nud_value.Minimum;
            }
        }
    }
}
