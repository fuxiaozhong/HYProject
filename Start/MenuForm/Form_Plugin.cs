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

namespace HYProject.MenuForm
{
    public partial class Form_Plugin : BaseForm
    {
        private static Form_Plugin instance;

        //程序运行时创建一个静态只读的进程辅助对象
        private static readonly object syncRoot = new object();

        public static Form_Plugin Instance
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
                            instance = new Form_Plugin();
                        }
                    }
                }
                return instance;
            }
        }

        private Form_Plugin()
        {
            InitializeComponent();
        }

        private void TreeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
           
            if (e.Node.Parent != null)
            {
                bool flag = false;
                for (int i = 0; i < tabControlEx1.TabPages.Count; i++)
                {
                    if (e.Node.Text == tabControlEx1.TabPages[i].Text)
                    {
                        tabControlEx1.SelectedIndex = i;
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    TabPage Page = new TabPage();
                    Page.Name = e.Node.Text;
                    Page.Text = e.Node.Text;
                    int R = new Random().Next(255);
                    int G = new Random().Next(255);
                    int B = new Random().Next(255);
                    B = (R + G > 400) ? R + G - 400 : B;
                    B = (B > 255) ? 255 : B;
                    Page.BackColor = Color.FromArgb(R, G, B);
                    tabControlEx1.Controls.Add(Page);
                    tabControlEx1.SelectedTab = Page;
                }

               
            }

        }
    }
}
