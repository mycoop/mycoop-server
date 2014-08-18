using System;
using System.Diagnostics;
using System.Net.Http;
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
            summary = summary.Format(values);
            var description = new StackTrace(1).ToString();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Error, userId));
        }

        public static void Error(this Log log, Exception e, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            summary = summary.Format(values);
            var description = e.GetFullMessage();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Error, userId));
        }

        public static void Info(this Log log, string description, string summary, params object[] values)
        {
            int userId = UserHelper.GetId();
            summary = summary.Format(values);
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.Info, userId));
        }

        public static void Info(this Log log, string summary, params object[] values)
        {
            log.Info(String.Empty, summary, values);
        }

        public static void BeginInfo(this Log log, string summary, params object[] values)
        {
            log.Info(String.Format("Begin {0}", summary), values);
        }

        public static void BeginInfo(this Log log, string description, string summary, params object[] values)
        {
            log.Info(description, String.Format("Begin {0}", summary), values);
        }

        public static void EndInfo(this Log log, string summary, params object[] values)
        {
            log.Info(String.Format("End {0}", summary), values);
        }

        public static void EndInfo(this Log log, string description, string summary, params object[] values)
        {
            log.Info(description, String.Format("End {0}", summary), values);
        }

        public static void UserActivity(this Log log, HttpRequestMessage request)
        {
            int userId = UserHelper.GetId();
            var summary = request.RequestUri.AbsolutePath;
            var description = request.Headers.ToString();
            log.WriteAsync<EventLogger>(logger => logger.WriteAsync(summary, description, EventType.UserActivity, userId));
        }
    }
}