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
    public class branchesController : ApiController
    {
        private ddsport db = new ddsport();

        // GET: api/branches
        public IQueryable<branch> Getbranch()
        {
            return db.Branch;
        }

        // GET: api/branches/5
        [ResponseType(typeof(branch))]
        public IHttpActionResult Getbranch(int id)
        {
            branch branch = db.Branch.Find(id);
            if (branch == null)
            {
                return NotFound();
            }

            return Ok(branch);
        }

        // PUT: api/branches/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putbranch(int id, branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != branch.id)
            {
                return BadRequest();
            }

            db.Entry(branch).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!branchExists(id))
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

        // POST: api/branches
        [ResponseType(typeof(branch))]
        public IHttpActionResult Postbranch(branch branch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Branch.Add(branch);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = branch.id }, branch);
        }

        // DELETE: api/branches/5
        [ResponseType(typeof(branch))]
        public IHttpActionResult Deletebranch(int id)
        {
            branch branch = db.Branch.Find(id);
            if (branch == null)
            {
                return NotFound();
            }

            db.Branch.Remove(branch);
            db.SaveChanges();

            return Ok(branch);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool branchExists(int id)
        {
            return db.Branch.Count(e => e.id == id) > 0;
        }
    }
}