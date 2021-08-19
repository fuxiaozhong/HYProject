using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;

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
        }

        /// <summary>
        /// 功能描述:写入警告日志
        /// </summary>
        /// <param name="strInfoLog">strInfoLog</param>
        public static void WriteWarnLog(string strWarnLog)
        {
            if (m_lstLog["warn_logo"].IsWarnEnabled)
            {
                m_lstLog["warn_logo"].Warn(strWarnLog);
                Form_Log.Instance.OutputMsg(strWarnLog, System.Drawing.Color.Orange);
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
                Form_Log.Instance.OutputMsg(strErrLog, System.Drawing.Color.Red);
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
                Form_Log.Instance.OutputMsg(runmessage, System.Drawing.Color.Green);
            }
        }
    }
}