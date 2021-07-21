using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

using Basler.Pylon;

using HalconDotNet;

using static ToolKit.CamreaSDK.ICamera;

namespace ToolKit.CamreaSDK
{
    public class BaslerPylonGigE : ICamera
    {
        public override event ImageProcess ImageProcessEvent;
        public override event CameraLog CameraLogs;

        private Basler.Pylon.Camera camera = null;
        private PixelDataConverter converter = new PixelDataConverter();

        private long minExposureTime;    // 最小曝光时间
        private long maxExposureTime;    // 最大曝光时间
        private long minGain;            // 最小增益
        private long maxGain;            // 最大增益
        private long imageHeight;            // 最大增益
        private long imageWidth;            // 最大增益

        private IntPtr latestFrameAddress = IntPtr.Zero;

        private static System.Version Sfnc2_0_0 = new System.Version(2, 0, 0);
        public override bool Close()
        {

            if (camera.IsOpen)
            {
                camera.Parameters[PLCamera.TriggerMode].SetValue("On");
                camera.StreamGrabber.Stop();
                camera.Close();
                camera.Dispose();
                if (latestFrameAddress != null)
                {
                    Marshal.FreeHGlobal(latestFrameAddress);
                    latestFrameAddress = IntPtr.Zero;
                }
            }
            WriteLog("关闭相机...");
            CameraLogs?.Invoke(_CameraNmae, "关闭相机...");
            return true;
        }

        public override bool End_Real_Mode()
        {
            if (!camera.IsOpen)
                return false;
            if (camera.StreamGrabber.IsGrabbing)
                return Set_TriggerMode("On");
            else
                return false;
        }

        public override double Get_Exposure_Time()
        {
            if (!camera.IsOpen)
                return 0;
            try
            {
                camera.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Off);
                camera.Parameters[PLCamera.ExposureMode].TrySetValue(PLCamera.ExposureMode.Timed);
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                    return camera.Parameters[PLCamera.ExposureTimeRaw].GetValue();
                else
                    return camera.Parameters[PLUsbCamera.ExposureTime].GetValue();
            }
            catch
            {
                return 0;
            }
        }

        public override double Get_Gain()
        {
            if (!camera.IsOpen)
                return 0;
            try
            {
                camera.Parameters[PLCamera.GainAuto].TrySetValue(PLCamera.GainAuto.Off);
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                    return camera.Parameters[PLCamera.GainRaw].GetValue();
                else
                    return camera.Parameters[PLUsbCamera.Gain].GetValue();
            }
            catch
            {
                return 0;
            }
        }

        public override string Get_TriggerMode()
        {
            if (!camera.IsOpen)
                return string.Empty;

            if (camera.GetSfncVersion() < Sfnc2_0_0)
                return camera.Parameters[PLCamera.TriggerMode].GetValue();
            else
                return camera.Parameters[PLUsbCamera.TriggerMode].GetValue();
        }

        public override string Get_TriggerSource()
        {
            if (!camera.IsOpen)
                return string.Empty;
            if (camera.GetSfncVersion() < Sfnc2_0_0)
                return camera.Parameters[PLCamera.TriggerSource].GetValue();
            else
                return camera.Parameters[PLUsbCamera.TriggerSource].GetValue();
        }

        public override bool Open(string cameraName, string configFile = "")
        {
            // 枚举相机列表
            List<ICameraInfo> allCameraInfos = CameraFinder.Enumerate();
            foreach (ICameraInfo cameraInfo in allCameraInfos)
            {
                if (_CameraNmae == cameraInfo[CameraInfoKey.UserDefinedName])
                {
                    camera = new Basler.Pylon.Camera(cameraInfo);
                    break;
                }
            }
            if (camera == null)
            {
                return false;
            }
            camera.Open();
            if (camera.IsOpen)
            {

                imageWidth = camera.Parameters[PLCamera.Width].GetValue();               // 获取图像宽
                imageHeight = camera.Parameters[PLCamera.Height].GetValue();              // 获取图像高
                GetMinMaxExposureTime();
                GetMinMaxGain();
                camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;                      // 注册采集回调函数
                camera.ConnectionLost += OnConnectionLost;
                camera.Parameters[PLCamera.AcquisitionMode].SetValue(PLCamera.AcquisitionMode.Continuous);
                camera.StreamGrabber.Start(GrabStrategy.LatestImages, GrabLoop.ProvidedByStreamGrabber);
            }

            return camera.IsOpen;
        }
        private void SetHeartBeatTime(long value)
        {
            try
            {
                // 判断是否是网口相机
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    camera.Parameters[PLTransportLayer.HeartbeatTimeout].TrySetValue(value, IntegerValueCorrection.Nearest);
                }
            }
            catch
            {
            }
        }

        private void OnConnectionLost(object sender, EventArgs e)
        {
            try
            {
                camera.Close();

                for (int i = 0; i < 100; i++)
                {
                    try
                    {
                        camera.Open();
                        if (camera.IsOpen)
                        {
                            CameraLogs?.Invoke(_CameraNmae, "已重新连接上UserID为“" + _CameraNmae + "”的相机！");
                            break;
                        }
                        Thread.Sleep(200);
                    }
                    catch
                    {
                        CameraLogs?.Invoke(_CameraNmae, "已重新连接上UserID为“" + _CameraNmae + "”的相机！");
                        // MessageBox.Show("请重新连接UserID为“" + _Name + "”的相机！", "提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

                if (camera == null)
                {
                    CameraLogs?.Invoke(_CameraNmae, "重连超时20s:未识别到UserID为“" + _CameraNmae + "”的相机！");
                    MessageBox.Show("重连超时20s:未识别到UserID为“" + _CameraNmae + "”的相机！", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                SetHeartBeatTime(500);

                imageWidth = camera.Parameters[PLCamera.Width].GetValue();               // 获取图像宽
                imageHeight = camera.Parameters[PLCamera.Height].GetValue();              // 获取图像高
                GetMinMaxExposureTime();
                GetMinMaxGain();
                camera.StreamGrabber.ImageGrabbed += OnImageGrabbed;                      // 注册采集回调函数
                camera.ConnectionLost += OnConnectionLost;
            }
            catch (Exception)
            {
            }
        }
        private HObject ho_image = new HObject();
        private void OnImageGrabbed(object sender, ImageGrabbedEventArgs e)
        {
            lock (ho_image)
            {
                HOperatorSet.GenEmptyObj(out ho_image);
                ho_image.Dispose();
                IGrabResult grabResult = e.GrabResult;
                if (grabResult.GrabSucceeded)
                {
                    latestFrameAddress = Marshal.AllocHGlobal((Int32)grabResult.PayloadSize);
                    converter.OutputPixelFormat = PixelType.Mono8;
                    converter.Convert(latestFrameAddress, grabResult.PayloadSize, grabResult);

                    // 转换为Halcon图像显示
                    HOperatorSet.GenImage1(out ho_image, "byte", grabResult.Width, grabResult.Height, latestFrameAddress);

                    // 抛出图像处理事件
                    ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                    ho_image.Dispose();
                    Marshal.FreeHGlobal(latestFrameAddress);
                }
            }
        }
        public void GetMinMaxExposureTime()
        {
            try
            {
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    minExposureTime = camera.Parameters[PLCamera.ExposureTimeRaw].GetMinimum();
                    maxExposureTime = camera.Parameters[PLCamera.ExposureTimeRaw].GetMaximum();
                }
                else
                {
                    minExposureTime = (long)camera.Parameters[PLUsbCamera.ExposureTime].GetMinimum();
                    maxExposureTime = (long)camera.Parameters[PLUsbCamera.ExposureTime].GetMaximum();
                }
            }
            catch
            {
            }
        }

        public void GetMinMaxGain()
        {
            try
            {
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    minGain = camera.Parameters[PLCamera.GainRaw].GetMinimum();
                    maxGain = camera.Parameters[PLCamera.GainRaw].GetMaximum();
                }
                else
                {
                    minGain = (long)camera.Parameters[PLUsbCamera.Gain].GetMinimum();
                    maxGain = (long)camera.Parameters[PLUsbCamera.Gain].GetMaximum();
                }
            }
            catch (Exception)
            {
            }
        }
        public override bool Set_Exposure_Time(double value)
        {
            if (!camera.IsOpen)
                return false;

            try
            {
                camera.Parameters[PLCamera.ExposureAuto].TrySetValue(PLCamera.ExposureAuto.Off); // Set ExposureAuto to Off if it is writable.
                camera.Parameters[PLCamera.ExposureMode].TrySetValue(PLCamera.ExposureMode.Off); // Set ExposureMode to Timed if it is writable.
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    long min = camera.Parameters[PLCamera.ExposureTimeRaw].GetMinimum();
                    long max = camera.Parameters[PLCamera.ExposureTimeRaw].GetMaximum();
                    long incr = camera.Parameters[PLCamera.ExposureTimeRaw].GetIncrement();
                    if (value < min)
                        value = min;
                    else if (value > max)
                        value = max;
                    else
                        value = ((int)(value / incr)) * incr;
                    camera.Parameters[PLCamera.ExposureTimeRaw].SetValue((long)value);
                }
                else // For SFNC 2.0 cameras, e.g. USB3 Vision cameras
                    camera.Parameters[PLUsbCamera.ExposureTime].SetValue(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Set_Gain(double value)
        {
            if (!camera.IsOpen)
                return false;

            try
            {
                camera.Parameters[PLCamera.GainAuto].TrySetValue(PLCamera.GainAuto.Off);

                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    long min = camera.Parameters[PLCamera.GainRaw].GetMinimum();
                    long max = camera.Parameters[PLCamera.GainRaw].GetMaximum();
                    long incr = camera.Parameters[PLCamera.GainRaw].GetIncrement();
                    if (value < min)
                        value = min;
                    else if (value > max)
                        value = max;
                    else
                        value = ((int)(Math.Round(value) / incr)) * incr;
                    camera.Parameters[PLCamera.GainRaw].SetValue((long)value);
                }
                else
                    camera.Parameters[PLUsbCamera.Gain].SetValue(value);
            }
            catch
            {
                return false;
            }
            return true;
        }

        public override bool Set_Hard_Trigger_Mode()
        {
            if (!camera.IsOpen)
                return false;

            return Set_TriggerMode("On") && Set_TriggerSource("Line1");
        }

        public override bool Set_Soft_Trigger_Model()
        {
            if (!camera.IsOpen)
                return false;

            return Set_TriggerMode("On") && Set_TriggerSource("Software");
        }

        public override bool Set_TriggerMode(string value)
        {
            if (!camera.IsOpen)
                return false;

            if (camera.GetSfncVersion() < Sfnc2_0_0)
                camera.Parameters[PLCamera.TriggerMode].SetValue(value);
            else
                camera.Parameters[PLUsbCamera.TriggerMode].SetValue(value);
            return true;
        }

        public override bool Set_TriggerSource(string value)
        {
            if (!camera.IsOpen)
                return false;

            if (value == "Software")
            {
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    camera.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameActive);
                    camera.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                }
                else
                {
                    camera.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameBurstStart);
                    camera.Parameters[PLCamera.TriggerSource].TrySetValue(PLCamera.TriggerSource.Software);
                }
            }
            else
            {
                if (camera.GetSfncVersion() < Sfnc2_0_0)
                {
                    camera.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameActive);
                    camera.Parameters[PLCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line1);
                }
                else
                {
                    camera.Parameters[PLCamera.TriggerSelector].TrySetValue(PLCamera.TriggerSelector.FrameBurstStart);
                    camera.Parameters[PLUsbCamera.TriggerSource].SetValue(PLCamera.TriggerSource.Line1);
                }
            }

            return true;
        }

        public override bool Soft_Trigger()
        {
            if (!camera.IsOpen)
                return false;


            camera.ExecuteSoftwareTrigger();
            return true;
        }

        public override bool Start_Real_Mode()
        {
            if (!camera.IsOpen)
                return false;

            if (camera.StreamGrabber.IsGrabbing)
            {
                Set_TriggerMode("Off");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
