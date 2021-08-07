using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using HYProject.Model;

namespace HYProject
{
    public class RunThread
    {
        static Thread MonitoringCameraSignal;

        public static void Start()
        {
            if (MonitoringCameraSignal == null)
            {
                MonitoringCameraSignal = new Thread(CameraSignal);
            }
            MonitoringCameraSignal.Start();

        }

        private static void CameraSignal()
        {
            while (true)
            {
                //是否运行?
                if (AppParam.Instance.Runing)
                {
                    //读取第一个拍照信号
                    int Asignal = AppParam.Instance.Fx3uPLC.ReadInt32("D20").Content;
                    Asignal = 1;
                    if (Asignal == 1)
                    {
                        Log.RunLog("收到D20拍照信号: " + Asignal);
                        Log.RunLog("执行拍照命令: " + (Cameras.Instance["Cam1"].Soft_Trigger() ? "成功" : "失败"));
                        Log.RunLog("复位D20拍照信号: " + (AppParam.Instance.Fx3uPLC.Write("D20", 0).IsSuccess ? "成功" : "失败"));
                    }

                    //读取第二个拍照信号
                    int Bsignal = AppParam.Instance.Fx3uPLC.ReadInt32("D10").Content;
                    if (Bsignal == 1)
                    {
                        Log.RunLog("收到D10拍照信号: " + Asignal);
                        Log.RunLog("执行拍照命令: " + (Cameras.Instance["Cam2"].Soft_Trigger() ? "成功" : "失败"));
                        Log.RunLog("复位D10拍照信号: " + (AppParam.Instance.Fx3uPLC.Write("D10", 0).IsSuccess ? "成功" : "失败"));
                    }
                }
                Thread.Sleep(10);
            }
        }
    }
}
