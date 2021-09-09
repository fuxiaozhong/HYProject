using System;

using HYProject.Helper;
using HYProject.ToolForm;

namespace HYProject.Model
{
    public class Work
    {
        /// <summary>
        /// 相机正常工作方法(数据处理)
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="ho_image">图像</param>
        public static void CameraWork(string cameraName, HalconDotNet.HObject ho_image)
        {
            DisplayForm.Instance[0].Disp_Image(ho_image);
            DisplayForm.Instance[1].Disp_Image(ho_image);
            DisplayForm.Instance[2].Disp_Image(ho_image);
            DisplayForm.Instance[3].Disp_Image(ho_image);
            DisplayForm.Instance[4].Disp_Image(ho_image);
            DisplayForm.Instance[5].Disp_Image(ho_image);
            //QueueSaveImage.Instance.QueueEnqueue2(ho_image);
            //DisplayForm.Instance[1].Disp_Image(ho_image);
        }


        /// <summary>
        /// TCP服务器接收消息事件
        /// </summary>
        /// <param name="client">客服端对象</param>
        /// <param name="clientSocketIp">客户端地址</param>
        /// <param name="message">消息</param>
        public static void TCPSocketServer_SocketReceiveMessage(System.Net.Sockets.Socket client, string clientSocketIp, string message)
        {

        }

        /// <summary>
        /// TCP服务器监听客户端连接事件
        /// </summary>
        /// <param name="clients">连接的客户端</param>
        public static void TCPSocketServer_ClientsConnect(System.Collections.Generic.Dictionary<string, System.Net.Sockets.Socket> clients)
        {

        }
        /// <summary>
        /// TCP客户端接收消息事件
        /// </summary>
        /// <param name="serverSocketIp">服务端IP</param>
        /// <param name="message">消息</param>
        public static void TCPSocketClient_SocketReceiveMessage(string serverSocketIp, string message)
        {

        }
    }
}