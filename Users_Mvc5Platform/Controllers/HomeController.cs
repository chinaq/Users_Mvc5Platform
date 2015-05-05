using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Users_Mvc5Platform.Infrastructure;
using Microsoft.AspNet.Identity.Owin;
using System.Threading.Tasks;
using Users_Mvc5Platform.Models;
using Microsoft.AspNet.Identity;



namespace Users_Mvc5Platform.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Dictionary<string, object> data = new Dictionary<string, object>();
            data.Add("Placeholder", "Placeholder");
            return View(data);
        }
    }
}