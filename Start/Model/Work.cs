using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;

using HalconDotNet;

using HYProject.Helper;
using HYProject.ToolForm;

using ToolKit.DisplayWindow;

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
            switch (cameraName)
            {
                case "Cam1":
                    DisplayForm.Instance[0].Disp_Image(ho_image);
                    Cam1_Work.Cam1_Work_Method(ho_image);
                    break;

                case "Cam2":
                    DisplayForm.Instance[1].Disp_Image(ho_image);
                    Cam2_Work.Cam2_Work_Method(ho_image);
                    break;

                case "Cam3":
                    DisplayForm.Instance[2].Disp_Image(ho_image);
                    Cam3_Work.Cam3_Work_Method(ho_image);
                    break;
            }
            //QueueSaveImage.Instance.QueueEnqueue2(ho_image);
        }






        public static bool Cam1_Calibration_Mode = false;
        public static int Cam1_Calibration_Index;
        public static int Cam1_Suction_Nozzle_Number;
        public static double Cam1_X;
        public static double Cam1_Y;
        public static double Cam1_U;
        public static void TCPSocketServer_SocketReceiveMessage1(System.Net.Sockets.Socket client, string clientSocketIp, string message)
        {
            Log.WriteRunLog("相机1 [" + clientSocketIp + "] - 接收:" + message);

            //吸嘴旋转标定

            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {
                if (!Cam1_Calibration_Mode)
                {
                    Cam1_Calibration_Mode = true;
                    Log.WriteRunLog("相机1 进入标定模式");
                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam1_Calibration_Index = int.Parse(messageSplit[1]);
                Cam1_Suction_Nozzle_Number = int.Parse(messageSplit[1]);
                Cam1_X = double.Parse(messageSplit[3]);
                Cam1_Y = double.Parse(messageSplit[4]);
                Cam1_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam1"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam1_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam1_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam1_X = double.Parse(messageSplit[3]);
                Cam1_Y = double.Parse(messageSplit[4]);
                Cam1_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam1"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }
        }


        public static bool Cam2_Calibration_Mode = false;
        public static int Cam2_Calibration_Index;
        public static int Cam2_Suction_Nozzle_Number;
        public static double Cam2_X;
        public static double Cam2_Y;
        public static double Cam2_U;
        internal static void TCPSocketServer_SocketReceiveMessage2(Socket client, string clientSocketIp, string message)
        {
            Log.WriteRunLog("相机2 " + clientSocketIp + " - 接收:" + message);
            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {
                if (!Cam2_Calibration_Mode)
                {
                    Cam2_Calibration_Mode = true;
                    Log.WriteRunLog("相机2 进入标定模式");
                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam2_Calibration_Index = int.Parse(messageSplit[1]);
                Cam2_Suction_Nozzle_Number = int.Parse(messageSplit[1]);
                Cam2_X = double.Parse(messageSplit[3]);
                Cam2_Y = double.Parse(messageSplit[4]);
                Cam2_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam2"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam2_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam2_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam2_X = double.Parse(messageSplit[3]);
                Cam2_Y = double.Parse(messageSplit[4]);
                Cam2_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam2"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }
        }

        public static bool Cam3_Calibration_Mode = false;
        public static int Cam3_Calibration_Index;
        public static int Cam3_Suction_Nozzle_Number;
        public static double Cam3_X;
        public static double Cam3_Y;
        public static double Cam3_U;
        internal static void TCPSocketServer_SocketReceiveMessage3(Socket client, string clientSocketIp, string message)
        {
            Log.WriteRunLog("相机3 " + clientSocketIp + " - 接收:" + message);
            //九点标定 + 旋转标定
            if (message.StartsWith("&TAR"))
            {
                if (!Cam3_Calibration_Mode)
                {
                    Cam3_Calibration_Mode = true;
                    Log.WriteRunLog("相机3 进入标定模式");
                }
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam3_Calibration_Index = int.Parse(messageSplit[1]);
                Cam3_Suction_Nozzle_Number = int.Parse(messageSplit[1]);
                Cam3_X = double.Parse(messageSplit[3]);
                Cam3_Y = double.Parse(messageSplit[4]);
                Cam3_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam3"].Soft_Trigger();

            }
            //正常生产
            else if (message.StartsWith("&OBG"))
            {
                Cam3_Calibration_Mode = false;
                message = message.Replace("\\r\\n", "");
                string[] messageSplit = message.Split(',');
                Cam3_Suction_Nozzle_Number = int.Parse(messageSplit[2]);
                Cam3_X = double.Parse(messageSplit[3]);
                Cam3_Y = double.Parse(messageSplit[4]);
                Cam3_U = double.Parse(messageSplit[5]);
                Cameras.Instance["Cam3"].Soft_Trigger();
            }
            //动静态GRR    
            else if (message.StartsWith("&OBG1"))
            {

            }


        }




        /// <summary>
        /// 以中心点旋转Angle角度
        /// </summary>
        /// <param name="origin">中心点</param>
        /// <param name="rePoint">待旋转的点</param>
        /// <param name="angle">旋转角度, 逆时针</param>
        private void PointRotate_CCW(RobotPoint origin, ref RobotPoint rePoint, double angle)
        {
            double x = (rePoint.X - origin.X) * Math.Cos(angle) - (rePoint.Y - origin.Y) * Math.Sin(angle) + origin.X;
            double y = (rePoint.X - origin.X) * Math.Sin(angle) + (rePoint.Y - origin.Y) * Math.Cos(angle) + origin.Y;

            rePoint.X = x;
            rePoint.Y = y;
        }
        /// <summary>
        /// 以中心点旋转Angle角度
        /// </summary>
        /// <param name="origin">中心点</param>
        /// <param name="rePoint">待旋转的点</param>
        /// <param name="angle">旋转角度, 顺时针</param>
        private void PointRotate_CW(RobotPoint origin, ref RobotPoint rePoint, double angle)
        {
            double x = (rePoint.X - origin.X) * Math.Cos(-angle) - (rePoint.Y - origin.Y) * Math.Sin(-angle) + origin.X;
            double y = (rePoint.X - origin.X) * Math.Sin(-angle) + (rePoint.Y - origin.Y) * Math.Cos(-angle) + origin.Y;

            rePoint.X = x;
            rePoint.Y = y;
        }


























































































































































        public static void SaveImage(string Cam, string Suction_nozzle_number, bool result, HalconWindow halconWindow)
        {
            if (AppParam.Instance.IsSaveImage)
            {
                if (result)
                {//OK
                    if (AppParam.Instance.IsSaveImage_BmpImage)
                    {//原图
                        if (AppParam.Instance.IsSaveImage_OK)
                            if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK"))
                            {
                                Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK");
                            }
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\OK\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = halconWindow.Image });
                    }
                }
                if (AppParam.Instance.IsSaveImage_DumpImage)
                {//截图
                    if (AppParam.Instance.IsSaveImage_OK)
                    {
                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK");
                        }
                        HalconDotNet.HObject dump_image;
                        HOperatorSet.GenEmptyObj(out dump_image);
                        dump_image.Dispose();
                        HOperatorSet.DumpWindowImage(out dump_image, halconWindow.HalconWindowHandle);
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\OK\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = dump_image.Clone() });
                        dump_image.Dispose();
                    }
                }
            }
            else
            {//NG
                if (AppParam.Instance.IsSaveImage_BmpImage)
                {//原图
                    if (AppParam.Instance.IsSaveImage_NG)
                    {


                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG");
                        }
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\原图\\NG\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = halconWindow.Image });
                    }
                }
                if (AppParam.Instance.IsSaveImage_DumpImage)
                {//截图
                    if (AppParam.Instance.IsSaveImage_NG)
                    {
                        if (!Directory.Exists(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG"))
                        {
                            Directory.CreateDirectory(AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG");
                        }
                        HalconDotNet.HObject dump_image;
                        HOperatorSet.GenEmptyObj(out dump_image);
                        dump_image.Dispose();
                        HOperatorSet.DumpWindowImage(out dump_image, halconWindow.HalconWindowHandle);
                        QueueSaveImage.Instance.QueueEnqueue(new ImageParam() { SavePath = AppParam.Instance.Save_Image_Path + "\\" + Cam + "\\" + Suction_nozzle_number + "\\截图\\NG\\" + DateTime.Now.ToString("yyyyMMddHHmmssffff"), image = dump_image.Clone() });
                        dump_image.Dispose();
                    }
                }
            }
        }



    }





    internal static void TCPSocketServer_ClientsConnect1(Dictionary<string, Socket> clients)
    {
        foreach (string item in clients.Keys)
        {
            Log.WriteRunLog("相机1 客户端连接: " + clients[item].RemoteEndPoint.ToString());
        }
    }
    internal static void TCPSocketServer_ClientsConnect2(Dictionary<string, Socket> clients)
    {
        foreach (string item in clients.Keys)
        {
            Log.WriteRunLog("相机2 客户端连接: " + clients[item].RemoteEndPoint.ToString());
        }
    }
    public static void TCPSocketServer_ClientsConnect3(Dictionary<string, Socket> clients)
    {
        foreach (string item in clients.Keys)
        {
            Log.WriteRunLog("相机3 客户端连接: " + clients[item].RemoteEndPoint.ToString());
        }
    }
}
}