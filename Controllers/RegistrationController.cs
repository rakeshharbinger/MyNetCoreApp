using Microsoft.AspNetCore.Mvc;
using MyNetCoreApp.Models;
using MyNetCoreApp.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace MyNetCoreApp.Controllers
{
    public class RegistrationController : Controller
    {
        private readonly IUserRepos _userRepos;
        public RegistrationController(IUserRepos userRepos)
        {
            _userRepos = userRepos;
        }

        // GET: RegistrationController
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(User user)
        {
            if (ModelState.IsValid)
            {
                _userRepos.Register(user);
            }
            return View();
        }

        // GET: RegistrationController/Details/5
        public IActionResult Details(int id)
        {
            return View();
        }

        // GET: RegistrationController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrationController/Create
       

        //// GET: RegistrationController/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    return View();
        //}

        //// POST: RegistrationController/Edit/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Edit(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}

        //// GET: RegistrationController/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        //// POST: RegistrationController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Delete(int id, IFormCollection collection)
        //{
        //    try
        //    {
        //        return RedirectToAction(nameof(Index));
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
    }
}
