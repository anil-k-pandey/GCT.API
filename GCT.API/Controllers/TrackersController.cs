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
using GCT.API.ViewModel;

namespace GCT.API.Controllers
{
    public class TrackersController : ApiController
    {
        private GCTEntities db = new GCTEntities();

        // GET: api/Trackers
        public IQueryable<TrackerModel> GetTrackers()
        {
            var tracker =  db.Trackers;

            return tracker.Select(x => new TrackerModel
            {
                Id = x.Id,
                ProjectCode = x.ProjectCode,
                ProjectName = x.ProjectName,
                Region = x.Region,
                CountryId = x.CountryId.Value,
                CountryName = x.Country.Name,
                ResponsibilityCentreName = x.ResponsibilityCentreName,
                ResponsibilityCentreNumber = x.ResponsibilityCentreNumber,
                ExpenseCategory = x.ExpenseCategory,
                VendorId = x.VendorId,
                VendorName = x.Vendor.Name,
                RequisitionNumber = x.RequisitionNumber,
                CurrencyCode = x.CurrencyCode,
                LocalCcyFxRate= x.LocalCcyFxRate.Value,
                LocalCcyRPIRate= x.LocalCcyRPIRate.Value,
                BudgetLocalCcy = x.BudgetLocalCcy,
                BudgetUSCcy = x.BudgetUSCcy,
                ActualLocalCcy = x.ActualLocalCcy,
                ActualUSCcy = x.ActualUSCcy,
                CashStartDate = x.CashStartDate,
                CashEndDate=x.CashEndDate,
                PLStartDate=x.PLStartDate,
                PLEndDate=x.PLEndDate,
                RequisitionDescription = x.RequisitionDescription,
                PrimaryVarianceId = x.PrimaryVarianceId,
                PrimaryVariancName = x.PrimaryVariance.Name,
                SecondaryVarianceId = x.SecondaryVarianceId,
                SecondaryVarianceName=x.SecondaryVariance.Name,
                ReceiptNumber = x.ReceiptNumber,
                Comments = x.Comments,
                Renewal = x.Renewal,
                TotalBudget = x.TotalBudget,
                VarianceInBudget = x.VarianceInBudget,
                NextYrLocalCcyBudget  = x.NextYrLocalCcyBudget,
                NextYrUSCcyBudget = x.NextYrUSCcyBudget,
                InternalContractor = x.InternalContractor,
                ITDirector = x.ITDirector,
                AdditionalComments = x.AdditionalComments,
                IsDeleted  = x.IsDeleted,
                USD = x.USD,
                VAT = x.VAT,
                Inflation1 = x.Inflation1,
                Inflation2 = x.Inflation2,
                January = x.January,
                February = x.February,
                March = x.March,
                April = x.April,
                May = x.May ,
                June = x.June,
                July = x.July,
                August = x.August,
                Septemeber = x.Septemeber,
                October = x.October,
                November = x.November,
                December = x.December
            }).AsQueryable();
        }

        // GET: api/Trackers/5
        [ResponseType(typeof(Tracker))]
        public async Task<IHttpActionResult> GetTracker(int id)
        {
            Tracker tracker = await db.Trackers.FindAsync(id);
            if (tracker == null)
            {
                return NotFound();
            }

            return Ok(tracker);
        }

        // PUT: api/Trackers/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutTracker(int id, Tracker tracker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != tracker.Id)
            {
                return BadRequest();
            }

            db.Entry(tracker).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TrackerExists(id))
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

        // POST: api/Trackers
        [ResponseType(typeof(Tracker))]
        public async Task<IHttpActionResult> PostTracker(Tracker tracker)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Trackers.Add(tracker);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TrackerExists(tracker.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = tracker.Id }, tracker);
        }

        // DELETE: api/Trackers/5
        [ResponseType(typeof(Tracker))]
        public async Task<IHttpActionResult> DeleteTracker(int id)
        {
            Tracker tracker = await db.Trackers.FindAsync(id);
            if (tracker == null)
            {
                return NotFound();
            }

            db.Trackers.Remove(tracker);
            await db.SaveChangesAsync();

            return Ok(tracker);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TrackerExists(int id)
        {
            return db.Trackers.Count(e => e.Id == id) > 0;
        }
    }
}