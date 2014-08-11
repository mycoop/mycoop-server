using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Models.OrgUnits;
using MyCoop.WebApi.Models.Users;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{

    [CoopAuthorize]
    [RoutePrefix("orgunit")]
    public class OrgUnitController : ApiControllerBase
    {
        public OrgUnitController(IServiceManager serviceManager) 
            : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GeOrgUnits()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeOrgUnits());

        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetOrgUnit(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeOrgUnit(id));

        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddOrgUnit([FromBody] EditOrgUnitModel model)
        {
            var id = await Service.Get<IManagementSevice>().AddOrgUnit(model);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateOrgUnit([FromUri] int id, [FromBody] EditOrgUnitModel model)
        {
            await Service.Get<IManagementSevice>().UpdateOrgUnit(id, model);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrgUnit(int id)
        {
            await Service.Get<IManagementSevice>().DeleteOrgUnit(id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
