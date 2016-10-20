namespace SMS.Web.Areas.Administrator.Controllers
{

    using SMS.Web.Controllers;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    public class AdminController : BaseController
    {
        // GET: Administrator/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}