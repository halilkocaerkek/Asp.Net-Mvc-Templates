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
    public class documenttypesController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/documenttypes
        public IQueryable<documenttype> Getdocumenttype()
        {
            return db.documenttype;
        }

        // GET: api/documenttypes/5
        [ResponseType(typeof(documenttype))]
        public IHttpActionResult Getdocumenttype(int id)
        {
            documenttype documenttype = db.documenttype.Find(id);
            if (documenttype == null)
            {
                return NotFound();
            }

            return Ok(documenttype);
        }

        // PUT: api/documenttypes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putdocumenttype(int id, documenttype documenttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != documenttype.id)
            {
                return BadRequest();
            }

            db.Entry(documenttype).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!documenttypeExists(id))
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

        // POST: api/documenttypes
        [ResponseType(typeof(documenttype))]
        public IHttpActionResult Postdocumenttype(documenttype documenttype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.documenttype.Add(documenttype);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = documenttype.id }, documenttype);
        }

        // DELETE: api/documenttypes/5
        [ResponseType(typeof(documenttype))]
        public IHttpActionResult Deletedocumenttype(int id)
        {
            documenttype documenttype = db.documenttype.Find(id);
            if (documenttype == null)
            {
                return NotFound();
            }

            db.documenttype.Remove(documenttype);
            db.SaveChanges();

            return Ok(documenttype);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool documenttypeExists(int id)
        {
            return db.documenttype.Count(e => e.id == id) > 0;
        }
    }
}