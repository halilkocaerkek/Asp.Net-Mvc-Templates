
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
    public class teachersController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /teachers/
        public ActionResult Index(int? page)
        {
            var teacher = db.teachers.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfteacher = teacher.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfteacher = onePageOfteacher;

           // return View(db.teachers.ToList());
		     return View(teacher);
        }

        // GET: /teachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // GET: /teachers/Create
        public ActionResult Create()
        {
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name");
            return View();
        }

        // POST: /teachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,surname,phone,imageUrl,thumbnailUrl,street,city,state,postcode,email,gender,schooladmin,classadmin,isSchoolAdmin,isAcceptPayment,isViewer,schoolid,version,createdAt,updatedAt,deleted")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", teacher.schoolid);
            return View(teacher);
        }

        // GET: /teachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", teacher.schoolid);
            return View(teacher);
        }

        // POST: /teachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,surname,phone,imageUrl,thumbnailUrl,street,city,state,postcode,email,gender,schooladmin,classadmin,isSchoolAdmin,isAcceptPayment,isViewer,schoolid,version,createdAt,updatedAt,deleted")] teacher teacher)
        {
            if (ModelState.IsValid)
            {
              
			   db.teachers.Add(teacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", teacher.schoolid);
            return View(teacher);
        }

        // GET: /teachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            teacher teacher = db.teachers.Find(id);
            if (teacher == null)
            {
                return HttpNotFound();
            }
            return View(teacher);
        }

        // POST: /teachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            teacher teacher = db.teachers.Find(id);
            db.teachers.Remove(teacher);
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
