using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using DataModel;

namespace WebApi.Controllers
{
    public class teachersController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/teachers
        public IQueryable<teacher> Getteacher()
        {
            return db.teacher;
        }

        // GET: api/teachers/5?schoolid=1 
        public IQueryable<teacher> Getteacher (  int? schoolid , int? classid )
        {
            IQueryable < teacher > teachers  = null;
            if ( schoolid.HasValue )
            {
                  teachers =  db.teacher.Where(t => t.schoolid == schoolid);
            }
            if ( classid.HasValue )
            {
                teachers = db.teacher.Where(t => t.schoolid == classid);
            }

            return teachers;
        }

        // GET: api/teachers/5
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Getteacher(int id)
        {
            teacher teacher = db.teacher.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            return Ok(teacher);
        }

        // PUT: api/teachers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putteacher(int id, teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != teacher.id)
            {
                return BadRequest();
            }

            db.Entry(teacher).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!teacherExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/teachers
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Postteacher(teacher teacher)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(teacher.birthDate == DateTime.MinValue)
            {
                return BadRequest("Doğum Tarihi Girmelisiniz");
            }

            if (teacher.workBegin == DateTime.MinValue)
            {
                return BadRequest("Doğum Tarihi Girmelisiniz");
            }

            db.teacher.Add(teacher);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = teacher.id }, teacher);
        }

        // DELETE: api/teachers/5
        [ResponseType(typeof(teacher))]
        public IHttpActionResult Deleteteacher(int id)
        {
            teacher teacher = db.teacher.Find(id);
            if (teacher == null)
            {
                return NotFound();
            }

            db.teacher.Remove(teacher);
            db.SaveChanges();

            return Ok(teacher);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool teacherExists(int id)
        {
            return db.teacher.Count(e => e.id == id) > 0;
        }
    }
}