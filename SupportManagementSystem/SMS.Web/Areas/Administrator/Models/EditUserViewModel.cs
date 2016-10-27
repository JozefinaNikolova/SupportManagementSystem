namespace SMS.Web.Areas.Administrator.Models
{
    using SMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    public class EditUserViewModel
    {
        public EditUserViewModel()
        {
            this.PossibleAvailabilities = new List<string>();
        }

        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string Availability { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public IEnumerable<string> PossibleAvailabilities { get; set; }

        public static Expression<Func<SupportAgent, EditUserViewModel>> Create
        {
            get
            {
                return u => new EditUserViewModel
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