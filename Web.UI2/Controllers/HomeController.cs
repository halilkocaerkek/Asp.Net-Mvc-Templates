﻿using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.UI2.Controllers
{
    public class HomeController : Controller
    {
        private ddsport db = new ddsport();

        public ActionResult Dashboard()
        {
  
            // ViewBag.ProductCount = db.Products.Count();
            //ViewBag.OrderCount = db.Orders.Count();
            // ViewBag.OrderSum = db.Order_Details.Sum(o => o.Quantity * o.UnitPrice);
            //ViewBag.CustomerCount = db.Customers.Count();
            //ViewBag.EmployeeCount = db.Employees.Count();
            return View();
            
        }

        public ActionResult Index()
        {
            ViewData["SubTitle"] = "Welcome in ASP.NET MVC 5 INSPINIA SeedProject ";
            ViewData["Message"] = "It is an application skeleton for a typical MVC 5 project. You can use it to quickly bootstrap your webapp projects.";

            return View();
        }

        public ActionResult Minor()
        {
            ViewData["SubTitle"] = "Simple example of second view";
            ViewData["Message"] = "Data are passing to view by ViewData from controller";

            return View();
        }
    }
}