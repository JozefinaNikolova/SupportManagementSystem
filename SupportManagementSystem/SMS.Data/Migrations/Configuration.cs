namespace SMS.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using SMS.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public sealed class Configuration : DbMigrationsConfiguration<SMSContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SMSContext context)
        {
            if (!context.Users.Any())
            {
                var adminEmail = "admin@admin.com";
                var adminUsername = adminEmail;
                var adminPhoneNumber = "07001700";
                var adminPassword = "123456";
                string adminRole = "Administrator";
                CreateAdminUser(context, adminEmail, adminUsername, adminPhoneNumber, adminPassword, adminRole);
            }

            if(!context.Availabilities.Any())
            {
                context.Availabilities.Add(new Availability { AvailabilityName = "Primary Support" });
                context.Availabilities.Add(new Availability { AvailabilityName = "Secondary Support" });
                context.Availabilities.Add(new Availability { AvailabilityName = "Generally Available" });
                context.Availabilities.Add(new Availability { AvailabilityName = "Unavailable" });
            }

            context.SaveChanges();
        }

        private void CreateAdminUser(SMSContext context, string adminEmail, string adminUsername, string adminPhoneNumber, string adminPassword, string adminRole)
        {
            var adminUser = new SupportAgent
            {
                UserName = adminUsername,
                Email = adminEmail,
                PhoneNumber = adminPhoneNumber
            };

            var userStore = new UserStore<SupportAgent>(context);
            var userManager = new UserManager<SupportAgent>(userStore);

            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 1,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false
            };

            var userCreateResult = userManager.Create(adminUser, adminPassword);
            if (!userCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", userCreateResult.Errors));
            }

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var roleCreateResult = roleManager.Create(new IdentityRole(adminRole));
            if (!roleCreateResult.Succeeded)
            {
                throw new Exception(string.Join("; ", roleCreateResult.Errors));
            }

            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }
        }
    }
}
