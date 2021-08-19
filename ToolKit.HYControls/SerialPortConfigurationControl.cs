using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace ToolKit.HYControls
{
    public partial class SerialPortConfigurationControl : UserControl
    {
        private string _PortName;
        private int _BaudRate;
        private Parity _Parity;
        private int _DataBits;
        private StopBits _StopBits;

        public string PortName
        {
            get
            {
                _PortName = cmb_com.Text;
                return this._PortName;
            }

            set
            {
                this._PortName = value;
                cmb_com.Text = value;
            }
        }

        public int BaudRate
        {
            get
            {
                _BaudRate = int.Parse(cmb_btl.Text);
                return this._BaudRate;
            }

            set
            {
                this._BaudRate = value;
                cmb_btl.Text = value.ToString();
            }
        }

        public Parity Parity
        {
            get
            {
                this._Parity = (Parity)Enum.Parse(typeof(Parity), cmb_jojy.Text);
                return this._Parity;
            }

            set
            {
                this._Parity = value;
                cmb_jojy.Text = value.ToString();
            }
        }

        public int DataBits
        {
            get
            {
                this._DataBits = int.Parse(cmb_sjw.Text);
                return this._DataBits;
            }

            set
            {
                this._DataBits = value;
                cmb_sjw.Text = value.ToString();
            }
        }

        public StopBits StopBits
        {
            get
            {
                this._StopBits = (StopBits)Enum.Parse(typeof(StopBits), cmb_stop.Text);
                return this._StopBits;
            }

            set
            {
                this._StopBits = value;
                cmb_stop.Text = value.ToString();
            }
        }

        public SerialPortConfigurationControl()
        {
            InitializeComponent();
            if (cmb_com.Items.Count == 0)
            {
                cmb_com.DataSource = SerialPort.GetPortNames();
                cmb_btl.DataSource = new object[] { 300, 1200, 2400, 9600, 19200, 38400, 115200 };
                cmb_jojy.DataSource = Enum.GetValues(Parity.Even.GetType());
                cmb_sjw.DataSource = new object[] { 6, 7, 8 };
                cmb_stop.DataSource = Enum.GetValues(StopBits.One.GetType());
                if (cmb_com.Items.Count > 0)
                {
                    cmb_com.SelectedIndex = 0;
                }
                cmb_btl.SelectedIndex = 4;
                cmb_jojy.SelectedIndex = 0;
                cmb_sjw.SelectedIndex = 2;
                cmb_stop.SelectedIndex = 1;
            }
        }

        private void Cmb_com_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void Cmb_com_Click(object sender, EventArgs e)
        {
            if (cmb_com.Items.Count == 0)
            {
                cmb_com.DataSource = SerialPort.GetPortNames();
                cmb_btl.DataSource = new object[] { 300, 1200, 2400, 9600, 19200, 38400, 115200 };
                cmb_jojy.DataSource = Enum.GetValues(Parity.Even.GetType());
                cmb_sjw.DataSource = new object[] { 6, 7, 8 };
                cmb_stop.DataSource = Enum.GetValues(StopBits.One.GetType());
                if (cmb_com.Items.Count > 0)
                {
                    cmb_com.SelectedIndex = 0;
                }
                cmb_btl.SelectedIndex = 4;
                cmb_jojy.SelectedIndex = 0;
                cmb_sjw.SelectedIndex = 2;
                cmb_stop.SelectedIndex = 1;
            }
        }
    }
}