namespace SMS.Web.Areas.Administrator.Models
{
    using System;
    public class SupportAgentsAvailabilityViewModel
    {
        public string SupportAgentId { get; set; }

        public string Email { get; set; }

        public string Availability { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }
    }
}