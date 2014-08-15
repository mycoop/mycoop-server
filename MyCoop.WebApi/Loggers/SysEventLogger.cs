using System;
using System.Threading.Tasks;
using Any.Logs.Loggers;
using MyCoop.Data;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Loggers
{
    public class SysEventLogger : EventLogger
    {
        public override Task WriteAsync(string method, string summary, string description)
        {
            return Task.Run(() => { });
            //var context = new CoopEntities();
            //context.SysEvents.Add(new SysEvent
            //{
            //    Summary = summary,
            //    Description = description,
            //    Time = DateTime.UtcNow,
            //    TypeId = method == "Error" ? 1 : 2,
            //    UserId = -1
            //});
            //return context.SaveChangesAsync().ContinueWith(_ => context.Dispose());
        }
    }
}
