namespace SMS.Data
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SMSContext : IdentityDbContext<IdentityUser>
    {
        public SMSContext()
            : base("name=SMSContext")
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<SMSContext, Configuration>());
        }

        // public virtual DbSet<MyEntity> MyEntities { get; set; }
    }
}