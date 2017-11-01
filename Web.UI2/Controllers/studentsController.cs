
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
using System.Web.Script.Serialization;
using System.Text;

namespace Web.UI2.Controllers
{
    public class studentsController : Controller
    {
        //private ddsport db = new ddsport();
		 UnitOfWork db = new UnitOfWork();

        // GET: /students/
        public ActionResult Index(int? page)
        {
            var student = db.students.GetAll().OrderBy(o => o.id);

			var pageNumber = page ?? 1; // if no page was specified in the querystring, default to the first page (1)
            var onePageOfstudent = student.ToPagedList(pageNumber, 10); // will only contain 25 products max because of the pageSize

            ViewBag.OnePageOfstudent = onePageOfstudent;

           // return View(db.students.ToList());
		     return View(student);
        }

        // GET: /students/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }


            var List1 = (from items in student.measure where items.studentId == id && items.measuretype.id == 1 select new { date = items.createdAt, value = items.value }).ToList();
            var List2 = (from items in student.measure where items.studentId == id && items.measuretype.id == 2 select new { date = items.createdAt, value = items.value }).ToList();

            var jsonSerialiser = new JavaScriptSerializer();

            StringBuilder sb = new StringBuilder(List1.Count*20);
            var i = 0;
            var comma = "";
            sb.Append("[");
            foreach(var item in List1)
            {
                sb.AppendFormat( "{0}[gd({1},{2},{3}), {4}]" , comma,  item.date.Year, item.date.Month, item.date.Day , item.value);
                comma = ",";
            }
            sb.Append("]");

            ViewBag.BoyList = sb.ToString( );

            sb = sb.Clear( );
             i = 0;
            comma = "";
            sb.Append("[");
            foreach ( var item in List2 )
            {
                sb.AppendFormat("{0}[gd({1},{2},{3}), {4}]" , comma , item.date.Year , item.date.Month , item.date.Day , item.value);
                comma = ",";
            }
            sb.Append("]");

            ViewBag.KiloList = sb.ToString( );

            return View(student);
        }

        // GET: /students/Create
        public ActionResult Create()
        {
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name");
            return View();
        }

        // POST: /students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="id,name,surname,phone,imageUrl,thumbnailUrl,street,city,state,postcode,email,gender,schoolid,version,createdAt,updatedAt,deleted")] student student)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", student.schoolid);
            return View(student);
        }

        // GET: /students/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", student.schoolid);
            return View(student);
        }

        // POST: /students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="id,name,surname,phone,imageUrl,thumbnailUrl,street,city,state,postcode,email,gender,schoolid,version,createdAt,updatedAt,deleted")] student student)
        {
            if (ModelState.IsValid)
            {
              
			   db.students.Add(student);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.schoolid = new SelectList(db.schools.GetAll(), "id", "name", student.schoolid);
            return View(student);
        }

        // GET: /students/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            student student = db.students.Find(id);
            if (student == null)
            {
                return HttpNotFound();
            }
            return View(student);
        }

        // POST: /students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            student student = db.students.Find(id);
            db.students.Remove(student);
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
