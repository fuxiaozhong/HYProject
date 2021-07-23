using System;
using System.IO;
using System.Reflection;

using HalconDotNet;

namespace ToolKit.CamreaSDK
{
    public abstract class ICamera
    {
        /// <summary>
        /// 是否保存日志到本地
        /// </summary>
        public bool IsSaveLog2Disk = false;

        /// <summary>
        /// 相机图像输出声明委托
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="ho_image">图像</param>
        public delegate void ImageProcess(string cameraName, HObject ho_image);

        /// <summary>
        /// 相机日志输出委托
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="message">日志消息</param>
        public delegate void CameraLog(string cameraName, string message);

        /// <summary>
        /// 图像输出事件
        /// </summary>
        public abstract event ImageProcess ImageProcessEvent;

        /// <summary>
        /// 相机输出事件
        /// </summary>
        public abstract event CameraLog CameraLogs;

        /// <summary>
        /// 相机名称
        /// </summary>
        public string _CameraNmae;

        /// <summary>
        /// 当前曝光时间
        /// </summary>
        public double _Exposure_Time;

        /// <summary>
        /// 当前相机增益
        /// </summary>
        public double _Gain;

        /// <summary>
        /// 获取当前曝光时间
        /// </summary>
        /// <returns>曝光值</returns>
        public abstract double Get_Exposure_Time();

        /// <summary>
        /// 获取当前增益
        /// </summary>
        /// <returns>增益值</returns>
        public abstract double Get_Gain();

        /// <summary>
        /// 获取当前模式
        /// </summary>
        /// <returns>On触发模式  Off实时模式</returns>
        public abstract string Get_TriggerMode();

        /// <summary>
        /// 获取当前触发源
        /// </summary>
        /// <returns>Software软触发（指令触发）   其他硬触发</returns>
        public abstract string Get_TriggerSource();

        /// <summary>
        /// 设置曝光时间
        /// </summary>
        /// <param name="value">曝光值</param>
        /// <returns>是否设置成功</returns>
        public abstract bool Set_Exposure_Time(double value);

        /// <summary>
        /// 设置增益值
        /// </summary>
        /// <param name="value">增益值</param>
        /// <returns>是否设置成功</returns>
        public abstract bool Set_Gain(double value);

        /// <summary>
        /// 设置相机模式（On触发模式  Off实时模式）
        /// </summary>
        /// <param name="value">On(触发模式)/Off（实时模式）</param>
        /// <returns>设置是否成功</returns>
        public abstract bool Set_TriggerMode(string value);

        /// <summary>
        /// 设置相机触发源
        /// </summary>
        /// <param name="value">Software软触发（指令触发）   其他硬触发</param>
        /// <returns>设置是否成功</returns>
        public abstract bool Set_TriggerSource(string value);

        /// <summary>
        /// 开始实时模式
        /// </summary>
        /// <returns>是否开启成功</returns>
        public abstract bool Start_Real_Mode();

        /// <summary>
        /// 结束实时模式
        /// </summary>
        /// <returns>是否关闭实时模式成功</returns>
        public abstract bool End_Real_Mode();

        /// <summary>
        /// 设置为硬出发模式，默认触发源Line1
        /// </summary>
        /// <returns></returns>
        public abstract bool Set_Hard_Trigger_Mode();

        /// <summary>
        /// 设置软触发模式 默认：Software软触发（指令触发）
        /// </summary>
        /// <returns></returns>
        public abstract bool Set_Soft_Trigger_Model();

        /// <summary>
        /// 执行软触发命令
        /// </summary>
        /// <returns>是否成功</returns>
        public abstract bool Soft_Trigger();

        /// <summary>
        /// 初始化打开相机
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="configFile">相机配置文件路径</param>
        /// <returns>相机是否打开成功</returns>
        public abstract bool Open(string cameraName, string configFile = "");

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public abstract bool Close();

        public void WriteLog(string message)
        {
            if (IsSaveLog2Disk)
            {
                string filePath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + _CameraNmae;
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);
                }
                string logPath = AppDomain.CurrentDomain.BaseDirectory + "Logs\\" + _CameraNmae + "\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".txt";
                try
                {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.WriteLine("相机：" + _CameraNmae);
                        sw.WriteLine("消息：" + message);
                        sw.WriteLine("时间：" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                        sw.WriteLine("**************************************************");
                        sw.WriteLine();
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
                catch (IOException e)
                {
                    using (StreamWriter sw = File.AppendText(logPath))
                    {
                        sw.WriteLine("相机：" + _CameraNmae);
                        sw.WriteLine("异常：" + e.Message);
                        sw.WriteLine("时间：" + DateTime.Now.ToString("yyy-MM-dd HH:mm:ss"));
                        sw.WriteLine("**************************************************");
                        sw.WriteLine();
                        sw.Flush();
                        sw.Close();
                        sw.Dispose();
                    }
                }
            }
        }
        /// <summary>
        /// 清除事件绑定的函数
        /// </summary>
        /// <param name="objectHasEvents">拥有事件的实例</param>
        /// <param name="eventName">事件名称</param>
        public void ClearImageProcessEvents()
        {
            try
            {
                EventInfo[] events = this.GetType().GetEvents(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                if (events == null || events.Length < 1)
                {
                    return;
                }
                for (int i = 0; i < events.Length; i++)
                {
                    EventInfo ei = events[i];
                    if (ei.Name == "ImageProcessEvent")
                    {
                        FieldInfo fi = ei.DeclaringType.GetField("ImageProcessEvent", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                        if (fi != null)
                        {
                            fi.SetValue(this, null);
                        }
                        break;
                    }
                }
            }
            catch
            {
            }
        }
    }
}