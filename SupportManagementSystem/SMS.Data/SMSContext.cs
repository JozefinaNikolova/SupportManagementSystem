namespace SMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using SMS.Models;
    using SMS.Data.Migrations;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SMSContext : IdentityDbContext<SupportAgent>
    {
        public SMSContext()
            : base("name=SMSContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<SMSContext, Configuration>());
        }

        public IDbSet<Availability> Availabilities { get; set; }
        public IDbSet<CallSettings> CallSettings { get; set; }
        public IDbSet<Report> Reports { get; set; }
        public IDbSet<SupportAgentsAvailability> SupportAgentsAvailabilities { get; set; }

        public static SMSContext Create()
        {
            return new SMSContext();
        }
    }
}