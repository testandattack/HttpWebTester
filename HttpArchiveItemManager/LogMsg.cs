using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Globalization;
using System.Threading;
using System.Drawing;

namespace GTC.Utilities
{
#pragma warning disable 1591
    /// <summary>
    /// Use to log events to the display and/or event log
    /// </summary>
    public static class LogMsg
    {
        #region -- Properties -----------------------------------------------
        public static LoggingLevel globalLevel = LoggingLevel.Debug;
        public static bool includeDateTime = false;
        public static bool includeThreadId = true;

        public static bool writeToLogFile = false;
        public static string sLogFilePath = "";
        private static StringBuilder sbLog = new StringBuilder();
        #endregion

        #region -- Main Methods ---------------------------------------------
        public static string WriteLine(string strMsg)
        {
            return Write(globalLevel, strMsg + "\r\n");
        }

        public static string Write(LoggingLevel level, string formatString, object arg1)
        {
            string strMsg = string.Format(formatString, arg1);
            return Write(level, strMsg);
        }

        public static string Write(LoggingLevel level, string formatString, object arg1, object arg2)
        {
            string strMsg = string.Format(formatString, arg1, arg2);
            return Write(level, strMsg);
        }

        public static string Write(LoggingLevel level, string formatString, params object[] args)
        {
            string strMsg = string.Format(formatString, args);
            return Write(level, strMsg);
        }

        public static string Write(string formatString, params object[] args)
        {
            string strMsg = string.Format(formatString, args);
            return Write(globalLevel, strMsg);
        }

        public static string Write(LoggingLevel level, string strMsg)
        {
            if (level > globalLevel)
                return strMsg;

            string str;
            if (includeDateTime)
            {
                System.DateTime today = System.DateTime.Now;
                str = $"{today.ToShortDateString()} {today.ToShortTimeString()}: {strMsg}";
            }
            else if (includeThreadId)
            {
                str = String.Format("[Thread:{0:D3}] {1}", Thread.CurrentThread.ManagedThreadId, strMsg);
            }
            else
                str = strMsg;

            //Color color;
            //if (level == LoggingLevel.None) color = System.Drawing.Color.Azure;
            //else if (level == LoggingLevel.Summary) color = System.Drawing.Color.Black;
            //else if (level == LoggingLevel.Error) color = System.Drawing.Color.Orange;
            //else if (level == LoggingLevel.Detailed) color = System.Drawing.Color.Green;
            //else if (level == LoggingLevel.Code) color = System.Drawing.Color.Blue;
            //else if (level == LoggingLevel.Debug) color = System.Drawing.Color.Red;
            //else color = System.Drawing.Color.Yellow;

            sbLog.AppendLine(str);

            if (writeToLogFile)
                AddToLogFile(str);

            return strMsg;
        }
        #endregion

        #region -- Utility Methods -------------------------------------------
        public static void ClearLogFile()
        {
            if (sLogFilePath.Length > 0)
            {
                try
                {
                    File.Delete(sLogFilePath);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }

        private static void AddToLogFile(string str)
        {
            if (!String.IsNullOrEmpty(sLogFilePath))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sLogFilePath, true))
                    {
                        sw.Write(str + "\r\n");
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }

        public static void WriteFinalLogFile()
        {
            if (!String.IsNullOrEmpty(sLogFilePath))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sLogFilePath, true))
                    {
                        sw.Write(sbLog.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }
        #endregion
    }

    public class mLogMsg
    {
        #region -- Properties -----------------------------------------------
        public LoggingLevel globalLevel = LoggingLevel.Debug;
        public bool includeDateTime = false;
        public bool includeThreadId = true;

        public bool writeToLogFile = false;
        public string sLogFilePath = "";
        private StringBuilder sbLog = new StringBuilder();
        #endregion

        #region -- Main Methods ---------------------------------------------
        public string WriteLine(string strMsg)
        {
            return Write(globalLevel, strMsg + "\r\n");
        }

        public string Write(LoggingLevel level, string formatString, object arg1)
        {
            string strMsg = string.Format(formatString, arg1);
            return Write(level, strMsg);
        }

        public string Write(LoggingLevel level, string formatString, object arg1, object arg2)
        {
            string strMsg = string.Format(formatString, arg1, arg2);
            return Write(level, strMsg);
        }

        public string Write(LoggingLevel level, string formatString, params object[] args)
        {
            string strMsg = string.Format(formatString, args);
            return Write(level, strMsg);
        }

        public string Write(string formatString, params object[] args)
        {
            string strMsg = string.Format(formatString, args);
            return Write(globalLevel, strMsg);
        }

        public string Write(LoggingLevel level, string strMsg)
        {
            if (level > globalLevel)
                return strMsg;

            string str;
            if (includeDateTime)
            {
                System.DateTime today = System.DateTime.Now;
                str = $"{today.ToShortDateString()} {today.ToShortTimeString()}: {strMsg}";
            }
            else if (includeThreadId)
            {
                str = String.Format("[Thread:{0:D3}] {1}", Thread.CurrentThread.ManagedThreadId, strMsg);
            }
            else
                str = strMsg;

            //Color color;
            //if (level == LoggingLevel.None) color = System.Drawing.Color.Azure;
            //else if (level == LoggingLevel.Summary) color = System.Drawing.Color.Black;
            //else if (level == LoggingLevel.Error) color = System.Drawing.Color.Orange;
            //else if (level == LoggingLevel.Detailed) color = System.Drawing.Color.Green;
            //else if (level == LoggingLevel.Code) color = System.Drawing.Color.Blue;
            //else if (level == LoggingLevel.Debug) color = System.Drawing.Color.Red;
            //else color = System.Drawing.Color.Yellow;

            sbLog.AppendLine(str);

            if (writeToLogFile)
                AddToLogFile(str);

            return strMsg;
        }
        #endregion

        #region -- Utility Methods -------------------------------------------
        public void ClearLogFile()
        {
            if (sLogFilePath.Length > 0)
            {
                try
                {
                    File.Delete(sLogFilePath);
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }

        private void AddToLogFile(string str)
        {
            if (!String.IsNullOrEmpty(sLogFilePath))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sLogFilePath, true))
                    {
                        sw.Write(str + "\r\n");
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }

        public void WriteFinalLogFile()
        {
            if (!String.IsNullOrEmpty(sLogFilePath))
            {
                try
                {
                    using (StreamWriter sw = new StreamWriter(sLogFilePath, true))
                    {
                        sw.Write(sbLog.ToString());
                    }
                }
                catch (Exception ex)
                {
                    Debug.Write(ex.ToString());
                }
            }
        }

        public string GetFinalLogAsString()
        {
            return sbLog.ToString();
        }
        #endregion
    }


    /// <summary>
    /// Defines the level of logging that will occur
    /// </summary>
    public enum LoggingLevel
    {
        /// <summary>
        /// Nothing is output
        /// </summary>
        None = 0,

        /// <summary>
        /// Output only errors
        /// </summary>
        Error = 1,

        /// <summary>
        /// Output errors and summary info
        /// </summary>
        Summary = 5,

        /// <summary>
        /// Output all messages except debug statements
        /// </summary>
        Detailed = 10,

        /// <summary>
        /// Used with Detailed messages to control the color of the code showing in RTMonitor
        /// </summary>
        Code = 12,

        /// <summary>
        /// Output all messages
        /// </summary>
        Debug = 15
    };
#pragma warning restore 1591
}
