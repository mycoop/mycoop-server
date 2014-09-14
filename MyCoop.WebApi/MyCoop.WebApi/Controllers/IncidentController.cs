using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Incidents;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    public class IncidentController : ApiControllerBase
    {
        public IncidentController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeIncidents());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IManagementSevice>().GeIncident(id));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Add([FromBody] EditIncidentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddIncident");
            var id = await Service.Get<IManagementSevice>().AddIncident(model);
            Log.Out.EndInfo("AddIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditIncidentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateIncident Id: {0}", id);
            await Service.Get<IManagementSevice>().UpdateIncident(id, model);
            Log.Out.EndInfo("UpdateIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteIncident Id: {0}", id);
            await Service.Get<IManagementSevice>().DeleteIncident(id);
            Log.Out.EndInfo("DeleteIncident Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
