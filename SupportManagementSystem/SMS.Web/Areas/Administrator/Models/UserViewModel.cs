namespace SMS.Web.Areas.Administrator.Models
{
    using SMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class UserViewModel
    {
        public UserViewModel()
        {
            this.Roles = new List<string>();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Availability { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public ICollection<string> Roles { get; set; }

        public static Expression<Func<SupportAgent, UserViewModel>> Create
        {
            get
            {
                return u => new UserViewModel
                {
                    Id = u.Id,
                    Email = u.Email,
                    PhoneNumber = u.PhoneNumber,
                    Availability = u.Availability.AvailabilityName,
                    From = u.AvailableFrom,
                    To = u.AvailableTo
                };
            }
        }

    }
}