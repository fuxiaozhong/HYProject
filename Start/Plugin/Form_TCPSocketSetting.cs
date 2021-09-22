using System;

namespace HYProject.Plugin
{
    public partial class Form_TCPSocketSetting : ToolKit.HYControls.HYForm.HYBaseForm
    {
        public Form_TCPSocketSetting()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            text_Cam1_TCPIP.Text = AppParam.Instance.TCPServerIPAddress_Cam1;
            text_Cam1_TCPport.Text = AppParam.Instance.TCPServerPort_Cam1.ToString();

            text_Cam2_TCPIP.Text = AppParam.Instance.TCPServerIPAddress_Cam2;
            text_Cam2_TCPport.Text = AppParam.Instance.TCPServerPort_Cam2.ToString();

            text_Cam3_TCPIP.Text = AppParam.Instance.TCPServerIPAddress_Cam3;
            text_Cam3_TCPport.Text = AppParam.Instance.TCPServerPort_Cam3.ToString();
        }

        private void HslButton1_Click(object sender, EventArgs e)
        {
            try
            {
                AppParam.Instance.TCPServerIPAddress_Cam1 = text_Cam1_TCPIP.Text;

                AppParam.Instance.TCPServerPort_Cam1 = int.Parse(text_Cam1_TCPport.Text);

                AppParam.Instance.TCPServerIPAddress_Cam2 = text_Cam2_TCPIP.Text;

                AppParam.Instance.TCPServerPort_Cam2 = int.Parse(text_Cam2_TCPport.Text);

                AppParam.Instance.TCPServerIPAddress_Cam3 = text_Cam3_TCPIP.Text;

                AppParam.Instance.TCPServerPort_Cam3 = int.Parse(text_Cam3_TCPport.Text);

                ShowMessage("保存成功");
            }
            catch (Exception ex)
            {
                ShowError(ex.Message);
            }
        }

        private void HslButton2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}