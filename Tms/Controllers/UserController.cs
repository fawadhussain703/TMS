using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tms.Models;
using Tms.Service.Maintenance;
using Tms.Service.User;

namespace Tms.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {

        private readonly UserService _userService;
  
        public UserController()
        {

        }

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: User
        public ActionResult List()
        {
            var users = _userService.GetAllUsers();





            var data = users.Select(user => new UserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                
                RoleId = user.AspNetUserRoles != null && user.AspNetUserRoles.Any()
                            ? user.AspNetUserRoles.FirstOrDefault()?.RoleId
                            : null
            }).ToList();

            return View(data);
        }
        [HttpPost]
        public ActionResult MakeSupervisor(string userId)
        {
            var result = _userService.UpdateUserRole(userId, "2"); 
            if (result)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult RemoveSupervisor(string userId)
        {
            var result = _userService.UpdateUserRole(userId, "3"); 
            if (result)
            {
                return Json(new { success = true });
            }

            return Json(new { success = false });
        }
    }
}