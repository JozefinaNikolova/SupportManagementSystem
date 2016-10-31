namespace SMS.Web.Areas.Administrator.Models
{
    using SMS.Models;
    using System;
    using System.Linq.Expressions;
    public class SupportAgentsAvailabilityViewModel
    {
        public string SupportAgentId { get; set; }

        public string Email { get; set; }

        public string Availability { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public static Expression<Func<SupportAgentsAvailability, SupportAgentsAvailabilityViewModel>> Create
        {
            get
            {
                return s => new SupportAgentsAvailabilityViewModel
                {
                    SupportAgentId = s.SupportAgentId,
                    Email = s.SupportAgent.Email,
                    Availability = s.Availability.AvailabilityName,
                    From = s.StartTime,
                    To = s.EndTime
                };
            }
        }
    }
}