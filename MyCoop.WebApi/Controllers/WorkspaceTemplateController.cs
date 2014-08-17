using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Any.Logs;
using MyCoop.WebApi.Extentions;
using MyCoop.WebApi.Filters;
using MyCoop.WebApi.Loggers;
using MyCoop.WebApi.Models.WorkspaceTemplates;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    [CoopAuthorize]
    [RoutePrefix("workspace-template")]
    public class WorkspaceTemplateController : ApiControllerBase
    {
        public WorkspaceTemplateController(IServiceManager serviceManager) : base(serviceManager)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<HttpResponseMessage> Get()
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetWorkspaceTemplates());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Get(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetWorkspaceTemplate(id));
        }

        [HttpPost]
        [Route("")]
        public async Task<HttpResponseMessage> Add([FromBody] EditWorkspaceTemplateModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "AddWorkspaceTemplate");
            var id = await Service.Get<ITemplateService>().AddWorkspaceTemplate(model);
            Log.Out.EndInfo("AddWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK, new { Id = id });
        }

        [HttpPost]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Update([FromUri] int id, [FromBody] EditWorkspaceTemplateModel model)
        {
            Log.Out.BeginInfo(model.ToJson(), "UpdateWorkspaceTemplate - Id: {0}", id);
            await Service.Get<ITemplateService>().UpdateWorkspaceTemplate(id, model);
            Log.Out.EndInfo("UpdateWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<HttpResponseMessage> Delete(int id)
        {
            Log.Out.BeginInfo("DeleteWorkspaceTemplate - Id: {0}", id);
            await Service.Get<ITemplateService>().DeleteWorkspaceTemplate(id);
            Log.Out.EndInfo("DeleteWorkspaceTemplate - Id: {0}", id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpGet]
        [Route("{id}/document-template")]
        public async Task<HttpResponseMessage> GetGroups(int id)
        {
            return Request.CreateResponse(HttpStatusCode.OK, await Service.Get<ITemplateService>().GetDocumentsByWorkspaceTemplateId(id));
        }
    }
}
