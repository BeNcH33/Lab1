using Lab1.Models.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab1
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            MyIdentityDbContext db = new MyIdentityDbContext();
            RoleStore<MyIdentityRole> roleStore = new RoleStore<MyIdentityRole>(db);
            RoleManager<MyIdentityRole> roleManager = new RoleManager<MyIdentityRole>(roleStore);
            if (!roleManager.RoleExists("Administrator"))
            {
                MyIdentityRole newRole = new MyIdentityRole("Administrator", "Администратор обладает полными правами в системе");
                roleManager.Create(newRole);
            }
            if (!roleManager.RoleExists("Operator"))
            {
                MyIdentityRole newRole = new MyIdentityRole("Operator", "Операторы могут только добавлять и изменять данные в системе");
                roleManager.Create(newRole);
            }
            if (!roleManager.RoleExists("Student"))
            {
                MyIdentityRole newRole = new MyIdentityRole("Student", "Студенты могут просматривать данные о нарушениях");
                roleManager.Create(newRole);
            }
            if (!roleManager.RoleExists("Boss"))
            {
                MyIdentityRole newRole = new MyIdentityRole("Boss", "Директор млжет просматривать всё!");
                roleManager.Create(newRole);
            }
        }
    }
}
