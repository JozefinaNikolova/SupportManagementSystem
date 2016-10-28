namespace SMS.Web.Areas.Administrator.Controllers
{
    using SMS.Models;
    using SMS.Web.Areas.Administrator.Models;
    using SMS.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    public class ReportController : BaseController
    {
        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public ActionResult Create(ReportViewModel model)
        {
            var supportAgentAvailabilities = this.Data.SupportAgentsAvailabilities
                .All()
                .Where(x => x.StartTime >= model.StartTime && x.EndTime <= model.EndTime);


            var report = new Report
            {
                StartTime = model.StartTime,
                EndTime = model.StartTime,
                SupportAgentsAvailabilities = supportAgentAvailabilities
            };

            this.Data.Reports.Add(report);
            this.Data.SaveChanges();

            return this.View();
        }
    }
}