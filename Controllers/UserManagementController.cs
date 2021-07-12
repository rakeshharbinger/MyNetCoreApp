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
            return View();
        }

        [HttpPost]
        public IActionResult LoadUser()
        {
            var draw = HttpContext.Request.Form["draw"].FirstOrDefault();

            // Skip number of Rows count  
            var start = Request.Form["start"].FirstOrDefault();

            // Paging Length 10,20  
            var length = Request.Form["length"].FirstOrDefault();

            // Sort Column Name  
            var sortColumn = Request.Form["columns[" + Request.Form["order[0][column]"].FirstOrDefault() + "][name]"].FirstOrDefault();

            // Sort Column Direction (asc, desc)  
            var sortColumnDirection = Request.Form["order[0][dir]"].FirstOrDefault();

            // Search Value from (Search box)  
            var searchValue = Request.Form["search[value]"].FirstOrDefault();

            //Paging Size (10, 20, 50,100)  
            int pageSize = length != null ? Convert.ToInt32(length) : 0;

            int skip = start != null ? Convert.ToInt32(start) : 0;

            int recordsTotal = 0;

            // getting all Customer data  
            var userData = _userRepos.GetUserList();
            //Sorting
            //if (!(string.IsNullOrEmpty(sortColumn) && string.IsNullOrEmpty(sortColumnDirection)))
            //{
            //    userData = userData.OrderBy(sortColumn + " " + sortColumnDirection);
            //}
            //Search  
            if (!string.IsNullOrEmpty(searchValue))
            {
                userData = userData.Where(m => m.FirstName == searchValue);
            }

            //total number of rows counts   
            recordsTotal = userData.Count();
            //Paging   
            var data = userData.Skip(skip).Take(pageSize).ToList();
            //Returning Json Data  
            var jsonData = new { draw = draw, recordsFiltered = recordsTotal, recordsTotal = recordsTotal, data = data };
            return Ok(jsonData);
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
            User user = _userRepos.GetUser(id);
            return View(user);
        }

        // POST: UserManagementController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            _userRepos.EditUser(user);
            return Json(new { success = true, responseText = "Edited Successfullly" });
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
