namespace SMS.Web.Areas.Administrator
{
    using SMS.Web.Areas.Administrator.Controllers;
    using System.Web.Mvc;

    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator_Admin",
                "Administrator/{action}/{id}",
                new { controller = "Admin", action = "Index", id = UrlParameter.Optional },
                new { isMethodInHomeController = new RootRouteConstraint<AdminController>() }
            );

            context.MapRoute(
                "Administrator_default",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}