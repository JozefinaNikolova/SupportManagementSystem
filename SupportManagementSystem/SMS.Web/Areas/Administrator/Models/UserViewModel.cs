using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SMS.Web.Areas.Administrator.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Availability { get; set; }

    }
}