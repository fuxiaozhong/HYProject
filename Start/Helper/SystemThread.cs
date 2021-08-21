using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using HYProject.ToolForm;

namespace HYProject.Helper
{
    public class SystemThread
    {
        static Thread Global_System;
        public static void Start()
        {
            Global_System = new Thread(Global_SystemWork);
            Global_System.Start();

        }

        private static void Global_SystemWork()
        {
            while (true)
            {
                try
                {
                    MainForm.Instance.Text = (Form_Global_System.Instance["标题栏"] == null ? "视觉软件" : Form_Global_System.Instance["标题栏"].ToString());
                    MainForm.Instance.toolStrip_Version.Text = "版本号:" + (Form_Global_System.Instance["版本号"] == null ? "v1.0.0" : Form_Global_System.Instance["版本号"].ToString());
                }
                catch (Exception)
                {
                }
                Thread.Sleep(10);
                Application.DoEvents();
            }
        }
    }
}
