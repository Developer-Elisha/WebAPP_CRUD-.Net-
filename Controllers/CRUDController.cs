using CRUD_AspDotNet.DB_Context;
using CRUD_AspDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CRUD_AspDotNet.Controllers
{
    public class CRUDController : Controller
    {
        SqlContext sc;
        public CRUDController(SqlContext sc1)
        {
            this.sc = sc1;
        }

        public IActionResult add_user()
        {
            return View();
        }

        [HttpPost]
        public IActionResult add_user(User us)
        {
            if (us == null || string.IsNullOrEmpty(us.Name) || string.IsNullOrEmpty(us.LastName))
            {
                ModelState.AddModelError(string.Empty, "Name and LastName are required.");
                return View(us);
            }
            sc.Add(us);
            sc.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("FetchUser");
        }

        public IActionResult FetchUser()
        {
            var us = sc.tblusers.ToList();
            return View(us);
        }

        public IActionResult deleteuser(int id)
        {
            var us = sc.tblusers.Find(id);
            if (us == null)
            {
                return RedirectToAction("error404");
            }

            sc.tblusers.Remove(us);
            sc.SaveChanges();
            return RedirectToAction("FetchUser");
        }

        public IActionResult edit_user(int id)
        {
            var us = sc.tblusers.Find(id);
            if (us == null)
            {
                return RedirectToAction("error404");
            }
            return View(us);
        }

        [HttpPost]
        public IActionResult edit_user(User user)
        {
            if (user == null || user.Id <= 0 || string.IsNullOrEmpty(user.Name) || string.IsNullOrEmpty(user.LastName))
            {
                ModelState.AddModelError(string.Empty, "Invalid data.");
                return View(user);
            }

            var existingUser = sc.tblusers.Find(user.Id);
            if (existingUser == null)
            {
                return RedirectToAction("error404");
            }

            existingUser.Name = user.Name;
            existingUser.LastName = user.LastName;
            // Update other fields as needed

            sc.SaveChanges();
            return RedirectToAction("FetchUser");
        }
    }
}
