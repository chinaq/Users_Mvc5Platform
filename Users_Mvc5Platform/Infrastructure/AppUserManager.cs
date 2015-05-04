using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users_Mvc5Platform.Models;

namespace Users_Mvc5Platform.Infrastructure
{
    /// <summary>
    /// user管理
    /// </summary>
    public class AppUserManager : UserManager<AppUser>
    {
        public AppUserManager(IUserStore<AppUser> store) : base(store)
        {
        }


        /// <summary>
        /// 生成UserManager实例
        /// </summary>
        /// <param name="options"></param>
        /// <param name="context"></param>
        /// <returns></returns>
        public static AppUserManager Create(IdentityFactoryOptions<AppUserManager> options, IOwinContext context)
        {
            AppIdentityDbContext db = context.Get<AppIdentityDbContext>();              //iOwinContext.Get()返回注册在owin中的AppIdentityDbContext实例
            AppUserManager manager = new AppUserManager(new UserStore<AppUser>(db));        //UserStore是EF实现的IUserStore
            return manager;
        }

    }
}