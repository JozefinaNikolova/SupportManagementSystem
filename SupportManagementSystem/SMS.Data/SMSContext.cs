namespace SMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SMS.Models;
    using SMS.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SMSContext : IdentityDbContext<IdentityUser>
    {
        public SMSContext()
            : base("name=SMSContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SMSContext, Configuration>());
        }

        public virtual DbSet<Availability> Availabilities { get; set; }
        public virtual DbSet<CallSettings> CallSettings { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<SupportAgentsAvailability> SupportAgentsAvailabilities { get; set; }

        public static SMSContext Create()
        {
            return new SMSContext();
        }
    }
}