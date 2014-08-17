using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.Components;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    public class ComponentController : ApiControllerBase
    {
        public ComponentController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetComponents()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetComponents());
        }

        [HttpGet]
        public async Task<HttpResponseMessage> GetComponent(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetComponent(id));
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddComponent([FromBody] EditComponentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddComponent");
            var id = await Service.Get<ITemplateService>().AddComponent(model);
            Log.Out.EndInfo("AddComponent Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        public async Task<HttpResponseMessage> UpdateComponent([FromUri] int id, [FromBody] EditComponentModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateComponent Id: {0}", id);
            await Service.Get<ITemplateService>().UpdateComponent(id, model);
            Log.Out.EndInfo("UpdateComponent Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public async Task<HttpResponseMessage> DeleteOrgUnit(int id)
        {
            Log.Out.BeginInfo("DeleteComponent Id: {0}", id);
            await Service.Get<ITemplateService>().DeleteComponent(id);
            Log.Out.EndInfo("DeleteComponent Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
