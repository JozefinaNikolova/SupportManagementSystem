namespace SMS.Models
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class SupportAgent : IdentityUser
    {
        public int? AvailabilityId { get; set; }

        public virtual Availability Availability { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<SupportAgent> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}
