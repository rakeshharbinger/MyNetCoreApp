using Microsoft.AspNetCore.Mvc;
using MyNetCoreApp.Models;
using MyNetCoreApp.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyNetCoreApp.Controllers
{
    public class LoginLogoutController : Controller
    {
        private readonly IUserRepos _userRepos;
        public LoginLogoutController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Index(UserLogin cred)
        {
            if (ModelState.IsValid)
            {
                User user = _userRepos.Validate(cred);
                if (user.UserId > 0)
                {
                    return Json(new {success = true, responseText = user.FirstName + " " + user.LastName});
                }
                else
                {
                    return Json(new { success = true, responseText = "invalid user" });
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Invalid login form" });
            }

        }
    }
}
