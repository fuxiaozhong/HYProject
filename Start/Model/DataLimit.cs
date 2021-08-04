using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using HYProject.Helper;

namespace HYProject.Model
{
    [Serializable]
    public class DataLimit
    {
        private static DataLimit instance;
        //屏蔽
        internal bool Check_W;
        internal bool Check_M1;
        internal bool Check_M2;
        internal bool Check_PT;
        internal bool Check_P;
        internal bool Check_KJ;
        internal bool Check_S1;
        internal bool Check_S2;
        //下限
        internal decimal LowerLimit_W;
        internal decimal LowerLimit_M1;
        internal decimal LowerLimit_M2;
        internal decimal LowerLimit_PT;
        internal decimal LowerLimit_P;
        internal decimal LowerLimit_KJ;
        internal decimal LowerLimit_S1;
        internal decimal LowerLimit_S2;
        //基准
        internal decimal Standard_W;
        internal decimal Standard_M1;
        internal decimal Standard_M2;
        internal decimal Standard_PT;
        internal decimal Standard_P;
        internal decimal Standard_KJ;
        internal decimal Standard_S1;
        internal decimal Standard_S2;
        //上限
        internal decimal UpperLimit_W;
        internal decimal UpperLimit_M1;
        internal decimal UpperLimit_M2;
        internal decimal UpperLimit_PT;
        internal decimal UpperLimit_P;
        internal decimal UpperLimit_KJ;
        internal decimal UpperLimit_S1;
        internal decimal UpperLimit_S2;
        //补偿
        internal decimal Offset_W;
        internal decimal Offset_M1;
        internal decimal Offset_M2;
        internal decimal Offset_PT;
        internal decimal Offset_P;
        internal decimal Offset_KJ;
        internal decimal Offset_S1;
        internal decimal Offset_S2;








        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        private DataLimit()
        {
        }

        /// <summary>
        /// 初始化当前类(单例模式)
        /// </summary>
        public static DataLimit Instance
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
                            instance = new DataLimit();
                        }
                    }
                }
                return instance;
            }
        }

        public void Save()
        {
            Serialization.Save(DataLimit.Instance, "DataLimit");
        }
        public void Read()
        {
            instance = (DataLimit)Serialization.Read("DataLimit");
            if (instance == null)
            {
                instance = new DataLimit();
            }
        }



    }
}
