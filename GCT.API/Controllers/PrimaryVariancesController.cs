using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using GCT.API.Models;

namespace GCT.API.Controllers
{
    public class PrimaryVariancesController : ApiController
    {
        private GCTEntities db = new GCTEntities();

        // GET: api/PrimaryVariances
        public IQueryable<PrimaryVariance> GetPrimaryVariances()
        {
            return db.PrimaryVariances;
        }

        // GET: api/PrimaryVariances/5
        [ResponseType(typeof(PrimaryVariance))]
        public async Task<IHttpActionResult> GetPrimaryVariance(int id)
        {
            PrimaryVariance primaryVariance = await db.PrimaryVariances.FindAsync(id);
            if (primaryVariance == null)
            {
                return NotFound();
            }

            return Ok(primaryVariance);
        }

        // PUT: api/PrimaryVariances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutPrimaryVariance(int id, PrimaryVariance primaryVariance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != primaryVariance.Id)
            {
                return BadRequest();
            }

            db.Entry(primaryVariance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrimaryVarianceExists(id))
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

        // POST: api/PrimaryVariances
        [ResponseType(typeof(PrimaryVariance))]
        public async Task<IHttpActionResult> PostPrimaryVariance(PrimaryVariance primaryVariance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PrimaryVariances.Add(primaryVariance);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PrimaryVarianceExists(primaryVariance.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = primaryVariance.Id }, primaryVariance);
        }

        // DELETE: api/PrimaryVariances/5
        [ResponseType(typeof(PrimaryVariance))]
        public async Task<IHttpActionResult> DeletePrimaryVariance(int id)
        {
            PrimaryVariance primaryVariance = await db.PrimaryVariances.FindAsync(id);
            if (primaryVariance == null)
            {
                return NotFound();
            }

            db.PrimaryVariances.Remove(primaryVariance);
            await db.SaveChangesAsync();

            return Ok(primaryVariance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PrimaryVarianceExists(int id)
        {
            return db.PrimaryVariances.Count(e => e.Id == id) > 0;
        }
    }
}