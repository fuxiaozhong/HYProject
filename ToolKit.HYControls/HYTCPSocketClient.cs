using System;
using System.Windows.Forms;

using ToolKit.CommunicAtion;

namespace ToolKit.HYControls
{
    public partial class HYTCPSocketClient : UserControl
    {
        public HYTCPSocketClient()
        {
            InitializeComponent();
        }

        private TCPSocketClient socketClient;

        private void Button1_Click(object sender, EventArgs e)
        {
            socketClient = new TCPSocketClient(textBox1.Text, int.Parse(textBox2.Text));
            socketClient.SocketReceiveMessage += SocketClient_SocketReceiveMessage;
            if (socketClient.Connect_server())
            {
                button2.Enabled = true;
                button3.Enabled = true;
                button1.Enabled = false;
                MessageBox.Show("连接成功");
            }
            else
            {
                MessageBox.Show("连接超时");
            }
        }

        private void SocketClient_SocketReceiveMessage(string serverSocketIp, string message)
        {
            richTextBox2.AppendText("[" + serverSocketIp + "] : " + message + "\n");
            richTextBox2.SelectionStart = richTextBox2.TextLength;
            richTextBox2.ScrollToCaret();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                socketClient.SendMessage(richTextBox1.Text);
            }
            catch (Exception)
            {
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (socketClient == null || socketClient.Close())
            {
                button2.Enabled = false;
                button3.Enabled = false;
                button1.Enabled = true;
                MessageBox.Show("断开成功");
            }
            else
            {
                MessageBox.Show("断开失败");
            }
        }
    }
}