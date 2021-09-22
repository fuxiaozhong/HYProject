using System;
using System.Collections.Generic;

using HalconDotNet;

using ThridLibray;

namespace ToolKit.CamreaSDK
{
    public class DaHuaCamera : ICamera
    {
        public override event ImageProcess ImageProcessEvent;

        public override event CameraLog CameraLogs;

        private IDevice m_dev;

        /// <summary>
        /// 是否是彩色
        /// </summary>
        public bool _IsColor;

        public override bool Close()
        {
            if (m_dev != null)
            {
                WriteLog("相机关闭");
                CameraLogs?.Invoke(_CameraNmae, "相机关闭");
                return m_dev.Close();
            }
            return true;
        }

        public override bool End_Real_Mode()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;

            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
            {
                WriteLog("相机关闭实时模式");
                CameraLogs?.Invoke(_CameraNmae, "相机关闭实时模式");
                return p.SetValue(TriggerModeEnum.On);
            }
        }

        public override double Get_Exposure_Time()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return 0;
            using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
            {
                _Exposure_Time = p.GetValue();
                WriteLog("相机获取曝光时间:" + _Exposure_Time);
                CameraLogs?.Invoke(_CameraNmae, "相机获取曝光时间:" + _Exposure_Time);
                return _Exposure_Time;
            }
        }

        public override double Get_Gain()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return 0.0;
            using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.GainRaw])
            {
                _Gain = p.GetValue();
                WriteLog("相机获取增益:" + _Gain);
                CameraLogs?.Invoke(_CameraNmae, "相机获取增益:" + _Gain);
                return _Gain;
            }
        }

        public override string Get_TriggerMode()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return string.Empty;
            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
            {
                WriteLog("相机获取相机模式:" + p.GetValue());
                CameraLogs?.Invoke(_CameraNmae, "相机获取相机模式:" + p.GetValue());
                return p.GetValue();
            }
        }

        public override string Get_TriggerSource()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return string.Empty;
            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSource])
            {
                WriteLog("相机获取相机触发源:" + p.GetValue());
                CameraLogs?.Invoke(_CameraNmae, "相机获取相机触发源:" + p.GetValue());
                return p.GetValue();
            }
        }

        public override bool Open(string cameraName, string configFile = "")
        {
            _CameraNmae = cameraName;
            List<IDeviceInfo> li = Enumerator.EnumerateDevices();
            WriteLog("相机初始化,开始遍历相机,遍历到:" + li.Count + "个相机");
            CameraLogs?.Invoke(_CameraNmae, "相机初始化,开始遍历相机,遍历到:" + li.Count + "个相机");
            for (int i = 0; i < li.Count; i++)
            {
                if (li[i].Name.Trim() == _CameraNmae.Trim())
                {
                    m_dev = Enumerator.GetDeviceByIndex(i);
                    if (m_dev.Open())
                    {
                        WriteLog("相机初始化,打开成功");
                        CameraLogs?.Invoke(_CameraNmae, "相机初始化,打开成功");
                        IStringParameter pa = m_dev.ParameterCollection[new StringName("DeviceModelName")];
                        if (pa.GetValue().Contains("C"))
                        {
                            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                            {
                                p.SetValue("BayerRG8");
                                _IsColor = true;
                            }
                        }
                        else
                        {
                            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ImagePixelFormat])
                            {
                                p.SetValue("Mono8");
                                _IsColor = false;
                            }
                        }
                        //读取配置文件
                        if (configFile != "")
                        {
                            WriteLog("相机初始化,加载配置文件");
                            CameraLogs?.Invoke(_CameraNmae, "相机初始化,加载配置文件");
                            List<string> oErrPropertyList = new List<string>();
                            m_dev.LoadDeviceCfg(configFile, ref oErrPropertyList);
                        }

                        m_dev.StreamGrabber.SetBufferCount(8);
                        m_dev.StreamGrabber.ImageGrabbed += OnImageGrabbed;//注册采集回调函数
                        m_dev.ConnectionLost += M_dev_ConnectionLost;
                        m_dev.TriggerSet.Open(TriggerSourceEnum.Software);
                        WriteLog("相机初始化成功");
                        CameraLogs?.Invoke(_CameraNmae, "相机初始化成功");
                        m_dev.GrabUsingGrabLoopThread();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }

            return false;
        }

        private void M_dev_ConnectionLost(object sender, EventArgs e)
        {
            //System.Windows.Forms.MessageBox.Show(_CameraNmae+"掉线");
        }

        private void OnImageGrabbed(object sender, GrabbedEventArgs e)
        {
            if (_IsColor)
            {
                int nRGB = RGBFactory.EncodeLen(e.GrabResult.Width, e.GrabResult.Height, true);
                IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(nRGB);
                RGBFactory.ToRGB(e.GrabResult.Image, e.GrabResult.Width, e.GrabResult.Height, true, e.GrabResult.PixelFmt, pData, nRGB);
                HObject ho_image;
                HOperatorSet.GenImageInterleaved(out ho_image, (HTuple)pData, "bgr", e.GrabResult.Width, e.GrabResult.Height, 0, "byte",
                e.GrabResult.Width, e.GrabResult.Height, 0, 0, 8, 0);
                ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                ho_image.Dispose();
                //GC.Collect();
            }
            else
            {
                int nRGB = RGBFactory.EncodeLen(e.GrabResult.Width, e.GrabResult.Height, false);
                IntPtr pData = System.Runtime.InteropServices.Marshal.AllocHGlobal(nRGB);
                System.Runtime.InteropServices.Marshal.Copy(e.GrabResult.Image, 0, pData, e.GrabResult.ImageSize);
                HObject ho_image;
                HOperatorSet.GenEmptyObj(out ho_image);
                HOperatorSet.GenImage1Extern(out ho_image, "byte", e.GrabResult.Width, e.GrabResult.Height, pData, 0);
                ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                System.Runtime.InteropServices.Marshal.FreeHGlobal(pData);
                ho_image.Dispose();
                //GC.Collect();
            }
        }

        public override bool Set_Exposure_Time(double value)
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.ExposureTime])
            {
                _Exposure_Time = value;
                WriteLog("设置相机曝光时间:" + _Exposure_Time);
                CameraLogs?.Invoke(_CameraNmae, "设置相机曝光时间:" + _Exposure_Time);
                return p.SetValue(value);
            }
        }

        public override bool Set_Gain(double value)
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            using (IFloatParameter p = m_dev.ParameterCollection[ParametrizeNameSet.GainRaw])
            {
                _Gain = value;
                WriteLog("设置相机增益:" + _Gain);
                CameraLogs?.Invoke(_CameraNmae, "设置相机增益:" + _Gain);
                return p.SetValue(value);
            }
        }

        public override bool Set_Hard_Trigger_Mode()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            WriteLog("设置相机默认硬触发模式:On , 触发源:Line1");
            CameraLogs?.Invoke(_CameraNmae, "设置相机默认硬触发模式:On , 触发源:Line1");
            return Set_TriggerMode("On") && Set_TriggerSource("Line1");
        }

        public override bool Set_Soft_Trigger_Model()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            WriteLog("设置相机默认软触发模式:On , 触发源:Software");
            CameraLogs?.Invoke(_CameraNmae, "设置相机默认软触发模式:On , 触发源:Software");
            return Set_TriggerMode("On") && Set_TriggerSource("Software");
        }

        public override bool Set_TriggerMode(string value)
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            if (value != "On" && value != "Off")
            {
                WriteLog("设置相机默认触发模式关键字错误:" + value);
                CameraLogs?.Invoke(_CameraNmae, "设置相机默认触发模式关键字错误:" + value);
                return false;
            }
            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
            {
                try
                {
                    WriteLog("设置相机默认触发模式:" + value);
                    CameraLogs?.Invoke(_CameraNmae, "设置相机默认触发模式:" + value);
                    return p.SetValue(value);
                }
                catch (Exception ee)
                {
                    WriteLog("设置相机触发源错误:" + ee.Message);
                    CameraLogs?.Invoke(_CameraNmae, "设置相机触发源错误:" + ee.Message);
                    return false;
                }
            }
        }

        public override bool Set_TriggerSource(string value)
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            if (value != "Software" && value != "Line1" && value != "Line2" && value != "Line3" && value != "Line4" && value != "Line5" && value != "Line6")
            {
                WriteLog("设置相机默认触发源关键字错误:" + value);
                CameraLogs?.Invoke(_CameraNmae, "设置相机默认触发源关键字错误:" + value);
                return false;
            }

            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerSource])
            {
                try
                {
                    WriteLog("设置相机默认触发模式:" + value);
                    CameraLogs?.Invoke(_CameraNmae, "设置相机默认触发模式:" + value);
                    return p.SetValue(value);
                }
                catch (Exception ex)
                {
                    WriteLog("设置相机默认触发模式异常:" + ex.Message);
                    CameraLogs?.Invoke(_CameraNmae, "设置相机默认触发模式异常: " + ex.Message);
                    return false;
                }
            }
        }

        public override bool Soft_Trigger()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            if (Get_TriggerMode() == "Off")
            {
                WriteLog("当前为实时模式,无法执行软触发指令");
                CameraLogs?.Invoke(_CameraNmae, "当前为实时模式,无法执行软触发指令");
                return false;
            }
            else
            {
                if (Get_TriggerSource() == "Software")
                {
                    WriteLog("相机执行软触发命令");
                    CameraLogs?.Invoke(_CameraNmae, "相机执行软触发命令 ");
                    return m_dev.ExecuteSoftwareTrigger();
                }
                else
                {
                    WriteLog("当前为硬触发模式,无法执行软触发指令");
                    CameraLogs?.Invoke(_CameraNmae, "当前为硬触发模式,无法执行软触发指令");
                    return false;
                }
            }
        }

        public override bool Start_Real_Mode()
        {
            if (m_dev == null || m_dev.IsOpen == false)
                return false;
            using (IEnumParameter p = m_dev.ParameterCollection[ParametrizeNameSet.TriggerMode])
            {
                WriteLog("关闭相机实时模式");
                CameraLogs?.Invoke(_CameraNmae, "关闭相机实时模式");
                return p.SetValue(TriggerModeEnum.Off);
            }
        }
    }
}