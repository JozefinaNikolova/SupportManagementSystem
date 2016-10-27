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
        public ActionResult Users()
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

        [HttpGet]
        public ActionResult EditPhone(string id)
        {
            var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == id)
                .Select(EditUserViewModel.Create)
                .FirstOrDefault();

            return this.View(user);
        }

        [HttpPost]
        public ActionResult EditPhone(EditUserViewModel model)
        {
            var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == model.Id)
                .FirstOrDefault();

            user.PhoneNumber = model.PhoneNumber;

            this.Data.SaveChanges();

            return this.RedirectToAction("Users", "Admin", new { area = "Administrator" });
        }

        [HttpGet]
        public ActionResult EditAvailability(string id)
        {
             var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == id)
                .Select(EditUserViewModel.Create)
                .FirstOrDefault();

            user.PossibleAvailabilities = this.Data.Availabilities.All().Select(a => a.AvailabilityName);

            return this.View(user);
        }

        [HttpPost]
        public ActionResult EditAvailability(EditUserViewModel model)
        {
            var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == model.Id)
                .FirstOrDefault();

            var availability = this.Data.Availabilities
                .All()
                .Where(a => a.AvailabilityName == model.Availability)
                .FirstOrDefault();

            user.Availability = availability;
            user.AvailableFrom = model.From;
            user.AvailableTo = model.To;

            var supportAgentAvailability = new SupportAgentsAvailability
            {
                AvailabilityId = availability.Id,
                SupportAgentId = model.Id,
                StartTime = model.From,
                EndTime = model.To
            };

            this.Data.SupportAgentsAvailabilities.Add(supportAgentAvailability);

            this.Data.SaveChanges();

            return this.RedirectToAction("Users", "Admin", new { area = "Administrator" });
        
        }

        [HttpGet]
        public ActionResult EditEmail(string id)
        {
            var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == id)
                .Select(EditUserViewModel.Create)
                .FirstOrDefault();

            return this.View(user);
        }

        [HttpPost]
        public ActionResult EditEmail(EditUserViewModel model)
        {
            var user = this.Data.SupportAgents
                .All()
                .Where(u => u.Id == model.Id)
                .FirstOrDefault();

            user.Email = model.Email;

            this.Data.SaveChanges();

            return this.RedirectToAction("Users", "Admin", new { area = "Administrator" });
        }


        public ActionResult UserProfile(string id)
        {
            string userId = id;
            var users = this.Data.SupportAgents
               .All()
               .Where(a => a.Id == userId)
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