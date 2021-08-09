using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace HYProject.Helper
{
    /// <summary>
    /// 序列化
    /// </summary>
    public class Serialization
    {
        /// <summary>
        /// 序列化保存对象
        /// </summary>
        /// <param name="obj">要保存的对象</param>
        /// <param name="path">要保存的路径</param>
        public static void Save2(object obj, string path)
        {
            FileStream stream = new FileStream(path, FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, obj);
            stream.Close();
        }
        /// <summary>
        /// 序列化保存对象
        /// </summary>
        /// <param name="obj">要保存的对象</param>
        /// <param name="name">要保存的文件名(默认路径)</param>
        public static void Save(object obj, string name)
        {
            FileStream stream = new FileStream(AppParam.Instance.Save_Data_Path + "\\" + name + ".bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, obj);
            stream.Close();
        }

        /// <summary>
        /// 读取序列化保存的对象
        /// </summary>
        /// <param name="name">(默认路径)要读取的文件名</param>
        /// <returns></returns>
        public static object Read(string name)
        {
            if (File.Exists(AppParam.Instance.Save_Data_Path + "\\" + name + ".bin"))
            {
                FileStream stream = new FileStream(AppParam.Instance.Save_Data_Path + "\\" + name + ".bin", FileMode.Open);
                BinaryFormatter bFormat = new BinaryFormatter();
                object obj = bFormat.Deserialize(stream);
                stream.Close();
                return obj;
            }
            return null;
        }
        /// <summary>
        /// 读取序列化保存的对象
        /// </summary>
        /// <param name="path">要读取的文件路径</param>
        /// <returns></returns>
        public static object Read2(string path)
        {
            if (File.Exists(path))
            {
                FileStream stream = new FileStream(path, FileMode.Open);
                BinaryFormatter bFormat = new BinaryFormatter();
                object obj = bFormat.Deserialize(stream);
                stream.Close();
                return obj;
            }
            return null;
        }
    }
}