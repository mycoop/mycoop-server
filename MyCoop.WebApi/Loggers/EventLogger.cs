using System;
using System.Threading.Tasks;
using Any.Logs;
using MyCoop.Data;

namespace MyCoop.WebApi.Loggers
{
    public class EventLogger : ILogger
    {
        public Task WriteAsync(string summary, string description, EventType type, int userId)
        {
            var context = new CoopEntities();
            context.SysEvents.Add(new SysEvent
            {
                Summary = summary,
                Description = description,
                Time = DateTime.UtcNow,
                TypeId = (int)type,
                UserId = userId
            });
            return context.SaveChangesAsync().ContinueWith(_ => context.Dispose());
        }

        public void Flush()
        {
            
        }

        public bool IsEnabledFor(string method)
        {
            return true;
        }
    }
}
