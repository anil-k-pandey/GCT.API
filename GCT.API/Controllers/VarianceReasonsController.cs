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
    public class VarianceReasonsController : ApiController
    {
        private GCTEntities db = new GCTEntities();

        // GET: api/VarianceReasons
        public IQueryable<BudgetVarianceReason> GetBudgetVarianceReasons()
        {
            return db.BudgetVarianceReasons;
        }

        // GET: api/VarianceReasons/5
        [ResponseType(typeof(BudgetVarianceReason))]
        public async Task<IHttpActionResult> GetBudgetVarianceReason(int id)
        {
            BudgetVarianceReason budgetVarianceReason = await db.BudgetVarianceReasons.FindAsync(id);
            if (budgetVarianceReason == null)
            {
                return NotFound();
            }

            return Ok(budgetVarianceReason);
        }

        // PUT: api/VarianceReasons/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBudgetVarianceReason(int id, BudgetVarianceReason budgetVarianceReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != budgetVarianceReason.Id)
            {
                return BadRequest();
            }

            db.Entry(budgetVarianceReason).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BudgetVarianceReasonExists(id))
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

        // POST: api/VarianceReasons
        [ResponseType(typeof(BudgetVarianceReason))]
        public async Task<IHttpActionResult> PostBudgetVarianceReason(BudgetVarianceReason budgetVarianceReason)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BudgetVarianceReasons.Add(budgetVarianceReason);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BudgetVarianceReasonExists(budgetVarianceReason.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = budgetVarianceReason.Id }, budgetVarianceReason);
        }

        // DELETE: api/VarianceReasons/5
        [ResponseType(typeof(BudgetVarianceReason))]
        public async Task<IHttpActionResult> DeleteBudgetVarianceReason(int id)
        {
            BudgetVarianceReason budgetVarianceReason = await db.BudgetVarianceReasons.FindAsync(id);
            if (budgetVarianceReason == null)
            {
                return NotFound();
            }

            db.BudgetVarianceReasons.Remove(budgetVarianceReason);
            await db.SaveChangesAsync();

            return Ok(budgetVarianceReason);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BudgetVarianceReasonExists(int id)
        {
            return db.BudgetVarianceReasons.Count(e => e.Id == id) > 0;
        }
    }
}