using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToolKit.CommunicAtion;

namespace ToolKit.HYControls
{
    public partial class TCPSocketControl : UserControl
    {
        private TCPSocketServer socketServer;
        private TCPSocketClient socketClient;
        public TCPSocketControl()
        {
            InitializeComponent();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            socketServer = new TCPSocketServer(textBox_severIP.Text, int.Parse(textBox_severport.Text));
            socketServer.SocketReceiveMessage += SocketServer_SocketReceiveMessage;
            if (socketServer.StartListen())
            {
                timer1.Enabled = true;
                button6.Enabled = true;
                button5.Enabled = true;
                button4.Enabled = false;
                MessageBox.Show("打开成功");
            }
            else
            {
                MessageBox.Show("打开失败");
            }
        }

        private void SocketServer_SocketReceiveMessage(Socket client, string clientSocketIp, string message)
        {
            richTextBox_severjs.AppendText(clientSocketIp + ":" + message + "\n");
            richTextBox_severjs.SelectionStart = richTextBox_severjs.TextLength;
            richTextBox_severjs.ScrollToCaret();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            try
            {
                socketServer.SendMessage(socketServer.clients[cmb_clientList.Text], richTextBox_severSend.Text);
            }
            catch (Exception)
            {
            }

        }

        private void Button6_Click(object sender, EventArgs e)
        {
            if (socketServer != null && socketServer.Close())
            {
                timer1.Enabled = false;
                button6.Enabled = false;
                button5.Enabled = false;
                button4.Enabled = true;
                MessageBox.Show("关闭成功");
            }
            else
            {
                MessageBox.Show("关闭失败");
            }
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            cmb_clientList.DataSource = socketServer.clients.Keys.ToArray();
            if (socketServer.clients.Keys.ToArray().Length == 0)
            {
                cmb_clientList.Text = "";
            }
        }

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
            richTextBox2.AppendText(serverSocketIp + " : " + message + "\n");
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
