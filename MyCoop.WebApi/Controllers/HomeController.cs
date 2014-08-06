using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyCoop.Data;
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

            //var context = new CoopEntities();
            //int id = 1;
            //var query = context.Groups.Where(g => g.UserGroups.Any(ug => ug.UserId == id));
            //return Content(query.ToString());
        }
    }
}
