namespace SMS.Models
{
    using System;
    public class SupportAgentsAvailability
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public SupportAgent SupportAgent { get; set; }

        public Availability Availability { get; set; }
    }
}
