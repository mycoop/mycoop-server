using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCoop.Helpers;
using MyCoop.WebApi.Helpers;

namespace MyCoop.WebApi.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //return Content(SecurityHelper.GetHash(String.Concat("mr.gusev.k@gmail.com", "123")));
            return Content((UserHelper.GetId() != -1).ToString());
        }
    }
}
