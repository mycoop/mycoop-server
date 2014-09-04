using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.BusinessProcesses;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [RoutePrefix("business-process")]
    public class BusinessProcessController : ApiControllerBase
    {
        public BusinessProcessController(IServiceManager serviceManager)
            : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcesses());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<IBusinessProcessService>().GetBusinessProcess(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditBusinessProcessModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddBusinessProcess");
            var id = await Service.Get<IBusinessProcessService>().AddBusinessProcess(model);
            Log.Out.EndInfo("AddBusinessProcess Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditBusinessProcessModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateBusinessProcess Id: {0}", id);
            await Service.Get<IBusinessProcessService>().UpdateBusinessProcess(id, model);
            Log.Out.EndInfo("UpdateBusinessProcess Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteBusinessProcess Id: {0}", id);
            await Service.Get<IBusinessProcessService>().DeleteBusinessProcess(id);
            Log.Out.EndInfo("DeleteBusinessProcess Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}