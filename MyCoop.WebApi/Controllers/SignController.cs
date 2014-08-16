using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Signs;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("sign")]
    public class SignController : ApiControllerBase
    {
        public SignController(IServiceManager serviceManager) : base(serviceManager)
        {
            
        }

        [HttpPost]
        [Route("in")]
        public async Task<HttpResponseMessage> In([FromBody] LoginModel login)
        {
            int userId = await Service.Get<ISystemService>().Connect(login.Email, login.Password);
            if (userId != -1)
            {
                UserHelper.SaveId(userId);
                Log.Out.Info("Sign in");
                return Request.CreateResponse(HttpStatusCode.OK, userId);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [HttpPost]
        [Route("out")]
        [CoopAuthorize]
        public HttpResponseMessage Out()
        {
            Log.Out.Info("Sign out");
            UserHelper.RemoveId();
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
