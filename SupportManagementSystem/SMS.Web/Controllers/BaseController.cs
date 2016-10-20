namespace SMS.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using SMS.Data;
    using SMS.Models;

    public abstract class BaseController : Controller
    {
        private ISMSData data;
        private SupportAgent userProfile;

        protected BaseController(ISMSData data)
        {
            this.data = data;
        }

        protected BaseController(ISMSData data, SupportAgent userProfile)
            : this(data)
        {
            this.userProfile = userProfile;
        }

        protected BaseController()
            : this(new SMSData(new SMSContext()))
        {
        }

        public ISMSData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        public SupportAgent UserProfile
        {
            get { return this.userProfile; }
            private set { this.userProfile = value; }
        }

        public bool isAdmin()
        {
            if (this.userProfile != null && this.User.IsInRole("Administrator"))
            {
                return true;
            }

            return false;
        }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.SupportAgents.All().FirstOrDefault(u => u.UserName == username);

                this.userProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}