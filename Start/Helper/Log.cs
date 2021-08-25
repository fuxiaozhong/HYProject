﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Windows.Forms;

using ToolKit.HYControls.HYForm;

namespace HYProject
{
    public class Log
    {
        private static string m_logFile;
        private static Dictionary<string, log4net.ILog> m_lstLog = new Dictionary<string, log4net.ILog>();

        public static void InitLog4Net(string strLog4NetConfigFile)
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(strLog4NetConfigFile));
            m_logFile = strLog4NetConfigFile;
            m_lstLog["error_logo"] = log4net.LogManager.GetLogger("error_logo");
            m_lstLog["warn_logo"] = log4net.LogManager.GetLogger("warn_logo");
            m_lstLog["run_logo"] = log4net.LogManager.GetLogger("run_logo");
            _DeleteLogFile = new Thread(DeleteLogFile);
            _DeleteLogFile.IsBackground = true;
            _DeleteLogFile.Name = "删除日志文件";
            _DeleteLogFile.Start();
        }

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

        private static Thread _DeleteLogFile;

        /// <summary>
        /// 功能描述:写入警告日志
        /// </summary>
        /// <param name="strInfoLog">strInfoLog</param>
        public static void WriteWarnLog(string strWarnLog)
        {
            if (m_lstLog["warn_logo"].IsWarnEnabled)
            {
                m_lstLog["warn_logo"].Warn(strWarnLog);
                HYForm_Log.Instance.OutputMsg(strWarnLog, System.Drawing.Color.Orange);
                WriteLogCSV(strWarnLog, "警告");
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
                HYForm_Log.Instance.OutputMsg(strErrLog, System.Drawing.Color.Red);
                WriteLogCSV(strErrLog, "异常");
            }
        }

        /// <summary>
        /// 功能描述:写入运行日志
        /// </summary>
        /// <param name="strErrLog">strErrLog</param>
        /// <param name="ex">ex</param>
        public static void WriteRunLog(string runmessage)
        {
            if (m_lstLog["run_logo"].IsErrorEnabled)
            {
                m_lstLog["run_logo"].Info(runmessage);
                HYForm_Log.Instance.OutputMsg(runmessage, System.Drawing.Color.Green);
                WriteLogCSV(runmessage, "正常");
            }
        }

        /// <summary>
        /// 队列
        /// </summary>
        private static ConcurrentQueue<LogInfo> queues = new ConcurrentQueue<LogInfo>();

        private static Thread SaveSCV;

        private static void WriteLogCSV(string MESSAGE, string TYPE)
        {
            queues.Enqueue(new LogInfo() { datetime = DateTime.Now, type = TYPE, message = MESSAGE });
            if (SaveSCV == null)
            {
                SaveSCV = new Thread(AutoSaveCSV);
                SaveSCV.Start();
            }
        }

        private static object obj = new object();

        private static void AutoSaveCSV()
        {
            while (true)
            {
                try
                {
                    lock (obj)
                    {
                        LogInfo info = null;
                        var isExit = queues.TryDequeue(out info);
                        if (!isExit)
                        {
                            Thread.Sleep(500);
                            continue;
                        }
                        try
                        {
                            if (!System.IO.Directory.Exists(@"Logs\\ALL\\"))
                            {
                                System.IO.Directory.CreateDirectory(@"Logs\\ALL\\");//不存在就创建目录
                            }
                            if (File.Exists(@"Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv"))
                            {
                                //存在
                                File.AppendAllText(@"Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", info.datetime.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
                            }
                            else
                            {
                                File.AppendAllText(@"Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", "时间,类型,信息\n", Encoding.Default);
                                File.AppendAllText(@"Logs\\ALL\\" + DateTime.Now.ToString("yyyy-MM-dd") + ".csv", info.datetime.ToString("yyyy-MM-dd HH:mm:ss:ffff") + "," + info.type + "," + info.message + "\n", Encoding.Default);
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