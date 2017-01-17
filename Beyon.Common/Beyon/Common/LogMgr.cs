using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading;
using NLog;

namespace Beyon.Common
{
    /// <summary>
    /// 日志管理类
    /// </summary>
    public class LogMgr
    {
        #region 单件

        private static LogMgr m_Instance = new LogMgr();

        public static LogMgr Instance
        {
            get { return m_Instance; }
        }

        Logger logger = LogManager.GetCurrentClassLogger();

        public LogMgr()
        {
        }
        #endregion


        #region fields


        #endregion
        #region fuctions
        /// <summary>
        /// log
        /// </summary>
        public void Log(string info, TimeSpan time)
        {
            String content = String.Format("{0}:{1}", info, time.ToString());
            logger.Log(LogLevel.Info, content);
        }

        public void Log(string info)
        {
            logger.Log(LogLevel.Info, info);
        }

        public void Error(String info, Exception ex)
        {
            logger.Log(LogLevel.Error, ex);
        }
        #endregion
    }
}
