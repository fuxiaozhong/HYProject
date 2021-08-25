using System.Windows.Forms;

using ToolKit.HYControls.HYForm;

namespace HYProject.ToolForm
{
    public partial class Form_Global_User : HYBaseForm
    {
        private static Form_Global_User instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_Global_User Instance
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
                            instance = new Form_Global_User();
                        }
                    }
                }
                instance.Read();
                return instance;
            }
        }

        public void Read()
        {
            if (Global_Parameter_User.GetData().Count == 0)
            {
                Global_Parameter_User.Read();
            }
        }

        public void Save()
        {
            Global_Parameter_User.Save();
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
                return Global_Parameter_User.GetValue(key);
            }
        }

        private Form_Global_User()
        {
            InitializeComponent();
        }

        private void Form_GlobalOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            Global_Parameter_User.Save();
        }
    }
}