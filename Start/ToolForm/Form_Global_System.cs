using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Global_System : HYBaseForm
    {
        private static Form_Global_System instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_Global_System Instance
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
                            instance = new Form_Global_System();
                        }
                    }
                }
                instance.Read();
                return instance;
            }
        }
        private Form_Global_System()
        {
            InitializeComponent();

        }

        public void Read()
        {
            if (Global_Parameter_System.GetData().Count == 0)
            {
                Global_Parameter_System.Read();
            }
        }
        public void Save()
        {
            Global_Parameter_System.Save();
        }

        /// <summary>
        /// 获取全局变量
        /// </summary>
        /// <param name="key">全局变量名称</param>
        /// <returns></returns>
        public object this[string key]
        {
            get
            {
                return Global_Parameter_System.GetValue(key);
            }
        }

        private void Form_Global_System_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global_Parameter_System.Save();
        }
    }
}
