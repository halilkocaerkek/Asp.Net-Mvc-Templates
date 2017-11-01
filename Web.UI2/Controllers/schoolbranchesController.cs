
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
    public class schoolbranchesController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /schoolbranches/
        public ActionResult Index(int? page)
        {
            var schoolbranch = db.schoolbranchs.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfschoolbranch = schoolbranch.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfschoolbranch = onePageOfschoolbranch;

           // return View(db.schoolbranchs.ToList());
		     return View( );
        }

        // GET: /schoolbranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolbranch schoolbranch = db.schoolbranchs.Find(id);
            if (schoolbranch == null)
            {
                return HttpNotFound();
            }
            return View(schoolbranch);
        }

        // GET: /schoolbranches/Create
        public ActionResult Create()
        {
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name");
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name");
            return View();
        }

        // POST: /schoolbranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,schoolid,branchid,version,createdAt,updatedAt,deleted")] schoolbranch schoolbranch)
        {
            if (ModelState.IsValid)
            {
                db.schoolbranchs.Add(schoolbranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", schoolbranch.branchid);
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", schoolbranch.schoolid);
            return View(schoolbranch);
        }

        // GET: /schoolbranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolbranch schoolbranch = db.schoolbranchs.Find(id);
            if (schoolbranch == null)
            {
                return HttpNotFound();
            }
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", schoolbranch.branchid);
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", schoolbranch.schoolid);
            return View(schoolbranch);
        }

        // POST: /schoolbranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,schoolid,branchid,version,createdAt,updatedAt,deleted")] schoolbranch schoolbranch)
        {
            if (ModelState.IsValid)
            {
              
			   db.schoolbranchs.Add(schoolbranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", schoolbranch.branchid);
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", schoolbranch.schoolid);
            return View(schoolbranch);
        }

        // GET: /schoolbranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            schoolbranch schoolbranch = db.schoolbranchs.Find(id);
            if (schoolbranch == null)
            {
                return HttpNotFound();
            }
            return View(schoolbranch);
        }

        // POST: /schoolbranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            schoolbranch schoolbranch = db.schoolbranchs.Find(id);
            db.schoolbranchs.Remove(schoolbranch);
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
