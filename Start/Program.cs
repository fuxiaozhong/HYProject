using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

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
            //初始化Log4j日志
            Log.InitLog4Net(Application.StartupPath + "\\Log4jConfig.xml");
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Log.RunLog(DateTime.Now.ToString() + " - 程序启动"); ;
            string proc = Process.GetCurrentProcess().ProcessName;
            Process[] processes = Process.GetProcessesByName(proc);
            if (processes.Length <= 1)
            {
                if (new Welcome().ShowDialog() == DialogResult.OK)
                    Application.Run(MainForm.Instance);
                else
                    Application.Exit();
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