using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using ToolKit.DisplayWindow;

namespace HYProject.ToolForm
{
    public partial class Form_GlobalOptions : Form
    {
        private static Form_GlobalOptions instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_GlobalOptions Instance
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
                            instance = new Form_GlobalOptions();
                        }
                    }
                }
                return instance;
            }
        }

        public object this[string key]
        {
            get
            {
                return globalVariable1.GetValue(key);
            }
        }

        private Form_GlobalOptions()
        {
            InitializeComponent();
        }

        private void Form_GlobalOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            globalVariable1.Save();
        }
    }
}
