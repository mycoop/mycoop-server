using System;
using System.Threading.Tasks;
using Any.Logs.Loggers;
using MyCoop.Data;

namespace MyCoop.Loggers
{
    public class ErrorLogger : IEventLogger
    {
        public void Flush()
        {
            
        }

        public bool IsEnabledFor(string methodName)
        {
            return methodName == "Error";
        }

        public Task WriteAsync(string summary, string description)
        {
            var context = new CoopEntities();
            context.SysEvents.Add(new SysEvent
            {
                Summary = summary,
                Description = description,
                Time = DateTime.UtcNow,
                TypeId = 1
            });
            return context.SaveChangesAsync().ContinueWith(_ => context.Dispose());
        }
    }
}
