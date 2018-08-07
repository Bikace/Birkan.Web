using DenemeProje.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DenemeProje.Identity
{
    public class IdentityInitializer:DropCreateDatabaseAlways<IdentityDataContext>
    {
        protected override void Seed(IdentityDataContext context)
        {
            //Rolleri
            if(!context.Roles.Any(i => i.Name == "admin"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "admin", Description = "yönetici rolü" };

                manager.Create(role);
            }

            if (!context.Roles.Any(i => i.Name == "user"))
            {
                var store = new RoleStore<ApplicationRole>(context);
                var manager = new RoleManager<ApplicationRole>(store);

                var role = new ApplicationRole() { Name = "user", Description = "user rolü" };

                manager.Create(role);
            }

            //Userlar

            if (!context.Users.Any(i => i.Name == "Bikace"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "birkan",
                    Surname = "Köse",
                    UserName = "Bikace",
                    Email = "bikace95@gmail.com"
                };
                manager.Create(user,"123456");
                manager.AddToRole(user.Id, "admin");
                manager.AddToRole(user.Id, "user");
            }
            if (!context.Users.Any(i => i.Name == "Bikace2"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    Name = "birkan2",
                    Surname = "Köse2",
                    UserName = "Bikace2",
                    Email = "bikace952@gmail.com"
                };
                manager.Create(user, "123456");
                manager.AddToRole(user.Id, "user");
            }


            base.Seed(context);
        }
    }
}