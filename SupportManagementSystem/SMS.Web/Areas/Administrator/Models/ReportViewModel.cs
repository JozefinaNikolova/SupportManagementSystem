namespace SMS.Web.Areas.Administrator.Models
{
    using SMS.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;

    public class ReportViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public IEnumerable<SupportAgentsAvailabilityViewModel> SupportAgentsAvailabilities { get; set; }

        public static Expression<Func<Report, ReportViewModel>> Create
        {
            get
            {
                return r => new ReportViewModel
                {
                    Id = r.Id,
                    StartTime = r.StartTime,
                    EndTime = r.EndTime,
                    SupportAgentsAvailabilities = r.SupportAgentsAvailabilities
                            .AsEnumerable()
                            .Select(s => new SupportAgentsAvailabilityViewModel
                            {
                                SupportAgentId = s.SupportAgentId,
                                Email = s.SupportAgent.Email,
                                Availability = s.Availability.AvailabilityName,
                                From = s.StartTime,
                                To = s.EndTime
                            })
                };
            }
        }
    }
}