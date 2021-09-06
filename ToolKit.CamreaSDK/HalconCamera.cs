using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HalconDotNet;

namespace ToolKit.CamreaSDK
{
    public class HalconCamera : ICamera
    {
        public override event ImageProcess ImageProcessEvent;
        public override event CameraLog CameraLogs;

        private HTuple CameraHandle;
        Thread thread;

        public override bool Close()
        {
            HOperatorSet.CloseFramegrabber(CameraHandle);
            CameraHandle.Dispose();
            thread.Abort();
            thread = null;
            CameraLogs?.Invoke(_CameraNmae, "相机关闭成功");
            return true;
        }

        public override bool End_Real_Mode()
        {
            tm.Stop();
            CameraLogs?.Invoke(_CameraNmae, "相机关闭实时模式");
            return true;
        }

        public override double Get_Exposure_Time()
        {
            HTuple Exposure_Time;
            HOperatorSet.GetFramegrabberParam(CameraHandle, "ExposureTime", out Exposure_Time);
            CameraLogs?.Invoke(_CameraNmae, "获取曝光时间:" + Exposure_Time.D);
            return Exposure_Time.D;
        }

        public override double Get_Gain()
        {
            HTuple Gain;
            HOperatorSet.GetFramegrabberParam(CameraHandle, "GainRaw", out Gain);
            CameraLogs?.Invoke(_CameraNmae, "获取增益值:" + Gain.D);
            return Gain.D;
        }

        public override string Get_TriggerMode()
        {
            HTuple mode;
            HOperatorSet.GetFramegrabberParam(CameraHandle, "TriggerMode", out mode);
            CameraLogs?.Invoke(_CameraNmae, "获取触发模式:" + mode.S.ToString());
            return mode.S.ToString();

        }

        public override string Get_TriggerSource()
        {
            HTuple Source;
            HOperatorSet.GetFramegrabberParam(CameraHandle, "TriggerSource", out Source);
            CameraLogs?.Invoke(_CameraNmae, "获取触发源:" + Source.S.ToString());
            return Source.S.ToString();
        }

        public override bool Open(string cameraName, string configFile = "")
        {
            try
            {
                _CameraNmae = cameraName;
                HOperatorSet.OpenFramegrabber("GigEVision2", 0, 0, 0, 0, 0, 0, "progressive", -1, "default", -1, "false", "default", _CameraNmae, 0, -1, out CameraHandle);
                //HOperatorSet.SetFramegrabberParam(CameraHandle, "grab_timeout", -1);
                HOperatorSet.GrabImageStart(CameraHandle, -1);
                HOperatorSet.SetFramegrabberParam(CameraHandle, "grab_timeout", -1);
                HTuple Exposure_Time, Gain;
                HOperatorSet.GetFramegrabberParam(CameraHandle, "ExposureTime", out Exposure_Time);
                HOperatorSet.GetFramegrabberParam(CameraHandle, "GainRaw", out Gain);
                _Exposure_Time = Exposure_Time.D;
                _Gain = Gain.D;
                tm.Interval = 1;
                tm.Tick += new EventHandler(tm_Tick);
                thread = new Thread(GetImage);
                thread.IsBackground = true;
                thread.Start();
                return true;
            }
            catch (Exception)
            {
                HOperatorSet.CloseAllFramegrabbers();
                return false;
            }

        }

        private void tm_Tick(object sender, EventArgs e)
        {
            autoEvent.Set(); //通知阻塞的线程继续执行  
        }

        private System.Windows.Forms.Timer tm = new System.Windows.Forms.Timer();
        AutoResetEvent autoEvent = new AutoResetEvent(false);
        private void GetImage()
        {
            while (true)
            {
                autoEvent.WaitOne();  //阻塞当前线程，等待通知以继续执行  
                HOperatorSet.GenEmptyObj(out ho_Image);
                ho_Image.Dispose();
                //异步图像抓取（out 图像，句柄，默认值-1）
                HOperatorSet.GrabImageAsync(out ho_Image, CameraHandle, -1);
                ImageProcessEvent?.Invoke(_CameraNmae, ho_Image.Clone());
                ho_Image.Dispose();
                ho_Image = null;
            }
        }

        public override bool Set_Exposure_Time(double value)
        {
            HOperatorSet.SetFramegrabberParam(CameraHandle, "ExposureTime", value);
            _Exposure_Time = value;
            return true;
        }

        public override bool Set_Gain(double value)
        {
            HOperatorSet.SetFramegrabberParam(CameraHandle, "GainRaw", value);
            _Gain = value;
            return true;
        }

        public override bool Set_Hard_Trigger_Mode()
        {
            return Set_TriggerMode("On") && Set_TriggerSource("Line1");
        }

        public override bool Set_Soft_Trigger_Model()
        {
            return Set_TriggerMode("On") && Set_TriggerSource("Software");
        }

        public override bool Set_TriggerMode(string value)
        {
            HOperatorSet.SetFramegrabberParam(CameraHandle, "TriggerMode", value);
            return true;
        }

        public override bool Set_TriggerSource(string value)
        {
            HOperatorSet.SetFramegrabberParam(CameraHandle, "TriggerSource", value);
            return true;
        }
        HObject ho_Image;
        public override bool Soft_Trigger()
        {
            autoEvent.Set();
            return true;
        }

        public override bool Start_Real_Mode()
        {
            tm.Start();
            return true;
        }


    }
}
