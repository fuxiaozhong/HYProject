using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HYProject
{
    [Serializable]
    public class AppParam
    {
        private static AppParam instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static AppParam Instance
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
                            instance = new AppParam();
                            if (!Directory.Exists(instance.Save_Image_Path))
                            {
                                Directory.CreateDirectory(instance.Save_Image_Path);
                            }
                            if (!Directory.Exists(instance.Save_Data_Path))
                            {
                                Directory.CreateDirectory(instance.Save_Data_Path);
                            }
                        }
                    }
                }
                return instance;
            }
        }

        private AppParam()
        {
        }

        /// <summary>
        /// 当前登陆用户
        /// </summary>
        [NonSerialized]
        internal string Power = "未登录";

        /// <summary>
        /// 图像保存路径
        /// </summary>
        internal string Save_Image_Path = System.Windows.Forms.Application.StartupPath + "\\Images";

        /// <summary>
        /// 图像保存天数
        /// </summary>
        internal int Save_Image_Days = 30;

        /// <summary>
        /// 数据保存路径
        /// </summary>
        internal string Save_Data_Path = System.Windows.Forms.Application.StartupPath + "\\Data";

        /// <summary>
        /// 桌面快捷方式
        /// </summary>
        internal bool DesktopShortcut = false;

        /// <summary>
        /// 开机自启动
        /// </summary>
        internal bool PowerBoot = false;

        /// <summary>
        /// 启动自动最大化
        /// </summary>
        internal bool RunStateMax = false;

        /// <summary>
        /// 启动前登陆
        /// </summary>
        internal bool StartBeforeLogin = false;

        /// <summary>
        /// 运行状态
        /// </summary>
        [NonSerialized]
        internal bool Runing = false;

        /// <summary>
        /// 保存的文件名
        /// </summary>
        private string SerializePath = "AppParam.bin";

        /// <summary>
        /// 保存对象到文件
        /// </summary>
        public void Save_To_File()
        {
            Serialize_To_File(SerializePath, AppParam.Instance);
        }

        /// <summary>
        /// 从文件加载数据到对象
        /// </summary>
        public void Read_From_File()
        {
            instance = (AppParam)Deserialize_From_File(SerializePath);
            if (instance == null)
            {
                AppParam.instance = AppParam.Instance;
            }
        }

        /// <summary>
        /// 序列化当前类到文件
        /// </summary>
        /// <param name="path"></param>
        /// <param name="obj"></param>
        private void Serialize_To_File(string path, object obj)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, obj);
            stream.Close();
            stream.Dispose();
        }

        /// <summary>
        /// 反序列化当前类到对象
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private object Deserialize_From_File(string path)
        {
            if (!File.Exists(path))
                return null;

            FileStream stream = new FileStream(path, FileMode.Open);
            BinaryFormatter bFormat = new BinaryFormatter();
            object obj = bFormat.Deserialize(stream);
            stream.Close();
            stream.Dispose();
            return obj;
        }
    }
}