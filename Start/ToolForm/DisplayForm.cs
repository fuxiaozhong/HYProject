﻿using System.Windows.Forms;

using ToolKit.DisplayWindow;

namespace HYProject.ToolForm
{
    public partial class DisplayForm : Form
    {
        private static DisplayForm instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static DisplayForm Instance
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
                            instance = new DisplayForm();
                            instance.TopLevel = false;
                            instance.Dock = DockStyle.Fill;
                            instance.Show();
                        }
                    }
                }
                return instance;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.ExStyle |= 0x02000000; // 用双缓冲绘制窗口的所有子控件
                return cp;
            }
        }

        private DisplayForm()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
        }

        public int DisplayWindowCount
        {
            get
            {
                return autoAddDisplayWindowControl1.Count;
            }
            set
            {
                autoAddDisplayWindowControl1.Count = value;
            }
        }

        public DisplayWindow this[int key]
        {
            get
            {
                return autoAddDisplayWindowControl1[key];
            }
        }
    }
}