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
            return this.RedirectToAction("Details", model);
        }

        [HttpGet]
        public ActionResult Details(ReportViewModel model)
        {
            model.SupportAgentsAvailabilities = this.Data.SupportAgentsAvailabilities
                .All()
                .Where(x => x.StartTime >= model.StartTime && x.EndTime <= model.EndTime)
                .Select(SupportAgentsAvailabilityViewModel.Create);

            return this.View(model);
        }
    }
}