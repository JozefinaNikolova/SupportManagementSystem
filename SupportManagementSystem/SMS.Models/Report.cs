namespace SMS.Models
{
    using System;
    using System.Collections.Generic;
    public class Report
    {
        private ICollection<SupportAgentsAvailability> supportAgentsAvailabilities;

        public Report()
        {
            this.supportAgentsAvailabilities = new HashSet<SupportAgentsAvailability>();
        }

        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual ICollection<SupportAgentsAvailability> SupportAgentsAvailabilities
        {
            get { return this.supportAgentsAvailabilities; }
            set { this.supportAgentsAvailabilities = value; }
        }
    }
}
