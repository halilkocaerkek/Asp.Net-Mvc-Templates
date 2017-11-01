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
    public class roomsController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/rooms
        public IQueryable<room> Getroom()
        {
            return db.room;
        }

        // GET: api/teachers/5?schoolid=1 
        public IQueryable<room> Getteacher ( int id , int schoolid )
        {
            var rooms =  db.room.Where(t => t.schoolid == schoolid);

            return rooms;
        }

        // GET: api/rooms/5
        [ResponseType(typeof(room))]
        public IHttpActionResult Getroom(int id)
        {
            room room = db.room.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            return Ok(room);
        }

        // PUT: api/rooms/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putroom(int id, room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != room.id)
            {
                return BadRequest();
            }

            db.Entry(room).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!roomExists(id))
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

        // POST: api/rooms
        [ResponseType(typeof(room))]
        public IHttpActionResult Postroom(room room)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.room.Add(room);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = room.id }, room);
        }

        // DELETE: api/rooms/5
        [ResponseType(typeof(room))]
        public IHttpActionResult Deleteroom(int id)
        {
            room room = db.room.Find(id);
            if (room == null)
            {
                return NotFound();
            }

            db.room.Remove(room);
            db.SaveChanges();

            return Ok(room);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool roomExists(int id)
        {
            return db.room.Count(e => e.id == id) > 0;
        }
    }
}