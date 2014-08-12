using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using Any.Logs.Extentions;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Helpers;
using MyCoop.WebApi.Models.OrgUnits;
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
            Log.Out.Info(model.ToJson(), "User: {0} Begin AddOrgUnit", UserHelper.GetId());
            var id = await Service.Get<IManagementSevice>().AddOrgUnit(model);
            Log.Out.Info(model.ToJson(), "User: {0} End AddOrgUnit Id: {1}", UserHelper.GetId(), id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });

        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateOrgUnit([FromUri] int id, [FromBody] EditOrgUnitModel model)
        {
            Log.Out.Info(model.ToJson(), "User: {0} Begin UpdateOrgUnit Id: {1}", UserHelper.GetId(), id);
            await Service.Get<IManagementSevice>().UpdateOrgUnit(id, model);
            Log.Out.Info(model.ToJson(), "User: {0} End UpdateOrgUnit Id: {1}", UserHelper.GetId(), id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrgUnit(int id)
        {
            Log.Out.Info("User: {0} Begin DeleteOrgUnit Id: {1}", UserHelper.GetId(), id);
            await Service.Get<IManagementSevice>().DeleteOrgUnit(id);
            Log.Out.Info("User: {0} End DeleteOrgUnit Id: {1}", UserHelper.GetId(), id);
            return Request.CreateResponse(HttpStatusCode.OK);

        }

    }
}
