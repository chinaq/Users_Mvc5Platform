using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Users_Mvc5Platform.Models;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Users_Mvc5Platform.Infrastructure
{
    public class AppRoleManager : RoleManager<AppRole>, IDisposable
    {
        public AppRoleManager(RoleStore<AppRole> store) : base(store)
        {
        }


        public static AppRoleManager Create(
            IdentityFactoryOptions<AppRoleManager> options, IOwinContext context) 
        {
            return
                new AppRoleManager(
                    new RoleStore<AppRole>(context.Get<AppIdentityDbContext>())
                );
        }
    }
}