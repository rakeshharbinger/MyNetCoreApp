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
    public class UserManagementController : Controller
    {
        private readonly IUserRepos _userRepos;  
        public UserManagementController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }
        // GET: UserManagementController
        public ActionResult Index()
        {
            List<User> users = _userRepos.GetUserList();
            return View();
        }

        // GET: UserManagementController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: UserManagementController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserManagementController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagementController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: UserManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UserManagementController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: UserManagementController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
