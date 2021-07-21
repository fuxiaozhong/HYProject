using System;
using System.Collections.Generic;

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
            m_lstLog["info_logo"] = log4net.LogManager.GetLogger("info_logo");
            m_lstLog["error_logo"] = log4net.LogManager.GetLogger("error_logo");
            m_lstLog["warn_logo"] = log4net.LogManager.GetLogger("warn_logo");
            m_lstLog["run"] = log4net.LogManager.GetLogger("run");
        }

        /// <summary>
        /// 功能描述:写入常规日志
        /// </summary>
        /// <param name="strInfoLog">strInfoLog</param>
        public static void WriteInfoLog(string strInfoLog)
        {
            if (m_lstLog["info_logo"].IsInfoEnabled)
            {
                m_lstLog["info_logo"].Info(strInfoLog);
                Form_Log.Instance.OutputMsg(strInfoLog, System.Drawing.Color.Green);
            }
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
                Form_Log.Instance.OutputMsg(strWarnLog, System.Drawing.Color.Yellow);
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
                m_lstLog["error_logo"].Error(strErrLog, ex);
                Form_Log.Instance.OutputMsg(strErrLog, System.Drawing.Color.Red);
            }
        }

        public static void RunLog(string runmessage)
        {
            if (m_lstLog["run"].IsErrorEnabled)
            {
                m_lstLog["run"].Fatal(runmessage);
                Form_Log.Instance.OutputMsg(runmessage, System.Drawing.Color.Green);
            }
        }
    }
}