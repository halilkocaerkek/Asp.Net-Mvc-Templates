
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PagedList;
using DataModel;

namespace Web.UI2.Controllers
{
    public class beltColorsController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /beltColors/
        public ActionResult Index(int? page)
        {
            var beltcolor = db.beltColors.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfbeltColor = beltcolor.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfbeltColor = onePageOfbeltColor;

           // return View(db.beltColors.ToList());
		     return View( );
        }

        // GET: /beltColors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beltColor beltColor = db.beltColors.Find(id);
            if (beltColor == null)
            {
                return HttpNotFound();
            }
            return View(beltColor);
        }

        // GET: /beltColors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /beltColors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,value,version,createdAt,updatedAt,deleted")] beltColor beltColor)
        {
            if (ModelState.IsValid)
            {
                db.beltColors.Add(beltColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(beltColor);
        }

        // GET: /beltColors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beltColor beltColor = db.beltColors.Find(id);
            if (beltColor == null)
            {
                return HttpNotFound();
            }
            return View(beltColor);
        }

        // POST: /beltColors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,value,version,createdAt,updatedAt,deleted")] beltColor beltColor)
        {
            if (ModelState.IsValid)
            {
              
			   db.beltColors.Add(beltColor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(beltColor);
        }

        // GET: /beltColors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            beltColor beltColor = db.beltColors.Find(id);
            if (beltColor == null)
            {
                return HttpNotFound();
            }
            return View(beltColor);
        }

        // POST: /beltColors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            beltColor beltColor = db.beltColors.Find(id);
            db.beltColors.Remove(beltColor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
