using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyCoop.WebApi.Helpers;
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
        public async Task<HttpResponseMessage> In([FromBody] UserModel user)
        {
            int userId = await Service.Get<ISystemService>().Connect(user.Email, user.Password);
            if (userId != -1)
            {
                UserHelper.SaveId(userId);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest);

        }

        [HttpPost]
        [Route("out")]
        public HttpResponseMessage Out()
        {
            UserHelper.RemoveId();
            return Request.CreateResponse(HttpStatusCode.OK);

        }
    }
}
