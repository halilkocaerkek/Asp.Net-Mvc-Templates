using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI.Controllers
{
    public class HomeController : Controller
    {
        private NorthwindModel db = new NorthwindModel();

        public ActionResult Dashboard()
        {
            ViewBag.ProductCount = db.Products.Count();
            ViewBag.OrderCount = db.Orders.Count();
            ViewBag.CustomerCount = db.Customers.Count();
            ViewBag.EmployeeCount = db.Employees.Count();
            return View();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}