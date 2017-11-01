
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
    public class beltsController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /belts/
        public ActionResult Index(int? page)
        {
            var belt = db.belts.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfbelt = belt.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfbelt = onePageOfbelt;

           // return View(db.belts.ToList());
		     return View( );
        }

        // GET: /belts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            belt belt = db.belts.Find(id);
            if (belt == null)
            {
                return HttpNotFound();
            }
            return View(belt);
        }

        // GET: /belts/Create
        public ActionResult Create()
        {
            ViewBag.beltcolorid = new SelectList(db.beltColors.GetAll(), "id", "name");
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name");
            return View();
        }

        // POST: /belts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,beltcolorid,order,branchid,version,createdAt,updatedAt,deleted")] belt belt)
        {
            if (ModelState.IsValid)
            {
                db.belts.Add(belt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.beltcolorid = new SelectList(db.beltColors.GetAll(), "id", "name", belt.beltcolorid);
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", belt.branchid);
            return View(belt);
        }

        // GET: /belts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            belt belt = db.belts.Find(id);
            if (belt == null)
            {
                return HttpNotFound();
            }
            ViewBag.beltcolorid = new SelectList(db.beltColors.GetAll(), "id", "name", belt.beltcolorid);
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", belt.branchid);
            return View(belt);
        }

        // POST: /belts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,beltcolorid,order,branchid,version,createdAt,updatedAt,deleted")] belt belt)
        {
            if (ModelState.IsValid)
            {
              
			   db.belts.Add(belt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.beltcolorid = new SelectList(db.beltColors.GetAll(), "id", "name", belt.beltcolorid);
            ViewBag.branchid = new SelectList(db.branchs.GetAll(), "id", "name", belt.branchid);
            return View(belt);
        }

        // GET: /belts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            belt belt = db.belts.Find(id);
            if (belt == null)
            {
                return HttpNotFound();
            }
            return View(belt);
        }

        // POST: /belts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            belt belt = db.belts.Find(id);
            db.belts.Remove(belt);
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
