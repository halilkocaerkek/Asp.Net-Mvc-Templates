
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
    public class sinifsController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /sinifs/
        public ActionResult Index(int? page)
        {
            var sinif = db.sinifs.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfsinif = sinif.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfsinif = onePageOfsinif;

           // return View(db.sinifs.ToList());
		     return View( );
        }

        // GET: /sinifs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinif sinif = db.sinifs.Find(id);
            if (sinif == null)
            {
                return HttpNotFound();
            }
            return View(sinif);
        }

        // GET: /sinifs/Create
        public ActionResult Create()
        {
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name");
            return View();
        }

        // POST: /sinifs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,schoolid,thumbnailUrl,version,createdAt,updatedAt,deleted")] sinif sinif)
        {
            if (ModelState.IsValid)
            {
                db.sinifs.Add(sinif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", sinif.schoolid);
            return View(sinif);
        }

        // GET: /sinifs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinif sinif = db.sinifs.Find(id);
            if (sinif == null)
            {
                return HttpNotFound();
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", sinif.schoolid);
            return View(sinif);
        }

        // POST: /sinifs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,schoolid,thumbnailUrl,version,createdAt,updatedAt,deleted")] sinif sinif)
        {
            if (ModelState.IsValid)
            {
              
			   db.sinifs.Add(sinif);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", sinif.schoolid);
            return View(sinif);
        }

        // GET: /sinifs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            sinif sinif = db.sinifs.Find(id);
            if (sinif == null)
            {
                return HttpNotFound();
            }
            return View(sinif);
        }

        // POST: /sinifs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            sinif sinif = db.sinifs.Find(id);
            db.sinifs.Remove(sinif);
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
