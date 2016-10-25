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
        private const string DefaultAdminEmail = "admin@admin.com";
        private const string DefaultAdminPhoneNumber = "07001700";
        private const string DefaultAdminPassword = "123456";

        private const string AdministratorRoleName = "Administrator";
        private const string SupportAgentRoleName = "Support Agent";
        private const string CustomerRoleName = "Customer";

        private const string PrimarySupportName = "Primary Support";
        private const string SecondarySupportName = "Secondary Support";
        private const string GenerallyAvailableName = "Generally Available";
        private const string UnavailableName = "Unavailable";

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

                var adminEmail = DefaultAdminEmail;
                var adminUsername = adminEmail;
                var adminPhoneNumber = DefaultAdminPhoneNumber;
                var adminPassword = DefaultAdminPassword;
                var adminRole = AdministratorRoleName;
                var adminAvailabilityId = context.Availabilities.Where(a => a.AvailabilityName == UnavailableName).FirstOrDefault().Id;

                CreateAdminUser(context, adminEmail, adminUsername, adminPhoneNumber, adminPassword, adminRole, adminAvailabilityId);
            }

            
        }

        private void CreateUserRoles(SMSContext context)
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            roleManager.Create(new IdentityRole(AdministratorRoleName));
            roleManager.Create(new IdentityRole(SupportAgentRoleName));
            roleManager.Create(new IdentityRole(CustomerRoleName));

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
            context.Availabilities.Add(new Availability { AvailabilityName = PrimarySupportName });
            context.Availabilities.Add(new Availability { AvailabilityName = SecondarySupportName });
            context.Availabilities.Add(new Availability { AvailabilityName = GenerallyAvailableName });
            context.Availabilities.Add(new Availability { AvailabilityName = UnavailableName });

            context.SaveChanges();
        }
    }
}
