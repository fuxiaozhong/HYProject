using System.Threading;

namespace HYProject
{
    public class RunThread
    {
        private static Thread MonitoringCameraSignal;

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
                    //if (MainForm.Instance.tackTest)
                    //{
                    //
                    //    Log.WriteRunLog("收到D10拍照信号: " + MainForm.Instance.tackTest);
                    //    Log.WriteRunLog("执行拍照命令: " + (Cameras.Instance["Cam1"].Soft_Trigger() ? "成功" : "失败"));
                    //    MainForm.Instance.tackTest = false;
                    //    Log.WriteRunLog("复位D10拍照信号: " + (!MainForm.Instance.tackTest ? "成功" : "失败"));
                    //}

                    //读取第一个拍照信号
                    //OperateResult<int> AoperateResult = AppParam.Instance.Fx3uPLC.ReadInt32("D10");
                    //if (AoperateResult.IsSuccess && AoperateResult.Content == 1)
                    //{
                    //    Log.WriteRunLog("收到D10拍照信号: " + AoperateResult.Content);
                    //    Log.WriteRunLog("执行拍照命令: " + (Cameras.Instance["Cam1"].Soft_Trigger() ? "成功" : "失败"));
                    //    Log.WriteRunLog("复位D10拍照信号: " + (AppParam.Instance.Fx3uPLC.Write("D10", 0).IsSuccess ? "成功" : "失败"));
                    //}

                    ////读取第二个拍照信号
                    //OperateResult<int> BoperateResult = AppParam.Instance.Fx3uPLC.ReadInt32("D20");
                    //if (BoperateResult.IsSuccess && BoperateResult.Content == 1)
                    //{
                    //    Log.WriteRunLog("收到D20拍照信号: " + BoperateResult.Content);
                    //    Log.WriteRunLog("执行拍照命令: " + (Cameras.Instance["Cam2"].Soft_Trigger() ? "成功" : "失败"));
                    //    Log.WriteRunLog("复位D20拍照信号: " + (AppParam.Instance.Fx3uPLC.Write("D20", 0).IsSuccess ? "成功" : "失败"));
                    //}
                }
                Thread.Sleep(10);
            }
        }
    }
}