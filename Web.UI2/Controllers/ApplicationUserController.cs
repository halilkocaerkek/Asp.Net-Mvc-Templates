using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.UI2.Models;

namespace Web.UI2.Controllers
{
    public class ApplicationUserController : Controller
    {
        ApplicationDbContext context;

        public ApplicationUserController()
        {
            context = new ApplicationDbContext();
        }

        // GET: ApplicationUser
        public ActionResult Index()
        {
            
            return View(context.Users.ToList());
        }

        // GET: ApplicationUser/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: ApplicationUser/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ApplicationUser/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUser/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: ApplicationUser/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: ApplicationUser/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ApplicationUser/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
