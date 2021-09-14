using System;
using System.Windows.Forms;

using Org.BouncyCastle.Asn1.X509;

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
                        if (instance == null)
                        {
                            instance = new Form_Global_System();
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

        private void Form_Global_System_Load(object sender, EventArgs e)
        {
            if (Global_Parameter_System.GetData().Count == 0)
            {

                Global_Parameter_System.Add("String", "日期格式", "yyyy-MM-dd HH:mm:ss", "时间格式");
                Global_Parameter_System.Add("String", "标题栏", "视觉软件", "软件标题");
                Global_Parameter_System.Add("String", "版本号", "v1.0.0", "软件版本号");
                Global_Parameter_System.Add("Bool", "系统设置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "用户设置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "通讯设置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "相机", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "设置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "产品库", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "工具", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "锁定", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "相机配置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "光源配置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "屏幕键盘", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "PLC配置", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "系统操作", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "用户变量", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "系统变量", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "备份", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "重启", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "TCP服务端", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "TCP客户端", "true", "菜单按钮显示状态");
                Global_Parameter_System.Add("Bool", "数据面板", "true", "右侧面板显示状态");
                Global_Parameter_System.Add("Int", "显示数量", "3", "图像显示界面数量");

            }
        }
    }
}