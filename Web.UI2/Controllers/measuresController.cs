
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
    public class measuresController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();


        public ActionResult Dashboard ()
        {
            return View();
        }
        // GET: /measures/
        public ActionResult Index(int? page)
        {
            var measure = db.measures.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfmeasure = measure.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfmeasure = onePageOfmeasure;

           // return View(db.measures.ToList());
		     return View( );
        }

        // GET: /measures/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measure measure = db.measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // GET: /measures/Create
        public ActionResult Create()
        {
            ViewBag.type = new SelectList(db.measuretypes.GetAll(), "id", "Name");
            ViewBag.studentId = new SelectList(db.students.GetAll(), "id", "name");
            return View();
        }

        // POST: /measures/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,studentId,type,value,createdBy,createdAt")] measure measure)
        {
            if (ModelState.IsValid)
            {
                db.measures.Add(measure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.type = new SelectList(db.measuretypes.GetAll(), "id", "Name", measure.type);
            ViewBag.studentId = new SelectList(db.students.GetAll(), "id", "name", measure.studentId);
            return View(measure);
        }

        // GET: /measures/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measure measure = db.measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            ViewBag.type = new SelectList(db.measuretypes.GetAll(), "id", "Name", measure.type);
            ViewBag.studentId = new SelectList(db.students.GetAll(), "id", "name", measure.studentId);
            return View(measure);
        }

        // POST: /measures/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,studentId,type,value,createdBy,createdAt")] measure measure)
        {
            if (ModelState.IsValid)
            {
              
			   db.measures.Add(measure);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.type = new SelectList(db.measuretypes.GetAll(), "id", "Name", measure.type);
            ViewBag.studentId = new SelectList(db.students.GetAll(), "id", "name", measure.studentId);
            return View(measure);
        }

        // GET: /measures/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            measure measure = db.measures.Find(id);
            if (measure == null)
            {
                return HttpNotFound();
            }
            return View(measure);
        }

        // POST: /measures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            measure measure = db.measures.Find(id);
            db.measures.Remove(measure);
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
