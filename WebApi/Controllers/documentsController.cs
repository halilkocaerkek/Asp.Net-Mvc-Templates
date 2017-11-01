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
using System.Web.Http.Cors;

namespace WebApi.Controllers
{
 
    public class documentsController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/documents
        public IQueryable<document> Getdocument()
        {
            return db.document;
        }

        // GET: api/documents/5
        [ResponseType(typeof(document))]
        public IHttpActionResult Getdocument(int id)
        {
            document document = db.document.Find(id);
            if (document == null)
            {
                return NotFound();
            }

            return Ok(document);
        }

        // PUT: api/documents/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdocument(int id, document document)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != document.id)
            {
                return BadRequest();
            }

            db.Entry(document).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!documentExists(id))
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

        // POST: api/documents
        [ResponseType(typeof(document))]
        public IHttpActionResult Postdocument(document document)
        {
            document.documenttype = db.documenttype.Find(document.documenttype.id);
  

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.document.Add(document);
            db.SaveChanges();

            return Ok();
            //return StatusCode(HttpStatusCode.OK);
           // return Ok(document);
            //return CreatedAtRoute("DefaultApi", new { id = document.id }, document);
        }

        // DELETE: api/documents/5
        [ResponseType(typeof(document))]
        public IHttpActionResult Deletedocument(int id)
        {
            document document = db.document.Find(id);
            if (document == null)
            {
                return NotFound();
            }

            db.document.Remove(document);
            db.SaveChanges();

            return Ok(document);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool documentExists(int id)
        {
            return db.document.Count(e => e.id == id) > 0;
        }
    }
}