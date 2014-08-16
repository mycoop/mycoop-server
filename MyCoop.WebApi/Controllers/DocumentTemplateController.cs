using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using MyCoop.WebApi.Services;

namespace MyCoop.WebApi.Controllers
{
    public class DocumentTemplateController : ApiControllerBase
    {
        public DocumentTemplateController(IServiceManager serviceManager) : base(serviceManager)
        {
        }
    }
}
