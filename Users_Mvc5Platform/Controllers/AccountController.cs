﻿using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Users_Mvc5Platform.Models;
using Microsoft.AspNet.Identity.Owin;
using Users_Mvc5Platform.Infrastructure;



namespace Users_Mvc5Platform.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {

        #region 本controller属性

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }

        #endregion



        #region User登陆

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            //if (HttpContext.User.Identity.IsAuthenticated)
            //{
            //    return View("Error", new string[] { "Access Denied" });
            //}
            ViewBag.returnUrl = returnUrl;
            return View();
        }


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginModel details, string returnUrl)
        {
            if (String.IsNullOrWhiteSpace(returnUrl))
                returnUrl = "/Home/index";

            if (ModelState.IsValid)
            {
                AppUser user = await UserManager.FindAsync(details.Name, details.Password);
                if (user == null)
                {
                    ModelState.AddModelError("", "用户名或密码错误.");
                }
                else
                {
                    ClaimsIdentity ident = await UserManager
                        .CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
                    AuthManager.SignOut();
                    AuthManager.SignIn(
                        new AuthenticationProperties
                        {
                            IsPersistent = false
                        }, 
                        ident   
                    );
                    return Redirect(returnUrl);
                }
            }
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        #endregion



        #region User登出

        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Index", "Home");
        }

        #endregion
    }
}