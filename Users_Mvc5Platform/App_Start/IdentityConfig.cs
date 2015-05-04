using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users_Mvc5Platform.Infrastructure;

namespace Users_Mvc5Platform.App_Start
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext<AppIdentityDbContext>(AppIdentityDbContext.Create);    //为每个request创建一个AppIdentityDbContext实例
            app.CreatePerOwinContext<AppUserManager>(AppUserManager.Create);                //为每个request创建一个AppUserManager实例
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,      //使用cookie验证
                LoginPath = new PathString("/Account/Login"),                           //未授权则登陆到login页
            });
        }
    }
}