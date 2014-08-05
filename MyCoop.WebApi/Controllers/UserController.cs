using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    public class UserController : ApiControllerBase
    {
        public UserController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUsers()
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUsers());
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetUser(int id)
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUser(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddUser([FromBody] AddUserModel model)
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                var id = await Service.Get<ISystemService>().AddUser(model);
                return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateUser([FromUri] int id,  [FromBody] UpdateUserModel model)
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                await Service.Get<ISystemService>().UpdateUser(id, model);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteUser(int id)
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                await Service.Get<ISystemService>().DeleteUser(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }

        [HttpGet]
        [Route("{id}/group")]
        public async Task<HttpResponseMessage> GetGroups(int id)
        {
            int userId = UserHelper.GetId();
            if (userId != -1)
            {
                return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ISystemService>().GetUserGroups(id));
            }
            return Request.CreateResponse(HttpStatusCode.Unauthorized);

        }
    }
}
