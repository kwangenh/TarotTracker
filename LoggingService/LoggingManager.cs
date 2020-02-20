using NLog;
using Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LoggingService
{
    public class LoggingManager : ILoggingManager
    {
        public static ILogger logger = NLog.LogManager.GetCurrentClassLogger();

        public void LogDebug(string message)
        {
            logger.Debug(message);
        }

        public void LogWarning(string message)
        {
            logger.Debug(message);
        }

        public void LogError(string message)
        {
            logger.Error(message);
        }

        public void LogInfo(string message)
        {
            logger.Info(message);
        }
    }
}
