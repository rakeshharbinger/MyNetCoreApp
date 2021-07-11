using Microsoft.AspNetCore.Http;
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
                    HttpContext.Session.SetString("FullName", user.FirstName + " " + user.LastName);
                    return Json(new { success = true, responseText = "valid user" });
                }
                else
                {
                    return Json(new { success = false, responseText = "invalid user" });
                }
            }
            else
            {
                return Json(new { success = false, responseText = "Invalid login form" });
            }

        }

        [HttpPost]
        public JsonResult Logout()
        {
            HttpContext.Session.Clear();
            return Json(new { success = true });
        }
    }
}
