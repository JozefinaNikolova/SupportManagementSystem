namespace SMS.Web.Areas.Administrator.Controllers
{

    using SMS.Web.Controllers;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using SMS.Data;
    using SMS.Web.Areas.Administrator.Models;
    using System.Web.Security;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.AspNet.Identity;
    using SMS.Models;

    [Authorize(Roles = "Administrator")]
    public class AdminController : BaseController
    {
        public ActionResult Panel()
        {
            var users = this.Data.SupportAgents
                .All()
                .Select(UserViewModel.Create).ToList();

            foreach (var user in users)
            {
                var supportAgent = this.Data.SupportAgents.All().Where(a => a.Id == user.Id).FirstOrDefault();
                var roles = supportAgent.Roles;

                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(new SMSContext()));
                

                foreach (var role in roles)
	            {
                    var currentRole = roleManager.FindById(role.RoleId);
                    user.Roles.Add(currentRole.Name);
	            }
                
            }

            return View(users);
        }
       
    }
}