using System;
using System.IO.Ports;
using System.Windows.Forms;

using ToolKit.CommunicAtion;

namespace ToolKit.HYControls
{
    public partial class SerialPortControl : UserControl
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

        private COMSerailPortDevice serailPortDevice;

        public SerialPortControl()
        {
            InitializeComponent();
        }

        private void ComboBox1_Click(object sender, EventArgs e)
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
                cmb_btl.SelectedIndex = 3;
                cmb_jojy.SelectedIndex = 0;
                cmb_sjw.SelectedIndex = 2;
                cmb_stop.SelectedIndex = 1;
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            serailPortDevice = new COMSerailPortDevice();
            serailPortDevice.SigDataReceived += SerailPortDevice_sigDataReceived;
            bool flag = serailPortDevice.OpenSerialPort(cmb_com.Text, int.Parse(cmb_btl.Text), (Parity)Enum.Parse(typeof(Parity), cmb_jojy.Text), int.Parse(cmb_sjw.Text), (StopBits)Enum.Parse(typeof(StopBits), cmb_stop.Text));
            if (flag)
            {
                cmb_stop.Enabled = false;
                cmb_com.Enabled = false;
                cmb_jojy.Enabled = false;
                cmb_btl.Enabled = false;
                cmb_sjw.Enabled = false;
                button1.Enabled = false;
                button2.Enabled = true;
                button3.Enabled = true;
                MessageBox.Show("打开成功");
            }
            else
            {
                MessageBox.Show("打开失败");
            }
        }

        private void SerailPortDevice_sigDataReceived(object sender, SerialEventArgs e)
        {
            richTextBox2.AppendText(DateTime.Now.ToString("HH.mm.ss.ffff : ") + e.Code + "\n");
            richTextBox2.SelectionStart = richTextBox2.TextLength;
            richTextBox2.ScrollToCaret();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (serailPortDevice.IsOpen)
            {
                serailPortDevice.SendSerailData(richTextBox1.Text);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            serailPortDevice.CloseSerialPort();
            button2.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = true;
            cmb_btl.Enabled = true;
            cmb_com.Enabled = true;
            cmb_jojy.Enabled = true;
            cmb_sjw.Enabled = true;
            cmb_stop.Enabled = true;
        }
    }
}