
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
    public class classteachersController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /classteachers/
        public ActionResult Index(int? page)
        {
            var classteacher = db.classteachers.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfclassteacher = classteacher.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfclassteacher = onePageOfclassteacher;

           // return View(db.classteachers.ToList());
		     return View( );
        }

        // GET: /classteachers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classteacher classteacher = db.classteachers.Find(id);
            if (classteacher == null)
            {
                return HttpNotFound();
            }
            return View(classteacher);
        }

        // GET: /classteachers/Create
        public ActionResult Create()
        {
            ViewBag.teacherid = new SelectList(db.teachers.GetAll(), "id", "name");
            return View();
        }

        // POST: /classteachers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,classid,teacherid,isClassAdmin,isAcceptPayment,isViewer,version,createdAt,updatedAt,deleted")] classteacher classteacher)
        {
            if (ModelState.IsValid)
            {
                db.classteachers.Add(classteacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.teacherid = new SelectList(db.teachers.GetAll(), "id", "name", classteacher.teacherid);
            return View(classteacher);
        }

        // GET: /classteachers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classteacher classteacher = db.classteachers.Find(id);
            if (classteacher == null)
            {
                return HttpNotFound();
            }
            ViewBag.teacherid = new SelectList(db.teachers.GetAll(), "id", "name", classteacher.teacherid);
            return View(classteacher);
        }

        // POST: /classteachers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,classid,teacherid,isClassAdmin,isAcceptPayment,isViewer,version,createdAt,updatedAt,deleted")] classteacher classteacher)
        {
            if (ModelState.IsValid)
            {
              
			   db.classteachers.Add(classteacher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.teacherid = new SelectList(db.teachers.GetAll(), "id", "name", classteacher.teacherid);
            return View(classteacher);
        }

        // GET: /classteachers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            classteacher classteacher = db.classteachers.Find(id);
            if (classteacher == null)
            {
                return HttpNotFound();
            }
            return View(classteacher);
        }

        // POST: /classteachers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            classteacher classteacher = db.classteachers.Find(id);
            db.classteachers.Remove(classteacher);
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
