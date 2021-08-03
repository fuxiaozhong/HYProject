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
        /// 序列化保存数据
        /// </summary>
        public static void Save(object obj, string name)
        {
            FileStream stream = new FileStream(AppParam.Instance.Save_Data_Path + "\\" + name + ".bin", FileMode.Create);
            BinaryFormatter bFormat = new BinaryFormatter();
            bFormat.Serialize(stream, obj);
            stream.Close();
        }

        /// <summary>
        /// 读取序列化保存好的数据
        /// </summary>
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
    }
}