namespace WebUI.Admin.Migrations
{
    using System;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<WebUI.Admin.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebUI.Admin.Models.ApplicationDbContext context)
        {
            var userManager = new ApplicationUserManager(new UserStore<Models.ApplicationUser>(context));

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleAdmin = new IdentityRole { Name = "Admin" };
            var roleContent = new IdentityRole { Name = "ContentManager" };
            roleManager.Create(roleAdmin);
            roleManager.Create(roleContent);

            var admin = new Models.ApplicationUser { Email = "zilmmz554@yandex.ua", UserName = "SupaAdmin" };
            string password = "1234567";
            var result = userManager.Create(admin, password);

            if (result.Succeeded)
            {
                userManager.AddToRole(admin.Id, roleAdmin.Name);
                userManager.AddToRole(admin.Id, roleContent.Name);
            }

            base.Seed(context);
        }
    }
}
