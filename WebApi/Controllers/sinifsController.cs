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
using DataModel.Dto;

namespace WebApi.Controllers
{
    public class sinifsController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/sinifs
        public IQueryable<sinif> Getsinif()
        {
            return db.sinif;
        }

        // GET: api/sinifs/5/teachers 
        [Route("api/sinifs/{id}/teachers")]
        [HttpGet]
        public IQueryable<teacherDTO> teachers ( int id   )
        {
            List<teacherDTO> teachers = new List<teacherDTO>();
            var items = db.ClassTeacher.Where(o => o.classid == id).ToList();
            foreach(var item in items )
            {
                var teacher =  db.teacher.Find(item.teacherid);
                var t = new teacherDTO {id=teacher.id, name = teacher.name, surname = teacher.surname,thumbnailUrl =  teacher.thumbnailUrl };
                teachers.Add(t);
            }
            return teachers.AsQueryable();
        }


        // GET: api/sinifs/5/students 
        [Route("api/sinifs/{id}/students")]
        [HttpGet]
        public IQueryable<studentDTO> students ( int id )
        {
            List<studentDTO> students = new List<studentDTO>();
            var items = db.ClassStudent.Where(o => o.sinif_id == id).ToList();
            foreach ( var item in items )
            {
                var student =  db.student.Find(item.studentid);
                var t = new studentDTO { id= student.id, name = student.name, surname = student.surname,thumbnailUrl = student.thumbnailUrl };
                students.Add(t);
            }
            return students.AsQueryable( );
        }

        private Action<classteacher> addtoList ()
        {
            throw new NotImplementedException( );
        }

        // GET: api/sinifs/5
        [ResponseType(typeof(sinif))]
        public IHttpActionResult Getsinif(int id)
        {
            sinif sinif = db.sinif.Find(id);
            if (sinif == null)
            {
                return NotFound();
            }

            return Ok(sinif);
        }

        // PUT: api/sinifs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putsinif(int id, sinif sinif)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != sinif.id)
            {
                return BadRequest();
            }

            db.Entry(sinif).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!sinifExists(id))
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

        // POST: api/sinifs
        [ResponseType(typeof(sinif))]
        public IHttpActionResult Postsinif(sinif sinif)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.sinif.Add(sinif);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = sinif.id }, sinif);
        }

        // DELETE: api/sinifs/5
        [ResponseType(typeof(sinif))]
        public IHttpActionResult Deletesinif(int id)
        {
            sinif sinif = db.sinif.Find(id);
            if (sinif == null)
            {
                return NotFound();
            }

            db.sinif.Remove(sinif);
            db.SaveChanges();

            return Ok(sinif);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool sinifExists(int id)
        {
            return db.sinif.Count(e => e.id == id) > 0;
        }

        
    }
}