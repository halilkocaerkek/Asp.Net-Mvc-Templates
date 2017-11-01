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
    public class schoolsController : ApiController
    {
        //private ddsport db = new ddsport();

        UnitOfWork db = new UnitOfWork();

        // GET: api/scools
        [HttpGet]
        public  IQueryable<schoolDTO> Getschool ()
        {
             return db.schools.getAllSchools().AsQueryable();
        }

        // GET: api/schools/5/teachers 
        [Route("api/schools/{id}/teachers")]
        [HttpGet]
        public IQueryable<teacherDTO> teachers ( int id )
        {
             return db.schools.getAllTeachers(id).AsQueryable( );
        }

        // GET: api/schools/5/students 
        [Route("api/schools/{id}/students")]
        [HttpGet]
        public IQueryable<studentDTO> students ( int id )
        {
            return db.schools.getAllStudents(id).AsQueryable( );
        }

        // GET: api/schools/5/rooms 
        [Route("api/schools/{id}/rooms")]
        [HttpGet]
        public IQueryable<roomDTO> rooms ( int id )
        {
            return db.schools.getAllRooms(id).AsQueryable( );
        }

        // GET: api/schools/5/classes 
        [Route("api/schools/{id}/classes")]
        [HttpGet]
        public IQueryable<classDTO> classes ( int id )
        {
            return db.schools.getAllClasses(id).AsQueryable( );
        }

        // GET: api/schools/5
        [ResponseType(typeof(school))]
        public IHttpActionResult Getschool(int id)
        {
            school school = db.schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            return Ok(school);
        }

        // PUT: api/schools/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putschool(int id, school school)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != school.id)
            {
                return BadRequest();
            }

          //  db.schools(school).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!db.schools.isExists(id))
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

        // POST: api/schools
        [ResponseType(typeof(school))]
        public IHttpActionResult Postschool(school school)
        {
            if ( school == null )
            {
                return BadRequest("school can not be null");
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.schools.Add(school);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = school.id }, school);
        }

        // DELETE: api/schools/5
        [ResponseType(typeof(school))]
        public IHttpActionResult Deleteschool(int id)
        {
            school school = db.schools.Find(id);
            if (school == null)
            {
                return NotFound();
            }

            db.schools.Remove(school);
            db.SaveChanges();

            return Ok(school);
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