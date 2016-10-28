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
                .Where(x => x.StartTime >= model.StartTime && x.EndTime <= model.EndTime)
                .ToList();


            var report = new Report
            {
                StartTime = model.StartTime,
                EndTime = model.EndTime,
                SupportAgentsAvailabilities = supportAgentAvailabilities
            };

            this.Data.Reports.Add(report);
            this.Data.SaveChanges();

            return this.RedirectToAction("All");
        }

        [HttpGet]
        public ActionResult All()
        {
            var reports = this.Data.Reports
                .All()
                .OrderByDescending(r => r.Id)
                .Select(ReportViewModel.Create).ToList();

            return this.View(reports);
        }
    }
}