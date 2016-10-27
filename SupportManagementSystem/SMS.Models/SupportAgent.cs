namespace SMS.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class SupportAgent : IdentityUser
    {
        private ICollection<SupportAgentsAvailability> supportAgentsAvailabilities;

        public SupportAgent()
        {
            this.supportAgentsAvailabilities = new HashSet<SupportAgentsAvailability>();
        }

        public int AvailabilityId { get; set; }

        public DateTime? AvailableFrom { get; set; }

        public DateTime? AvailableTo { get; set; }

        public virtual Availability Availability { get; set; }

        public virtual ICollection<SupportAgentsAvailability> SupportAgentAvailabilities
        {
            get { return this.supportAgentsAvailabilities; }
            set { this.supportAgentsAvailabilities = value; }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SupportAgent> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
