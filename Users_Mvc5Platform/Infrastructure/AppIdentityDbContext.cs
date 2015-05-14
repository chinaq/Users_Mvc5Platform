using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Users_Mvc5Platform.Models;
using Microsoft.AspNet.Identity;


namespace Users_Mvc5Platform.Infrastructure
{
    /// <summary>
    /// Identity的DbContext
    /// </summary>
    public class AppIdentityDbContext : IdentityDbContext<AppUser>
    {
        public AppIdentityDbContext() : base("IdentityDb") { }      //连接数据库名

        static AppIdentityDbContext()
        {
            Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());        //指定数据库构造内容，当首次创建数据库时
        }

        public static AppIdentityDbContext Create()
        {
            return new AppIdentityDbContext();      //生成实例，供owin使用
        }
    }



    public class IdentityDbInit : NullDatabaseInitializer<AppIdentityDbContext>
    {
    }


    //public class IdentityDbInit : DropCreateDatabaseIfModelChanges<AppIdentityDbContext>     //创建或删除数据库的具体类
    //{
    //    protected override void Seed(AppIdentityDbContext context)
    //    {
    //        PerformInitialSetup(context);           //追加初始化特性
    //        base.Seed(context);
    //    }

    //    public void PerformInitialSetup(AppIdentityDbContext context)
    //    {
    //        // 添加具体的初始化特性
    //        AppUserManager userMgr = new AppUserManager(new UserStore<AppUser>(context));
    //        AppRoleManager roleMgr = new AppRoleManager(new RoleStore<AppRole>(context));
    //        string roleName = "Administrators";
    //        string userName = "Admin";
    //        string password = "MySecret";
    //        string email = "admin@example.com";
    //        if (!roleMgr.RoleExists(roleName))
    //        {
    //            roleMgr.Create(new AppRole(roleName));
    //        }
    //        AppUser user = userMgr.FindByName(userName);
    //        if (user == null)
    //        {
    //            userMgr.Create(
    //                new AppUser 
    //                { 
    //                    UserName = userName, 
    //                    Email = email 
    //                },
    //                password);
    //            user = userMgr.FindByName(userName);
    //        }
    //        if (!userMgr.IsInRole(user.Id, roleName))
    //        {
    //            userMgr.AddToRole(user.Id, roleName);
    //        }
    //    }
    //}

}