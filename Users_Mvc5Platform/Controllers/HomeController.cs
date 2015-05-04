using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users_Mvc5Platform.Infrastructure;
using Microsoft.AspNet.Identity.Owin;

namespace Users_Mvc5Platform.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(UserManager.Users);
        }

        private AppUserManager UserManager {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
    }
}