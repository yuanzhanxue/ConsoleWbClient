using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using log4net;
using log4net.Repository.Hierarchy;
using log4net.Appender;

namespace ConsoleWbClient.Utilities
{
    public delegate void LogWriteEventHandler(string msg);

    public static class Log
    {
        public static event LogWriteEventHandler LogHandler;

        public static readonly string TimeFormat = "yyyy-MM-dd HH:mm:ss,fff";

        private static readonly ILog log
            = LogManager.GetLogger((new System.Diagnostics.StackTrace()).GetFrame(2).GetMethod().DeclaringType);

        public static void E(string msg)
        {
            HandleLog(DateTime.Now.ToString(TimeFormat) + " ERROR  " + msg);
            log.Error(msg);
        }

        public static void E(string msg, Exception e)
        {
            HandleLog(e.ToString());
            HandleLog(DateTime.Now.ToString(TimeFormat) + " ERROR  " + msg);
            log.Error(msg, e);
        }

        public static void W(string msg)
        {
            HandleLog(DateTime.Now.ToString(TimeFormat) + " WARN  " + msg);
            log.Warn(msg);
        }

        public static void W(string msg, Exception e)
        {
            HandleLog(e.ToString());
            HandleLog(DateTime.Now.ToString(TimeFormat) + " WARN  " + msg);
            log.Warn(msg, e);
        }

        public static void I(string msg)
        {
            HandleLog(DateTime.Now.ToString(TimeFormat) + " INFO  " + msg);
            log.Info(msg);
        }

        public static void I(string msg, Exception e)
        {
            HandleLog(e.ToString());
            HandleLog(DateTime.Now.ToString(TimeFormat) + " INFO  " + msg);
            log.Info(msg, e);
        }

        public static void D(string msg)
        {
            HandleLog(DateTime.Now.ToString(TimeFormat) + " DEBUG  " + msg);
            log.Debug(msg);
        }

        public static void D(string msg, Exception e)
        {
            HandleLog(e.ToString());
            HandleLog(DateTime.Now.ToString(TimeFormat) + " DEBUG  " + msg);
            log.Debug(msg, e);
        }

        public static void F(string msg, Exception e)
        {
            log.Fatal(msg, e);
        }

        public static string[] ReadAllLogs()
        {
            var rootAppender = ((Hierarchy)LogManager.GetRepository()).Root.Appenders.OfType<FileAppender>().FirstOrDefault();
            string filename = rootAppender != null ? rootAppender.File : string.Empty;

            if (string.IsNullOrEmpty(filename) || !System.IO.File.Exists(filename))
            {
                return null;
            }

            return System.IO.File.ReadAllLines(filename, Encoding.Default);
        }

        private static void HandleLog(string log)
        {
            if (LogHandler != null)
            {
                LogHandler(log);
            }
        }
    }
}
