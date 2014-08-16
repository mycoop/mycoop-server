using System;
using System.Diagnostics;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Loggers
{
    public static class LogExtensions
    {
        public static void Error(this Log log, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            var stackTrace = new StackTrace(1);
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary.Format(values), stackTrace.ToString(), EventType.Error, userId));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary.Format(values), e.GetFullMessage(),EventType.Error,userId));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary.Format(values),String.Empty,EventType.Info,userId));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary.Format(values), description,EventType.Info,userId));
        } 
    }
}