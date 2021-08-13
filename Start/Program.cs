using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

using HYProject.MenuForm;

using Application = System.Windows.Forms.Application;

namespace HYProject
{
    internal static class Program
    {
        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll ", SetLastError = true)]
        private static extern void SwitchToThisWindow(IntPtr hWnd, bool fAltTab);

        [DllImport("user32.dll", EntryPoint = "ShowWindow", CharSet = CharSet.Auto)]
        public static extern int ShowWindow(IntPtr hwnd, int nCmdShow);

        public const int SW_RESTORE = 9;
        public static IntPtr formhwnd;

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        private static void Main()
        {
            //设置应用程序处理异常方式：ThreadException处理
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //处理UI线程异常
            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            //处理非UI线程异常
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);
            AppParam.Instance.Read_From_File();
            AppParam.Instance.Power = "未登录";
            //初始化Log4j日志
            Log.InitLog4Net(Application.StartupPath + "\\Log4jConfig.xml");
            //加快主窗体弹出
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MainForm.Instance.ShowIcon = true;
            Log.WriteRunLog(DateTime.Now.ToString() + " - 程序启动"); ;
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length <= 1)
            {
                if (new Welcome().ShowDialog() == DialogResult.OK)
                {
                    if (AppParam.Instance.StartBeforeLogin)
                    {
                        Form_User form_User = new Form_User();
                        if (form_User.ShowDialog() == DialogResult.OK)
                        {
                            AppParam.Instance.Power = form_User.Power;
                            Log.WriteRunLog("用户登录:" + AppParam.Instance.Power);
                            MainForm.Instance.Text = "视觉软件 -- " + AppParam.Instance.Power;
                            Application.Run(MainForm.Instance);
                        }
                    }
                    else
                    {
                        Application.Run(MainForm.Instance);
                    }
                }
                else
                {
                    Application.Exit();
                }
            }
            else
            {
                for (int i = 0; i < processes.Length; i++)
                {
                    if (processes[i].Id != Process.GetCurrentProcess().Id)
                    {
                        if (processes[i].MainWindowHandle.ToInt32() == 0)
                        {
                            formhwnd = FindWindow(null, "MainForm");
                            ShowWindow(formhwnd, SW_RESTORE);
                            SwitchToThisWindow(formhwnd, true);
                        }
                        else
                        {
                            SwitchToThisWindow(processes[i].MainWindowHandle, true);
                        }
                    }
                }
            }
        }

        private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string errorMessage = e.Exception.Message;
            if (errorMessage.Contains("HALCON"))
            {
                errorMessage = errorMessage.Replace("HALCON", "图像操作");
            }

            Log.WriteErrorLog(errorMessage, e.Exception);
        }

        private static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string errorMessage = (e.ExceptionObject as Exception).Message;
            if (errorMessage.Contains("HALCON"))
            {
                errorMessage = errorMessage.Replace("HALCON", "图像操作");
            }

            Log.WriteErrorLog(errorMessage, e.ExceptionObject as Exception);
        }
    }
}