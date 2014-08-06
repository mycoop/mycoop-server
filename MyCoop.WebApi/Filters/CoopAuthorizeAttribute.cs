﻿using System.Web.Http;
using System.Web.Http.Controllers;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Filters
{
    public class CoopAuthorizeAttribute : AuthorizeAttribute
    {
        protected override bool IsAuthorized(HttpActionContext actionContext)
        {
#if !DEBUG
            return UserHelper.GetId() != -1;
#else
            return true;
#endif
        }
    }
}