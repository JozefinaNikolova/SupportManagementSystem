namespace SMS.Models
{
    using System;
    public class SupportAgentsAvailability
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string SupportAgentId { get; set; }

        public int AvailabilityId { get; set; }

        public virtual SupportAgent SupportAgent { get; set; }

        public virtual Availability Availability { get; set; }
    }
}
