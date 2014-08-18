using System.Web.Http.Filters;
using Any.Logs;
using MyCoop.WebApi.Loggers;

namespace MyCoop.WebApi.Filters
{
    public class UserActivityFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Log.Out.UserActivity(actionExecutedContext.Request);
            base.OnActionExecuted(actionExecutedContext);
        }
    }
}