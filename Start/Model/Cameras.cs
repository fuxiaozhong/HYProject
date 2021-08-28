using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

using ToolKit.CamreaSDK;

namespace HYProject.Model
{
    public class Cameras
    {
        private static Cameras instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static Cameras Instance
        {
            get
            {
                //先判断是否存在，不存在再加锁处理
                if (instance == null)
                {
                    //在同一个时刻加了锁的那部分程序只有一个线程可以进入
                    lock (syncRoot)
                    {
                        if (instance == null)
                        {
                            instance = new Cameras();
                        }
                    }
                }
                return instance;
            }
        }

        public Dictionary<string, ICamera> GetCameras
        {
            get { return this.cameras; }
        }

        /// <summary>
        /// 相机列表
        /// </summary>
        private Dictionary<string, ICamera> cameras = new Dictionary<string, ICamera>();

        private Cameras()
        {
        }

        /// <summary>
        /// 索引器(根据相机名称拿取相机)
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <returns></returns>
        public ICamera this[string cameraName]
        {
            get
            {
                bool isExis = false;
                foreach (var item in cameras.Keys)
                {
                    if (item == cameraName)
                    {
                        isExis = true;
                        break;
                    }
                    isExis = false;
                }
                if (isExis)
                {
                    return cameras[cameraName];
                }
                else
                {
                    Log.WriteWarnLog("没有找到ID:" + cameraName + "的相机,默认使用第一个相机");
                    return cameras.Values.First();
                }
            }
        }

        /// <summary>
        /// 添加相机到字典中
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="camera">相机</param>
        public void AddCamera(string cameraName, ICamera camera)
        {
            bool isExis = false;
            foreach (var item in cameras.Keys)
            {
                if (item == cameraName)
                {
                    isExis = true;
                    break;
                }
                isExis = false;
            }

            if (isExis)
            {
                System.Windows.Forms.MessageBox.Show("软件中已经存在相同名称的相机,无法添加名称为:" + cameraName + "的相机");
            }
            else
            {
                cameras.Add(cameraName, camera);
            }
        }

        /// <summary>
        /// 关闭所有相机
        /// </summary>
        public void CloseCamera()
        {
            foreach (ICamera item in cameras.Values)
            {
                Log.WriteRunLog("相机:" + item._CameraNmae + "关闭成功");
                item.Close();
            }

            cameras.Clear();
        }

        /// <summary>
        /// 集中初始化相机
        /// </summary>
        public void InitializeCamera()
        {
            if (AppParam.Instance.CameraInitStr != null && AppParam.Instance.CameraInitStr.Count > 0)
            {
                foreach (CameraInfo item in AppParam.Instance.CameraInitStr)
                {
                    InitCamera(item.CameraName, item.CameraType);
                }
            }
        }

        /// <summary>
        /// 重新初始化相机
        /// </summary>
        public void ReInitializeCamera()
        {
            CloseCamera();
            InitializeCamera();
        }

        /// <summary>
        /// 初始化打开相机
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="type">相机类型</param>
        private void InitCamera(string cameraName, CameraType type)
        {
            switch (type)
            {
                case CameraType.大华相机:
                    DaHuaCamera dahua = new DaHuaCamera();
                    if (dahua.Open(cameraName))
                    {
                        Log.WriteRunLog("相机:" + cameraName + "打开成功");
                        AddCamera(cameraName, dahua);
                        dahua.IsSaveLog2Disk = true;
                        dahua.ImageProcessEvent += Camera_ImageProcessEvent;
                    }
                    else
                    {
                        Log.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;

                case CameraType.海康威视:
                    HikvisionCamera haikang = new HikvisionCamera();
                    if (haikang.Open(cameraName))
                    {
                        Log.WriteRunLog("相机:" + cameraName + "打开成功");
                        AddCamera(cameraName, haikang); 
                        haikang.IsSaveLog2Disk = true;
                        haikang.ImageProcessEvent += Camera_ImageProcessEvent;
                    }
                    else
                    {
                        Log.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;

                case CameraType.巴斯勒:
                    BaslerPylonGigE basler = new BaslerPylonGigE();
                    if (basler.Open(cameraName))
                    {
                        Log.WriteRunLog("相机:" + cameraName + "打开成功");
                        AddCamera(cameraName, basler); 
                        basler.IsSaveLog2Disk = true;
                        basler.ImageProcessEvent += Camera_ImageProcessEvent;
                    }
                    else
                    {
                        Log.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;
                case CameraType.Halcon:
                    HalconCamera halconCamera = new HalconCamera();
                    if (halconCamera.Open(cameraName))
                    {
                        Log.WriteRunLog("相机:" + cameraName + "打开成功");
                        AddCamera(cameraName, halconCamera); 
                        halconCamera.IsSaveLog2Disk = true;
                        halconCamera.ImageProcessEvent += Camera_ImageProcessEvent;
                    }
                    else
                    {
                        Log.WriteErrorLog("相机:" + cameraName + "打开失败");
                    }
                    break;
            }
        }

        /// <summary>
        /// 图像处理事件
        /// </summary>
        /// <param name="cameraName">相机名称</param>
        /// <param name="ho_image">图片</param>
        public void Camera_ImageProcessEvent(string cameraName, HalconDotNet.HObject ho_image)
        {
            Log.WriteRunLog(cameraName + "接收到图像开始处理......");
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            Work.CameraWork(cameraName, ho_image);
            stopwatch.Stop();
            Log.WriteRunLog(cameraName + "图像处理完成,耗时:" + stopwatch.ElapsedMilliseconds + "ms");
        }
    }

    /// <summary>
    /// 相机类型
    /// </summary>
    public enum CameraType
    {
        大华相机, 海康威视, 巴斯勒, Halcon
    }
}