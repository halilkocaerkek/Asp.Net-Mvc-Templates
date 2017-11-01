
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
    public class classstudentsController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /classstudents/
        public ActionResult Index(int? page)
        {
            var classstudent = db.classstudents.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfclassstudent = classstudent.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfclassstudent = onePageOfclassstudent;

           // return View(db.classstudents.ToList());
		     return View( );
        }

        // GET: /classstudents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classstudent classstudent = db.classstudents.Find(id);
            if (classstudent == null)
            {
                return HttpNotFound();
            }
            return View(classstudent);
        }

        // GET: /classstudents/Create
        public ActionResult Create()
        {
            ViewBag.studentid = new SelectList(db.students.GetAll(), "id", "name");
            return View();
        }

        // POST: /classstudents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,studentid,discount,version,createdAt,updatedAt,deleted")] classstudent classstudent)
        {
            if (ModelState.IsValid)
            {
                db.classstudents.Add(classstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.studentid = new SelectList(db.students.GetAll(), "id", "name", classstudent.studentid);
            return View(classstudent);
        }

        // GET: /classstudents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classstudent classstudent = db.classstudents.Find(id);
            if (classstudent == null)
            {
                return HttpNotFound();
            }
            ViewBag.studentid = new SelectList(db.students.GetAll(), "id", "name", classstudent.studentid);
            return View(classstudent);
        }

        // POST: /classstudents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,studentid,discount,version,createdAt,updatedAt,deleted")] classstudent classstudent)
        {
            if (ModelState.IsValid)
            {
              
			   db.classstudents.Add(classstudent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.studentid = new SelectList(db.students.GetAll(), "id", "name", classstudent.studentid);
            return View(classstudent);
        }

        // GET: /classstudents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classstudent classstudent = db.classstudents.Find(id);
            if (classstudent == null)
            {
                return HttpNotFound();
            }
            return View(classstudent);
        }

        // POST: /classstudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            classstudent classstudent = db.classstudents.Find(id);
            db.classstudents.Remove(classstudent);
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
