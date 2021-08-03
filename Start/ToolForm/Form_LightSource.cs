using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HYProject.ToolForm
{
    public partial class Form_LightSource : Form
    {
        public Form_LightSource()
        {
            InitializeComponent();
        }

        private void Form_LightSource_Load(object sender, EventArgs e)
        {
            numericUpDown2.Value = AppParam.Instance.lightSource.CH1;
            numericUpDown3.Value = AppParam.Instance.lightSource.CH2;
            numericUpDown4.Value = AppParam.Instance.lightSource.CH3;
            numericUpDown5.Value = AppParam.Instance.lightSource.CH4;
            switch1.Checked = AppParam.Instance.lightSource.StateCH1;
            switch2.Checked = AppParam.Instance.lightSource.StateCH2;
            switch3.Checked = AppParam.Instance.lightSource.StateCH3;
            switch4.Checked = AppParam.Instance.lightSource.StateCH4;

            serialPortConfigurationControl1.PortName = AppParam.Instance.LightSourcePortName;
            serialPortConfigurationControl1.BaudRate = AppParam.Instance.LightSourceBaudRate;
            serialPortConfigurationControl1.DataBits = AppParam.Instance.LightSourceDataBits;
            serialPortConfigurationControl1.Parity = AppParam.Instance.LightSourceParity;
            serialPortConfigurationControl1.StopBits = AppParam.Instance.LightSourceStopBits;

            if (AppParam.Instance.lightSource.IsOpen)
            {
                serialPortConfigurationControl1.Enabled = false;
                button_Port.Enabled = false;
            }
            else
            {
                serialPortConfigurationControl1.Enabled = true;
                button_Port.Enabled = true;
            }

        }

        private void Button_Port_Click(object sender, EventArgs e)
        {
            AppParam.Instance.LightSourcePortName = serialPortConfigurationControl1.PortName;
            AppParam.Instance.LightSourceBaudRate = serialPortConfigurationControl1.BaudRate;
            AppParam.Instance.LightSourceDataBits = serialPortConfigurationControl1.DataBits;
            AppParam.Instance.LightSourceParity = serialPortConfigurationControl1.Parity;
            AppParam.Instance.LightSourceStopBits = serialPortConfigurationControl1.StopBits;
            if (AppParam.Instance.lightSource == null)
            {
                AppParam.Instance.lightSource = new ToolKit.CommunicAtion.LightSource();
            }

            if (AppParam.Instance.lightSource.OpenLightSource(AppParam.Instance.LightSourcePortName,
                                                            AppParam.Instance.LightSourceBaudRate,
                                                            AppParam.Instance.LightSourceParity,
                                                            AppParam.Instance.LightSourceDataBits,
                                                            AppParam.Instance.LightSourceStopBits))
            {
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接失败");
            }

        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;

            AppParam.Instance.lightSource.CH1 = (int)numericUpDown2.Value;
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.CH2 = (int)numericUpDown3.Value;
        }

        private void NumericUpDown4_ValueChanged(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.CH3 = (int)numericUpDown4.Value;

        }

        private void NumericUpDown5_ValueChanged(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.CH4 = (int)numericUpDown5.Value;
        }

        private void Switch1_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.StateCH1 = switch1.Checked;
        }

        private void Switch2_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.StateCH2 = switch2.Checked;
        }

        private void Switch3_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.StateCH3 = switch3.Checked;
        }

        private void Switch4_Click(object sender, EventArgs e)
        {
            if (AppParam.Instance.lightSource == null)
                return;
            AppParam.Instance.lightSource.StateCH4 = switch4.Checked;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            AppParam.Instance.lightSource.CloseAllCH();
            AppParam.Instance.lightSource.CloseLightSource();
            button_Port.Enabled = true;
            serialPortConfigurationControl1.Enabled = true;
        }
    }
}
