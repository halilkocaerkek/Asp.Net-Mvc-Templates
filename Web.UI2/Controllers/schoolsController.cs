
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
    public class schoolsController : Controller
    {
        //private ddsport db = new ddsport();
        UnitOfWork db = new UnitOfWork();


        public ActionResult Dashboard ()
        {
            return View(ScheduleData.getDummySchedule( ));
        }

        public ActionResult schedule()
        {
            return View( );
        }
        // GET: /schools1/
        public ActionResult Index ( int? page )
        {
            var school = db.schools.GetAll().OrderBy(o => o.id);

            var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfschool = school.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfschool = onePageOfschool;

            // return View(db.schools.ToList());
            return View(school);
        }

        // GET: /schools1/Details/5
        public ActionResult Details ( int? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            school school = db.schools.Find(id);
            if ( school == null )
            {
                return HttpNotFound( );
            }
            return View(school);
        }

        // GET: /schools1/Create
        public ActionResult Create ()
        {
            return View( );
        }

        // POST: /schools1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create ( [Bind(Include = "id,name,version,createdAt,updatedAt,deleted")] school school )
        {
            if ( ModelState.IsValid )
            {
                db.schools.Add(school);
                db.SaveChanges( );
                return RedirectToAction("Index");
            }

            return View(school);
        }

        // GET: /schools1/Edit/5
        public ActionResult Edit ( int? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            school school = db.schools.Find(id);
            if ( school == null )
            {
                return HttpNotFound( );
            }
            return View(school);
        }

        // POST: /schools1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit ( [Bind(Include = "id,name,version,createdAt,updatedAt,deleted")] school school )
        {
            if ( ModelState.IsValid )
            {

                db.schools.Add(school);
                db.SaveChanges( );
                return RedirectToAction("Index");
            }
            return View(school);
        }

        // GET: /schools1/Delete/5
        public ActionResult Delete ( int? id )
        {
            if ( id == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            school school = db.schools.Find(id);
            if ( school == null )
            {
                return HttpNotFound( );
            }
            return View(school);
        }

        // POST: /schools1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed ( int id )
        {
            school school = db.schools.Find(id);
            db.schools.Remove(school);
            db.SaveChanges( );
            return RedirectToAction("Index");
        }

        protected override void Dispose ( bool disposing )
        {
            if ( disposing )
            {
                db.Dispose( );
            }
            base.Dispose(disposing);
        }
    }
}
