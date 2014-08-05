using System.Web.Http;
using System.Web.Mvc;

namespace MyCoop.WebApi.AppStart
{
    public static class DependencyConfig
    {
        public static void RegisterDependencies(HttpConfiguration config, ControllerBuilder controllerBuilder)
        {
            config.DependencyResolver = new WebApiDependencyResolver();
        }
    }
}