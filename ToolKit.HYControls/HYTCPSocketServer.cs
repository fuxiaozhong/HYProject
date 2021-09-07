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
    public partial class HYTCPSocketServer : UserControl
    {
        public HYTCPSocketServer()
        {
            InitializeComponent();
        }

        private TCPSocketServer socketServer;


        private void Button4_Click_1(object sender, EventArgs e)
        {
            socketServer = new TCPSocketServer(textBox_severIP.Text, int.Parse(textBox_severport.Text));
            socketServer.SocketReceiveMessage += SocketServer_SocketReceiveMessage;
            socketServer.ClientsConnect += this.SocketServer_ClientsConnect;
            if (socketServer.StartListen())
            {
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
        private void SocketServer_ClientsConnect(Dictionary<string, Socket> clients)
        {
            cmb_clientList.DataSource = clients.Keys.ToArray();
            if (clients.Keys.ToArray().Length == 0)
            {
                cmb_clientList.Text = "";
            }
        }

        private void SocketServer_SocketReceiveMessage(Socket client, string clientSocketIp, string message)
        {
            richTextBox_severjs.AppendText("[" + clientSocketIp + "]:" + message + "\n");
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
    }
}
