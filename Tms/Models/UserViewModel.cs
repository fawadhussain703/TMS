using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tms.Models
{
    public class UserViewModel
    {


        public string Email { get; set; }
        public string UserName { get; set; }

        public string UserId { get; set; }

        public string Role { get; set; }
        public string RoleId { get; set; }
    }
}