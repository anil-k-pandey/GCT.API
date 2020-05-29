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
    public class SecondaryVariancesController : ApiController
    {
        private GCTEntities db = new GCTEntities();

        // GET: api/SecondaryVariances
        public IQueryable<SecondaryVariance> GetSecondaryVariances()
        {
            return db.SecondaryVariances;
        }

        // GET: api/SecondaryVariances/5
        [ResponseType(typeof(SecondaryVariance))]
        public async Task<IHttpActionResult> GetSecondaryVariance(int id)
        {
            SecondaryVariance secondaryVariance = await db.SecondaryVariances.FindAsync(id);
            if (secondaryVariance == null)
            {
                return NotFound();
            }

            return Ok(secondaryVariance);
        }

        // PUT: api/SecondaryVariances/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSecondaryVariance(int id, SecondaryVariance secondaryVariance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != secondaryVariance.Id)
            {
                return BadRequest();
            }

            db.Entry(secondaryVariance).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SecondaryVarianceExists(id))
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

        // POST: api/SecondaryVariances
        [ResponseType(typeof(SecondaryVariance))]
        public async Task<IHttpActionResult> PostSecondaryVariance(SecondaryVariance secondaryVariance)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SecondaryVariances.Add(secondaryVariance);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (SecondaryVarianceExists(secondaryVariance.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = secondaryVariance.Id }, secondaryVariance);
        }

        // DELETE: api/SecondaryVariances/5
        [ResponseType(typeof(SecondaryVariance))]
        public async Task<IHttpActionResult> DeleteSecondaryVariance(int id)
        {
            SecondaryVariance secondaryVariance = await db.SecondaryVariances.FindAsync(id);
            if (secondaryVariance == null)
            {
                return NotFound();
            }

            db.SecondaryVariances.Remove(secondaryVariance);
            await db.SaveChangesAsync();

            return Ok(secondaryVariance);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SecondaryVarianceExists(int id)
        {
            return db.SecondaryVariances.Count(e => e.Id == id) > 0;
        }
    }
}