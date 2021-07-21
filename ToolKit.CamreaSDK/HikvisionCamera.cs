using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;

using HalconDotNet;

using MvCamCtrl.NET;

using static ToolKit.CamreaSDK.ICamera;

namespace ToolKit.CamreaSDK
{
    public class HikvisionCamera : ICamera
    {
        private MyCamera myCamera;//相机对象
        private Thread work;
        private MyCamera.MV_CC_DEVICE_INFO deviceInfo;//设备对象

        //为读取、保存图像创建的数组
        private UInt32 m_nBufSizeForDriver = 4096 * 3000;
        private MyCamera.MVCC_INTVALUE stParam;//用于接收特定的参数
        private byte[] m_pBufForDriver = new byte[4096 * 3000];


        public override event ImageProcess ImageProcessEvent;
        public override event CameraLog CameraLogs;

        public override bool Close()
        {
            CameraLogs?.Invoke(_CameraNmae, "关闭相机中...");
            WriteLog("关闭相机中...");
            int temp = Convert.ToInt32(!End_Real_Mode());//停止相机采集
            if (MyCamera.MV_OK != temp)
                return false;
            temp = myCamera.MV_CC_StopGrabbing_NET();
            if (MyCamera.MV_OK != temp)
                return false;
            temp = myCamera.MV_CC_CloseDevice_NET();
            if (MyCamera.MV_OK != temp)
                return false;
            temp = myCamera.MV_CC_DestroyDevice_NET();
            if (MyCamera.MV_OK != temp)
                return false;
            CameraLogs?.Invoke(_CameraNmae, "关闭相机成功...");
            WriteLog("关闭相机成功...");
            return true;
        }

        public override bool End_Real_Mode()
        {
            CameraLogs?.Invoke(_CameraNmae, "关闭实时模式...");
            WriteLog("关闭实时模式...");
            Set_TriggerMode("On");
            return true;
        }

        public override double Get_Exposure_Time()
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = myCamera.MV_CC_GetFloatValue_NET("ExposureTime", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                CameraLogs?.Invoke(_CameraNmae, "获取曝光时间:" + stParam.fCurValue);
                WriteLog("获取曝光时间:" + stParam.fCurValue);
                return stParam.fCurValue;
            }
            return 0;
        }

        public override double Get_Gain()
        {
            MyCamera.MVCC_FLOATVALUE stParam = new MyCamera.MVCC_FLOATVALUE();
            int nRet = myCamera.MV_CC_GetFloatValue_NET("Gain", ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                CameraLogs?.Invoke(_CameraNmae, "获取增益值:" + stParam.fCurValue);
                WriteLog("获取增益值:" + stParam.fCurValue);
                return stParam.fCurValue;
            }
            return 0;
        }

        public override string Get_TriggerMode()
        {
            MyCamera.MVCC_ENUMVALUE stParam = new MyCamera.MVCC_ENUMVALUE();
            int nRet = myCamera.MV_CC_GetTriggerMode_NET(ref stParam);

            if (MyCamera.MV_OK == nRet)
            {
                if (stParam.nCurValue == 0)
                {
                    CameraLogs?.Invoke(_CameraNmae, "获取相机模式:Off");
                    WriteLog("获取相机模式:Off");
                    return "Off";
                }
                else
                {
                    CameraLogs?.Invoke(_CameraNmae, "获取相机模式:On");
                    WriteLog("获取相机模式:On");
                    return "On";
                }
            }
            return "On";
        }

        public override string Get_TriggerSource()
        {
            MyCamera.MVCC_ENUMVALUE stParam = new MyCamera.MVCC_ENUMVALUE();

            int nRet = myCamera.MV_CC_GetTriggerSource_NET(ref stParam);
            if (MyCamera.MV_OK == nRet)
            {
                ;

                CameraLogs?.Invoke(this._CameraNmae, "获取相机触发源:" + Enum.Parse(typeof(MyCamera.MV_CAM_TRIGGER_SOURCE), stParam.nCurValue.ToString()));
                WriteLog("获取相机触发源:" + Enum.Parse(typeof(MyCamera.MV_CAM_TRIGGER_SOURCE), stParam.nCurValue.ToString()));
                //MV_TRIGGER_SOURCE_LINE0 = 0,
                //MV_TRIGGER_SOURCE_LINE1 = 1,
                //MV_TRIGGER_SOURCE_LINE2 = 2,
                //MV_TRIGGER_SOURCE_LINE3 = 3,
                //MV_TRIGGER_SOURCE_COUNTER0 = 4,
                //MV_TRIGGER_SOURCE_SOFTWARE = 7,
                //MV_TRIGGER_SOURCE_FrequencyConverter = 8

                if (stParam.nCurValue == 0)
                {
                    return "Line0";
                }
                else if (stParam.nCurValue == 1)
                {
                    return "Line1";
                }
                else if (stParam.nCurValue == 2)
                {
                    return "Line2";
                }
                else if (stParam.nCurValue == 3)
                {
                    return "Line3";
                }
                else if (stParam.nCurValue == 7)
                {
                    return "Software";
                }
            }
            return "Software";
        }

        public override bool Open(string cameraName, string configFile = "")
        {
            _CameraNmae = cameraName;
            CameraLogs?.Invoke(_CameraNmae, "相机初始化中...");
            WriteLog("相机初始化中...");
            bool flag = this.ConnectCamera(_CameraNmae) == 0;
            if (flag && configFile != "")
            {
                CameraLogs?.Invoke(_CameraNmae, "相机初始化加载配置文件中...");
                WriteLog("相机初始化加载配置文件中...");
                //加载配置文件
                myCamera.MV_CC_FeatureLoad_NET(configFile);
            }
            if (work == null && flag)
            {

                myCamera.MV_CC_StartGrabbing_NET();
                work = new Thread(ReceiveThreadProcess);
                work.Start();
            }
            if (flag)
            {
                CameraLogs?.Invoke(_CameraNmae, "相机打开成功...");
                WriteLog("相机打开成功...");
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "相机打开失败...");
                WriteLog("相机打开失败...");
            }
            return flag;


        }
        private bool IsMonoData(MyCamera.MvGvspPixelType enGvspPixelType)
        {
            switch (enGvspPixelType)
            {
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono8:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono10_Packed:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12:
                case MyCamera.MvGvspPixelType.PixelType_Gvsp_Mono12_Packed:
                    return true;

                default:
                    return false;
            }
        }
        private void ReceiveThreadProcess()
        {
            while (true)
            {
                UInt32 nPayloadSize = 0;
                int temp = myCamera.MV_CC_GetIntValue_NET("PayloadSize", ref stParam);
                if (MyCamera.MV_OK != temp)
                {
                    Thread.Sleep(10);
                    continue;
                }
                nPayloadSize = stParam.nCurValue;
                if (nPayloadSize > m_nBufSizeForDriver)
                {
                    m_nBufSizeForDriver = nPayloadSize;
                    m_pBufForDriver = new byte[m_nBufSizeForDriver];
                }
                IntPtr pData = Marshal.UnsafeAddrOfPinnedArrayElement(m_pBufForDriver, 0);
                MyCamera.MV_FRAME_OUT_INFO_EX stFrameInfo = new MyCamera.MV_FRAME_OUT_INFO_EX();
                temp = myCamera.MV_CC_GetOneFrameTimeout_NET(pData, m_nBufSizeForDriver, ref stFrameInfo, 1000);//获取一帧图像，超时时间设置为1000
                if (MyCamera.MV_OK != temp)
                {
                    Thread.Sleep(10);
                    continue;
                }
                HObject ho_image = new HObject();
                HOperatorSet.GenEmptyObj(out ho_image);
                ho_image.Dispose();
                if (IsMonoData(stFrameInfo.enPixelType))//判断是否为黑白图像
                {
                    //如果是黑白图像，则利用Halcon图像库中的GenImage1算子来构建图像
                    HOperatorSet.GenImage1(out ho_image, "byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, pData);
                    ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                    //image.GenImage1("byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, pData);
                }
                else
                {
                    if (stFrameInfo.enPixelType == MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed)
                    {
                        //如果彩色图像是RGB8格式，则可以直接利用GenImageInterleaved算子来构建图像

                        HOperatorSet.GenImageInterleaved(out ho_image, pData, "rgb", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, "byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, 0, -1, 0);
                        //image.GenImageInterleaved(pData, "rgb", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, "byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, 0, -1, 0);
                        ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                        Marshal.FreeHGlobal(pData);
                    }
                    else
                    {
                        //如果彩色图像不是RGB8格式，则需要将图像格式转换为RGB8。
                        IntPtr pBufForSaveImage = IntPtr.Zero;
                        if (pBufForSaveImage == IntPtr.Zero)
                        {
                            pBufForSaveImage = Marshal.AllocHGlobal((int)(stFrameInfo.nWidth * stFrameInfo.nHeight * 3 + 2048));
                        }
                        MyCamera.MV_PIXEL_CONVERT_PARAM stConverPixelParam = new MyCamera.MV_PIXEL_CONVERT_PARAM();
                        stConverPixelParam.nWidth = stFrameInfo.nWidth;
                        stConverPixelParam.nHeight = stFrameInfo.nHeight;
                        stConverPixelParam.pSrcData = pData;
                        stConverPixelParam.nSrcDataLen = stFrameInfo.nFrameLen;
                        stConverPixelParam.enSrcPixelType = stFrameInfo.enPixelType;
                        stConverPixelParam.enDstPixelType = MyCamera.MvGvspPixelType.PixelType_Gvsp_RGB8_Packed;//在此处选择需要转换的目标类型
                        stConverPixelParam.pDstBuffer = pBufForSaveImage;
                        stConverPixelParam.nDstBufferSize = (uint)(stFrameInfo.nWidth * stFrameInfo.nHeight * 3 + 2048);
                        myCamera.MV_CC_ConvertPixelType_NET(ref stConverPixelParam);
                        HOperatorSet.GenImageInterleaved(out ho_image, pBufForSaveImage, "rgb", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, "byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, 0, -1, 0);
                        //image.GenImageInterleaved(pBufForSaveImage, "rgb", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, "byte", (int)stFrameInfo.nWidth, (int)stFrameInfo.nHeight, 0, 0, -1, 0);

                        ImageProcessEvent?.Invoke(_CameraNmae, ho_image.Clone());
                        //Marshal.FreeHGlobal(pData);
                        //释放指针
                        Marshal.FreeHGlobal(pBufForSaveImage);
                    }
                }
                ho_image.Dispose();
                Thread.Sleep(10);
            }
        }

        private int ConnectCamera(string name)//连接相机，返回-1为失败，0为成功
        {
            string m_SerialNumber = "";//接收设备返回的序列号
            int temp;//接收命令执行结果
            myCamera = new MyCamera();
            try
            {
                MyCamera.MV_CC_DEVICE_INFO_LIST deviceList = new MyCamera.MV_CC_DEVICE_INFO_LIST(); //设备列表
                temp = MyCamera.MV_CC_EnumDevices_NET(MyCamera.MV_GIGE_DEVICE | MyCamera.MV_USB_DEVICE, ref deviceList);//更新设备列表
                if (temp != 0)
                {
                    //设备更新成功接收命令的返回值为0，返回值不为0则为异常
                    return -1;
                }
                for (int i = 0; i < deviceList.nDeviceNum; i++)
                {
                    deviceInfo = (MyCamera.MV_CC_DEVICE_INFO)Marshal.PtrToStructure(deviceList.pDeviceInfo[i], typeof(MyCamera.MV_CC_DEVICE_INFO));//获取设备
                    if (deviceInfo.nTLayerType == MyCamera.MV_GIGE_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(deviceInfo.SpecialInfo.stGigEInfo, 0);
                        MyCamera.MV_GIGE_DEVICE_INFO gigeInfo = (MyCamera.MV_GIGE_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_GIGE_DEVICE_INFO));
                        //m_SerialNumber = gigeInfo.chSerialNumber;//获取序列号
                        m_SerialNumber = gigeInfo.chUserDefinedName;//获取用户名
                    }
                    else if (deviceInfo.nTLayerType == MyCamera.MV_USB_DEVICE)
                    {
                        IntPtr buffer = Marshal.UnsafeAddrOfPinnedArrayElement(deviceInfo.SpecialInfo.stUsb3VInfo, 0);
                        MyCamera.MV_USB3_DEVICE_INFO usbInfo = (MyCamera.MV_USB3_DEVICE_INFO)Marshal.PtrToStructure(buffer, typeof(MyCamera.MV_USB3_DEVICE_INFO));
                        m_SerialNumber = usbInfo.chUserDefinedName;
                    }
                    if (name.Equals(m_SerialNumber))
                    {
                        temp = myCamera.MV_CC_CreateDevice_NET(ref deviceInfo);
                        if (MyCamera.MV_OK != temp)
                        {
                            //创建相机失败
                            return -1;
                        }
                        temp = myCamera.MV_CC_OpenDevice_NET();//
                        if (MyCamera.MV_OK != temp)
                        {
                            //打开相机失败
                            return -1;
                        }
                        else
                        {
                            int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                            if (nRet != MyCamera.MV_OK)
                            {
                                return -1;
                            }
                            nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                            if (nRet != MyCamera.MV_OK)
                            {
                                return -1;
                            }
                        }
                        return 0;
                    }
                    continue;
                }
            }
            catch
            {
                return -1;
            }
            return -1;
        }

        public override bool Set_Exposure_Time(double value)
        {

            myCamera.MV_CC_SetEnumValue_NET("ExposureAuto", 0);
            int nRet = myCamera.MV_CC_SetFloatValue_NET("ExposureTime", (float)value);
            if (nRet != MyCamera.MV_OK)
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机曝光时间失败:" + value);
                WriteLog("设置相机曝光时间失败:" + value);
                return false;
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机曝光时间成功:" + value);
                WriteLog("设置相机曝光时间成功:" + value);
                _Exposure_Time = value;
            }
            return true;
        }

        public override bool Set_Gain(double value)
        {
            myCamera.MV_CC_SetEnumValue_NET("GainAuto", 0);
            int nRet = myCamera.MV_CC_SetFloatValue_NET("Gain", (float)value);
            if (nRet != MyCamera.MV_OK)
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机增益失败:" + value);
                WriteLog("设置相机增益失败:" + value);
                return false;
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机增益成功:" + value);
                WriteLog("设置相机增益成功:" + value);
                _Gain = value;
            }

            return true;
        }

        public override bool Set_Hard_Trigger_Mode()
        {
            CameraLogs?.Invoke(_CameraNmae, "设置默认硬触发模式:On 触发源:Line1");
            WriteLog("设置默认硬触发模式:On 触发源:Line1");
            return Set_TriggerMode("On") && Set_TriggerSource("Line1");
        }

        public override bool Set_Soft_Trigger_Model()
        {
            CameraLogs?.Invoke(_CameraNmae, "设置默认软触发模式:On 触发源:Software");
            WriteLog("设置默认软触发模式:On 触发源:Software");
            return Set_TriggerMode("On") && Set_TriggerSource("Software");
        }

        public override bool Set_TriggerMode(string value)
        {
            if (value == "Off")
            {
                int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_OFF);
                if (nRet != MyCamera.MV_OK)
                {
                    return false;
                }
                CameraLogs?.Invoke(_CameraNmae, "设置相机模式:" + value);
                WriteLog("设置相机模式:" + value);
            }
            else
            {
                int nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerMode", (uint)MyCamera.MV_CAM_TRIGGER_MODE.MV_TRIGGER_MODE_ON);
                if (nRet != MyCamera.MV_OK)
                {
                    return false;
                }
                CameraLogs?.Invoke(_CameraNmae, "设置相机模式:" + value);
                WriteLog("设置相机模式:" + value);
            }
            return true;
        }

        public override bool Set_TriggerSource(string value)
        {
            int nRet = -1;
            switch (value)
            {
                case "Software":

                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                    break;

                case "Line0":
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE0);
                    break;

                case "Line1":
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE1);
                    break;

                case "Line2":
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE2);
                    break;

                case "Line3":
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_LINE3);
                    break;

                default:
                    nRet = myCamera.MV_CC_SetEnumValue_NET("TriggerSource", (uint)MyCamera.MV_CAM_TRIGGER_SOURCE.MV_TRIGGER_SOURCE_SOFTWARE);
                    break;
            }

            if (nRet != MyCamera.MV_OK)
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机触发源失败:" + value);
                WriteLog("设置相机触发源失败:" + value);
                return false;
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "设置相机触发源成功:" + value);
                WriteLog("设置相机触发源成功:" + value);
            }

            return true;
        }

        public override bool Soft_Trigger()
        {

            int nRet = myCamera.MV_CC_SetCommandValue_NET("TriggerSoftware");
            if (MyCamera.MV_OK != nRet)
            {
                CameraLogs?.Invoke(_CameraNmae, "执行软触发指令--失败");
                WriteLog("执行软触发指令--成功");
                return false;
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "执行软触发指令--失败");
                WriteLog("执行软触发指令--成功");

            }
            return true;
        }

        public override bool Start_Real_Mode()
        {

            if (Set_TriggerMode("Off"))
            {
                CameraLogs?.Invoke(_CameraNmae, "开始实时采集 -- 成功");
                WriteLog("开始实时采集 -- 成功");
                return true;
            }
            else
            {
                CameraLogs?.Invoke(_CameraNmae, "开始实时采集 -- 失败");
                WriteLog("开始实时采集 -- 失败");
                return false;
            }

        }
    }
}
