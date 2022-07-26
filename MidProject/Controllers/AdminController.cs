using MidProject.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MidProject.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var data = (from u in db.Users
                        where u.Role == "Buyer"
                        select u).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Create(User u)
        {
            if (ModelState.IsValid)
            {
                EE_StoreEntities db = new EE_StoreEntities();
                db.Users.Add(u);
                db.SaveChanges();
                return RedirectToAction("Users");
            }
            return View();
        }
        public ActionResult Users()
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var data = db.Users.ToList();
            return View(data);
        }

        public ActionResult Buyers()
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var data = (from u in db.Users
                       where u.Role == "Buyer"
                       select u).ToList();
            return View(data);
        }

        public ActionResult Products()
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var data = (from u in db.Products
                        select u).ToList();
            return View(data);
        }

        [HttpGet]
        public ActionResult EditUser(int id)
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var user = (from u in db.Users
                           where u.Id == id
                           select u).FirstOrDefault();
            return View(user);
        }

        [HttpPost]

        public ActionResult EditUser(User eu)
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var user = (from u in db.Users
                        where u.Id == eu.Id
                        select u).FirstOrDefault();

            db.Entry(user).CurrentValues.SetValues(eu);
            db.SaveChanges();
            return RedirectToAction("Users");
        }

        [HttpGet]
        public ActionResult DeleteUser(int id)
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var user = (from u in db.Users
                        where u.Id == id
                        select u).FirstOrDefault();
            db.Users.Remove(user);
            db.SaveChanges();

            return RedirectToAction("Users");
        }

        public ActionResult PaySallery()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Products(string searchString)
        {
            EE_StoreEntities db = new EE_StoreEntities();
            var data = (from m in db.Products
                        select m).ToList();



            if (!String.IsNullOrEmpty(searchString))
            {
                data = (from u in db.Products
                        where (u.Name.Contains(searchString) || u.Description.Contains(searchString))
                        select u).ToList();
            }



            return View(data);
        }
    }
}