using NLog;
using NLog.Targets;
using System;
using System.Diagnostics;
using System.Reflection;

namespace CustomerHelperUtility
{
    public class Logger
    {
        private NLog.Logger logger;

        public Logger()
        {
            logger = NLog.LogManager.GetCurrentClassLogger();

        }

        internal string GetCallingMethodName()
        {
            string name = "unknown";
            StackTrace trace = new StackTrace(false);
            for (int i = 1; i < trace.FrameCount; i++)
            {
                StackFrame frame = trace.GetFrame(i);
                MethodBase method = frame.GetMethod();
                Type dt = method.DeclaringType;
                if (!typeof(ILogger).IsAssignableFrom(dt) && method.DeclaringType.Namespace != "DiagnosticsLibrary")
                {
                    name = string.Concat(method.DeclaringType.FullName, ".", method.Name);
                    break;
                }
            }
            return name;
        }

        private void Log(string log, LogLevel level = LogLevel.INFO)
        {
            switch (level)
            {
                case LogLevel.DEBUG:
                    logger.Debug(log);
                    break;
                case LogLevel.ERROR:
                    logger.Error(log);
                    break;
                case LogLevel.WARN:
                    logger.Warn(log);
                    break;
                default:
                    logger.Info(log);
                    break;
            }
        }

        public void Info(string log)
        {
            log = log.Replace("\r\n", string.Empty);
            log = log.Replace("\n", string.Empty);

            logger.Info(log);
        }

        public void Error(string log)
        {
            log = log.Replace("\r\n", string.Empty);
            log = log.Replace("\n", string.Empty);
            log = log.Replace(Environment.NewLine, " ");
            logger.Error(log);
        }

        public void Warn(string log)
        {
            log = log.Replace("\r\n", string.Empty);
            log = log.Replace("\n", string.Empty);

            logger.Warn(log);
        }

        public void Debug(string log)
        {
            log = log.Replace("\r\n", string.Empty);
            log = log.Replace("\n", string.Empty);

            logger.Debug(log);
        }


        public static string GetLogFilePath()
        {
            var fileTarget = (FileTarget)NLog.LogManager.Configuration.FindTargetByName("logfile");
            return fileTarget.FileName.ToString().Replace("'", string.Empty);
        }

        public enum LogLevel
        {
            DEBUG,
            ERROR,
            INFO,
            WARN
        }
    }
}
