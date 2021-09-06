using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Messaging;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using HalconDotNet;

using HYProject.Helper;

using NPOI.SS.Formula.Functions;

using ToolKit.HYControls.HYForm;

namespace HYProject
{
    /// <summary>
    /// 日志类
    /// </summary>
    public class Log
    {
        /// <summary>
        /// 锁
        /// </summary>
        private static object obj = new object();
        /// <summary>
        /// 配置文件
        /// </summary>
        private static string m_logFile;
        /// <summary>
        /// 日志类型对象
        /// </summary>
        private static Dictionary<string, log4net.ILog> m_lstLog = new Dictionary<string, log4net.ILog>();
        /// <summary>
        /// 显示队列
        /// </summary>
        private static ConcurrentQueue<LogInfo> Dispqueues = new ConcurrentQueue<LogInfo>();
        /// <summary>
        /// 显示线程
        /// </summary>
        private static Thread DispLog;
        /// <summary>
        /// 删除文件线程
        /// </summary>
        private static Thread _DeleteLogFile;
        /// <summary>
        /// 保存CSV队列
        /// </summary>
        private static ConcurrentQueue<LogInfo> SaveCSVQueues = new ConcurrentQueue<LogInfo>();
        /// <summary>
        /// 保存CSV线程
        /// </summary>
        private static Thread SaveSCV;


        /// <summary>
        /// 初始化
        /// </summary>
        /// <param name="strLog4NetConfigFile">配置文件</param>
        public static void InitLog4Net(string strLog4NetConfigFile)
        {
            m_logFile = strLog4NetConfigFile;
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(strLog4NetConfigFile));
            m_lstLog["error_logo"] = log4net.LogManager.GetLogger("error_logo");
            m_lstLog["warn_logo"] = log4net.LogManager.GetLogger("warn_logo");
            m_lstLog["run_logo"] = log4net.LogManager.GetLogger("run_logo");

            _DeleteLogFile = new Thread(DeleteLogFile);
            _DeleteLogFile.IsBackground = true;
            _DeleteLogFile.Name = "删除日志文件";
            _DeleteLogFile.Start();

            DispLog = new Thread(DispLogWork);
            DispLog.IsBackground = true;
            DispLog.Name = "显示日志文件";
            DispLog.Start();

            SaveSCV = new Thread(AutoSaveCSV);
            SaveSCV.IsBackground = true;
            SaveSCV.Name = "保存日志文件到CSV";
            SaveSCV.Start();
        }
        /// <summary>
        /// 添加队列
        /// </summary>
        /// <param name="message"></param>
        /// <param name="type"></param>
        private static void DispMessage(string message, string type)
        {
            Dispqueues.Enqueue(new LogInfo() { datetime = DateTime.Now, type = type, message = message });
            SaveCSVQueues.Enqueue(new LogInfo() { datetime = DateTime.Now, type = type, message = message });
        }
        /// <summary>
        /// 异步显示日志到窗口
        /// </summary>
        private static void DispLogWork()
        {
            while (true)
            {
                lock (obj)
                {

                    LogInfo logMessage = null;
                    var isExit = Dispqueues.TryDequeue(out logMessage);
                    if (!isExit)
                    {
                        Thread.Sleep(500);
                        continue;
                    }
                    try
                    {
                        switch (logMessage.type)
                        {
                            case "警告":
                                HYForm_Log.Instance.OutputMsg(logMessage.message, System.Drawing.Color.Orange);
                                break;
                            case "异常":
                                HYForm_Log.Instance.OutputMsg(logMessage.message, System.Drawing.Color.Red);
                                break;
                            case "正常":
                                HYForm_Log.Instance.OutputMsg(logMessage.message, System.Drawing.Color.Green);
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        WriteErrorLog(ex.Message, ex);
                    }
                }
            }
        }
        /// <summary>
        /// 到期自动删除日志文件
        /// </summary>
        private static void DeleteLogFile()
        {
            while (true)
            {
                try
                {
                    string LogPath = System.Windows.Forms.Application.StartupPath + "\\Logs";
                    DirectoryInfo theFolder = new DirectoryInfo(LogPath);
                    DirectoryInfo[] dirInfo = theFolder.GetDirectories();
                    foreach (DirectoryInfo NextFolder in dirInfo)
                    {
                        FileInfo[] fileInfo = NextFolder.GetFiles("*.*", SearchOption.AllDirectories);
                        foreach (FileInfo NextFile in fileInfo)
                        {
                            TimeSpan t = DateTime.Now - NextFile.CreationTime;  //当前时间  减去 文件创建时间
                            int day = t.Days;
                            if (day > AppParam.Instance.Log_Save_Days)   //保存的时间 ;  单位：天
                            {
                                File.Delete(NextFile.FullName);  //删除超过时间的文件
                            }
                        }
                    }
                    Thread.Sleep(1000);
                    Application.DoEvents();
                }
                catch (Exception ex)
                {
                    WriteErrorLog("删除日志文件出错", ex);
                }
            }
        }



        /// <summary>
        /// 功能描述:写入警告日志
        /// </summary>
        /// <param name="strWarnLog">strWarnLog</param>
        public static void WriteWarnLog(string strWarnLog)
        {
            if (m_lstLog["warn_logo"].IsWarnEnabled)
            {
                m_lstLog["warn_logo"].Warn(strWarnLog);
                DispMessage(strWarnLog, "警告");

            }
        }

        /// <summary>
        /// 功能描述:写入错误日志
        /// </summary>
        /// <param name="strErrLog">strErrLog</param>
        /// <param name="ex">ex</param>
        public static void WriteErrorLog(string strErrLog, Exception ex = null)
        {
            if (m_lstLog["error_logo"].IsErrorEnabled)
            {
                StackTrace stackTrace = new StackTrace();
                StackFrame stackFrame = stackTrace.GetFrame(1);
                MethodBase methodBase = stackFrame.GetMethod();

                m_lstLog["error_logo"].Error("<类名:" + methodBase.ReflectedType.Name + ">   <方法名:" + methodBase.Name + ">   <信息:" + strErrLog + ">", ex);
                DispMessage(strErrLog, "异常");

            }
        }

        /// <summary>
        /// 功能描述:写入运行日志
        /// </summary>
        /// <param name="runmessage">strErrLog</param>
        public static void WriteRunLog(string runmessage)
        {
            if (m_lstLog["run_logo"].IsErrorEnabled)
            {
                m_lstLog["run_logo"].Info(runmessage);
                DispMessage(runmessage, "正常");

            }
        }


        /// <summary>
        /// 保存日志到csv
        /// </summary>
        private static void AutoSaveCSV()
        {
            while (true)
            {
                try
                {
                    lock (obj)
                    {
                        LogInfo info = null;
                        var isExit = SaveCSVQueues.TryDequeue(out info);
                        if (!isExit)
                        {
                            Thread.Sleep(500);
                            continue;
                        }
                        try
                        {
                            if (!System.IO.Directory.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\"))
                            {
                                System.IO.Directory.CreateDirectory(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\");//不存在就创建目录
                            }
                            if (File.Exists(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv"))
                            {
                                //存在
                                File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", info.datetime.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
                            }
                            else
                            {
                                File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", "时间,类型,信息\n", Encoding.Default);
                                File.AppendAllText(System.AppDomain.CurrentDomain.BaseDirectory + @"\\Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", info.datetime.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
                            }
                        }
                        catch
                        {
                        }
                    }
                }
                catch
                {
                }
            }
        }
    }

    internal class LogInfo
    {
        public string type;
        public DateTime datetime;
        public string message;
    }
}