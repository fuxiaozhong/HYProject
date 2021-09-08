using System;
using System.Threading;
using System.Windows.Forms;

using HYProject.ToolForm;

namespace HYProject.Helper
{
    public class SystemThread
    {
        private static Thread Global_System;

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
                    MainForm.Instance.UserName = AppParam.Instance.Power;
                    SystemInfo systemInfo = new SystemInfo();
                    MainForm.Instance.pro_memory.Value = (int)Math.Ceiling(((double)((systemInfo.PhysicalMemory - systemInfo.MemoryAvailable)) / (double)(systemInfo.PhysicalMemory) * 100));
                    MainForm.Instance.tsl_nowtime.Text = DateTime.Now.ToString(Form_Global_System.Instance["日期格式"] == null ? "yyyy-MM-dd HH:mm:ss" : Form_Global_System.Instance["日期格式"].ToString());
                    MainForm.Instance.Text = (Form_Global_System.Instance["标题栏"] == null ? "视觉软件" : Form_Global_System.Instance["标题栏"].ToString());
                    MainForm.Instance.toolStrip_Version.Text = "版本号:" + (Form_Global_System.Instance["版本号"] == null ? "v1.0.0" : Form_Global_System.Instance["版本号"].ToString());
                    MainForm.Instance.系统设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统设置"] == null ? true : Form_Global_System.Instance["系统设置"]));
                    MainForm.Instance.用户设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["用户设置"] == null ? true : Form_Global_System.Instance["用户设置"]));
                    MainForm.Instance.通讯设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["通讯设置"] == null ? true : Form_Global_System.Instance["通讯设置"]));
                    MainForm.Instance.相机ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["相机"] == null ? true : Form_Global_System.Instance["相机"]));
                    MainForm.Instance.设置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["设置"] == null ? true : Form_Global_System.Instance["设置"]));
                    MainForm.Instance.产品库ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["产品库"] == null ? true : Form_Global_System.Instance["产品库"]));
                    MainForm.Instance.工具ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["工具"] == null ? true : Form_Global_System.Instance["工具"]));
                    MainForm.Instance.锁定ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["锁定"] == null ? true : Form_Global_System.Instance["锁定"]));
                    MainForm.Instance.相机配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["相机配置"] == null ? true : Form_Global_System.Instance["相机配置"]));
                    MainForm.Instance.光源配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["光源配置"] == null ? true : Form_Global_System.Instance["光源配置"]));
                    // MainForm.Instance.全局变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["全局变量"] == null ? true : Form_Global_System.Instance["全局变量"]));
                    MainForm.Instance.屏幕键盘ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["屏幕键盘"] == null ? true : Form_Global_System.Instance["屏幕键盘"]));
                    MainForm.Instance.pLC配置ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["PLC配置"] == null ? true : Form_Global_System.Instance["PLC配置"]));
                    MainForm.Instance.系统操作ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统操作"] == null ? true : Form_Global_System.Instance["系统操作"]));
                    MainForm.Instance.用户变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["用户变量"] == null ? true : Form_Global_System.Instance["用户变量"]));
                    //MainForm.Instance.系统变量ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["系统变量"] == null ? true : Form_Global_System.Instance["系统变量"]));
                    MainForm.Instance.备份ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["备份"] == null ? true : Form_Global_System.Instance["备份"]));
                    MainForm.Instance.重启ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["重启"] == null ? true : Form_Global_System.Instance["重启"]));
                    MainForm.Instance.tCP服务端ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["TCP服务端"] == null ? true : Form_Global_System.Instance["TCP服务端"]));
                    MainForm.Instance.tCP客户端ToolStripMenuItem.Visible = ((bool)(Form_Global_System.Instance["TCP客户端"] == null ? true : Form_Global_System.Instance["TCP客户端"]));
                    MainForm.Instance.splitContainer_Main.Panel2Collapsed = !((bool)(Form_Global_System.Instance["数据面板"] == null ? true : Form_Global_System.Instance["数据面板"]));
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