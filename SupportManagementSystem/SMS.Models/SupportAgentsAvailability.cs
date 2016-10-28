namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    public class SupportAgentsAvailability
    {
        private ICollection<Report> reports;

        public SupportAgentsAvailability()
        {
            this.reports = new List<Report>();
        }

        public int Id { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }

        public string SupportAgentId { get; set; }

        public int AvailabilityId { get; set; }

        public virtual SupportAgent SupportAgent { get; set; }

        public virtual Availability Availability { get; set; }

        public virtual ICollection<Report> Reports
        {
            get { return this.reports; }
            set { this.reports = value; }
        }
    }
}
