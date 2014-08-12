using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("user")]
    public class UserController : ApiControllerBase
    {
        public UserController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUsers()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUsers());

        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUser(id));

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddUser([FromBody] AddUserModel model)
        {
            var id = await Service.Get<ISystemService>().AddUser(model);
            Log.Out.Info(model.ToJson(), "AddUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateUser([FromUri] int id,  [FromBody] UpdateUserModel model)
        {
            await Service.Get<ISystemService>().UpdateUser(id, model);
            Log.Out.Info(model.ToJson(), "UpdateUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            await Service.Get<ISystemService>().DeleteUser(id);
            Log.Out.Info("DeleteUser - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpGet]
        [Route("{userId}/group")]
        public async Task<HttpResponseMessage> GetGroups(int userId)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUserGroups(userId));
        }
    }
}
