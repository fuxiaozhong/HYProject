using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ToolKit.CommunicAtion
{
    public class TCP_Socket_Client
    {
        public delegate void _SocketReceiveMessage(string serverSocketIp, string message);

        public event _SocketReceiveMessage SocketReceiveMessage;

        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];
        private bool isOpen;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">连接服务器的IP</param>
        /// <param name="port">连接服务器的端口</param>
        public TCP_Socket_Client(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }

        /// <summary>
        /// 默认本机127.0.0.1
        /// </summary>
        /// <param name="port"></param>
        public TCP_Socket_Client(int port)
        {
            this._ip = "127.0.0.1";
            this._port = port;
        }

        public bool Connect_server()
        {
            try
            {
                //1.0 实例化套接字(IP4寻址地址,流式传输,TCP协议)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                IPAddress address = IPAddress.Parse(_ip);
                //3.0 创建网络端口包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                //4.0 建立连接
                _socket.Connect(endPoint);
                isOpen = true;
                Thread thread = new Thread(ReceiveMessage);
                thread.Name = "ReceiveMessage";
                thread.Start();
                Console.WriteLine("-------------" + new IPEndPoint(address, _port).ToString() + "连接服务器成功-------------");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                isOpen = false;
                return false;
            }

            return true;
        }

        private void ReceiveMessage()
        {
            while (isOpen)
            {
                try
                {
                    int length = _socket.Receive(buffer);
                    Console.WriteLine("接收服务器{0},消息:{1}", _socket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                    if (Encoding.UTF8.GetString(buffer, 0, length).Trim() == "SeverClose")
                    {
                        Console.WriteLine("-------------" + new IPEndPoint(IPAddress.Parse(_ip), _port).ToString() + "服务端掉线-------------");

                        isOpen = false;
                        Task.Factory.StartNew(() =>
                        {
                            int count = 0;
                            while (!Connect_server())
                            {
                                Thread.Sleep(300);
                                count++;
                                Console.WriteLine("-------------" + new IPEndPoint(IPAddress.Parse(_ip), _port).ToString() + "重新连接服务端中:" + count + "-------------");
                                if (count > 30) break;
                            };
                        });
                    }
                    else
                    {
                        SocketReceiveMessage?.Invoke(_socket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        /// <summary>
        /// 开启服务,连接服务端
        /// </summary>
        public void SendMessage(string message)
        {
            if (isOpen)
            {
                _socket.Send(Encoding.UTF8.GetBytes(message));
            }
        }

        public bool Close()
        {
            isOpen = false;
            _socket.Close();
            return !isOpen;
        }
    }
}