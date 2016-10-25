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
            if (!context.Availabilities.Any())
            {
                AddAvailabilities(context);
            }

            if (!context.Users.Any())
            {
                CreateUserRoles(context);

                var adminEmail = "admin@admin.com";
                var adminUsername = adminEmail;
                var adminPhoneNumber = "07001700";
                var adminPassword = "123456";
                var adminRole = "Administrator";
                var adminAvailabilityId = context.Availabilities.Where(a => a.AvailabilityName == "Unavailable").FirstOrDefault().Id;

                CreateAdminUser(context, adminEmail, adminUsername, adminPhoneNumber, adminPassword, adminRole, adminAvailabilityId);
            }

            
        }

        private void CreateUserRoles(SMSContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole("Administrator"));
            roleManager.Create(new IdentityRole("Support Agent"));
            roleManager.Create(new IdentityRole("Customer"));

            context.SaveChanges();
        }

        private void CreateAdminUser(SMSContext context, string adminEmail, string adminUsername, string adminPhoneNumber, string adminPassword, string adminRole, int adminAvailabilityId)
        {
            var adminUser = new SupportAgent
            {
                UserName = adminUsername,
                Email = adminEmail,
                PhoneNumber = adminPhoneNumber,
                AvailabilityId = adminAvailabilityId
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

            var addAdminRoleResult = userManager.AddToRole(adminUser.Id, adminRole);
            if (!addAdminRoleResult.Succeeded)
            {
                throw new Exception(string.Join("; ", addAdminRoleResult.Errors));
            }

            context.SaveChanges();
        }

        private void AddAvailabilities(SMSContext context)
        {
            context.Availabilities.Add(new Availability { AvailabilityName = "Primary Support" });
            context.Availabilities.Add(new Availability { AvailabilityName = "Secondary Support" });
            context.Availabilities.Add(new Availability { AvailabilityName = "Generally Available" });
            context.Availabilities.Add(new Availability { AvailabilityName = "Unavailable" });

            context.SaveChanges();
        }
    }
}
