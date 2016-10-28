namespace SMS.Web.Areas.Administrator.Models
{
    using System;

    public class CreateReportViewModel
    {
        public int Id { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
    }
}