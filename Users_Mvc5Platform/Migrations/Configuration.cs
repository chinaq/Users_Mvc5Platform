namespace Users_Mvc5Platform.Migrations
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Users_Mvc5Platform.Infrastructure;
    using Users_Mvc5Platform.Models;
    using Microsoft.AspNet.Identity;


    internal sealed class Configuration : DbMigrationsConfiguration<Users_Mvc5Platform.Infrastructure.AppIdentityDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "Users_Mvc5Platform.Infrastructure.AppIdentityDbContext";
        }

        protected override void Seed(Users_Mvc5Platform.Infrastructure.AppIdentityDbContext context)
        {
            AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
            AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
            string roleName = "Administrators";
            string userName = "admin4";
            string password = "admin4";
            string email = "admin4@example.com";
            if (!roleMgr.RoleExists(roleName))
            {
                roleMgr.Create(new AppRole(roleName));
            }
            AppUser user = userMgr.FindByName(userName);
            if (user == null)
            {
                userMgr.Create(new AppUser { UserName = userName, Email = email },
                password);
                user = userMgr.FindByName(userName);
            }
            if (!userMgr.IsInRole(user.Id, roleName))
            {
                userMgr.AddToRole(user.Id, roleName);
            }
            foreach (AppUser dbUser in userMgr.Users)
            {
                dbUser.City = Cities.PARIS;
            }
            context.SaveChanges();
        }
    }
}
