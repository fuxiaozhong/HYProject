using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace ToolKit.CommunicAtion
{
    public class TCP_Socket_Server
    {
        public delegate void _SocketReceiveMessage(Socket client, string clientSocketIp, string message);

        public event _SocketReceiveMessage SocketReceiveMessage;

        private string _ip = string.Empty;
        private int _port = 0;
        private Socket _socket = null;
        private byte[] buffer = new byte[1024 * 1024 * 2];
        public Dictionary<string, Socket> clients = new Dictionary<string, Socket>();
        private bool isOpen;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="ip">监听的IP</param>
        /// <param name="port">监听的端口</param>
        public TCP_Socket_Server(string ip, int port)
        {
            this._ip = ip;
            this._port = port;
        }

        /// <summary>
        /// 默认本机 127.0.0.1
        /// </summary>
        /// <param name="port"></param>
        public TCP_Socket_Server(int port)
        {
            this._ip = "127.0.0.1";
            this._port = port;
        }

        public bool StartListen()
        {
            try
            {
                //1.0 实例化套接字(IP4寻找协议,流式协议,TCP协议)
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                //2.0 创建IP对象
                IPAddress address = IPAddress.Parse(_ip);
                //3.0 创建网络端口,包括ip和端口
                IPEndPoint endPoint = new IPEndPoint(address, _port);
                //4.0 绑定套接字
                _socket.Bind(endPoint);
                //5.0 设置最大连接数
                _socket.Listen(int.MaxValue);
                Console.WriteLine("服务端监听{0}消息成功", _socket.LocalEndPoint.ToString());
                isOpen = true;
                //6.0 开始监听
                Thread thread = new Thread(ListenClientConnect);
                thread.Name = "ListenClientConnect";
                thread.Start();
                Thread thread2 = new Thread(ListenClientState);
                thread2.Name = "ListenClientState";
                thread2.Start();
            }
            catch (Exception)
            {
                Console.WriteLine("{0} 端口只能打开一次", new IPEndPoint(IPAddress.Parse(_ip), _port).ToString());
            }

            return isOpen;
        }

        private void ListenClientState()
        {
            while (isOpen)
            {
                for (int i = 0; i < clients.Count; i++)
                {
                    try
                    {
                        if (clients[(clients.Keys.ToArray()[i])].Poll(1000, SelectMode.SelectRead))
                        {
                            Console.WriteLine("客户端{0}已掉线,删除成功", (clients.Keys.ToArray()[i]));
                            clients.Remove((clients.Keys.ToArray()[i]));
                        }
                    }
                    catch (Exception)
                    {
                        clients.Remove((clients.Keys.ToArray()[i]));
                    }
                }

                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 监听客户端连接
        /// </summary>
        private void ListenClientConnect()
        {
            while (isOpen)
            {
                try
                {
                    //Socket创建的新连接
                    Socket clientSocket = _socket.Accept();

                    clients.Add(clientSocket.RemoteEndPoint.ToString(), clientSocket);
                    Console.WriteLine("客户端{0}连接成功", clientSocket.RemoteEndPoint.ToString());
                    Thread thread = new Thread(ReceiveMessage);
                    thread.Name = "ReceiveMessage";
                    thread.Start(clientSocket);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// 接收客户端消息
        /// </summary>
        /// <param name="socket">来自客户端的socket</param>
        private void ReceiveMessage(object socket)
        {
            Socket clientSocket = (Socket)socket;
            while (isOpen)
            {
                try
                {
                    //获取从客户端发来的数据
                    int length = clientSocket.Receive(buffer);
                    if (length > 0)
                    {
                        Console.WriteLine("接收客户端{0},消息:{1}", clientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                        SocketReceiveMessage?.Invoke(clientSocket, clientSocket.RemoteEndPoint.ToString(), Encoding.UTF8.GetString(buffer, 0, length));
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }
            }
        }

        public void SendMessage(Socket clientSocket, string message)
        {
            try
            {
                if (!clientSocket.Poll(1000, SelectMode.SelectRead))
                {
                    clientSocket.Send(Encoding.UTF8.GetBytes(message));
                }
            }
            catch (Exception)
            {
            }
        }

        public bool Close()
        {
            foreach (Socket item in clients.Values)
            {
                SendMessage(item, "SeverClose");
            }

            isOpen = false;
            clients.Clear();
            _socket.Close();
            return !isOpen;
        }
    }
}