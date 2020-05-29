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
    public class CurrenciesController : ApiController
    {
        private GCTEntities db = new GCTEntities();

        // GET: api/Currencies
        public IQueryable<CurrencyModel> GetCurrencies()
        {
            var currency =  db.Currencies;
            return currency.Select(y => new CurrencyModel
            {
                Id = y.Id,
                Code = y.CurrencyCode,
                Name = y.Name,
                Fxrate = y.FxRate.Value,
                RPI = y.RPI.Value,
                CountryId = y.CountryId,
                RenewYear = y.RenewalYear
            }).AsQueryable();
        }

        // GET: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> GetCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            return Ok(currency);
        }

        // PUT: api/Currencies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCurrency(int id, Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != currency.Id)
            {
                return BadRequest();
            }

            db.Entry(currency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CurrencyExists(id))
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

        // POST: api/Currencies
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> PostCurrency(Currency currency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Currencies.Add(currency);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CurrencyExists(currency.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = currency.Id }, currency);
        }

        // DELETE: api/Currencies/5
        [ResponseType(typeof(Currency))]
        public async Task<IHttpActionResult> DeleteCurrency(int id)
        {
            Currency currency = await db.Currencies.FindAsync(id);
            if (currency == null)
            {
                return NotFound();
            }

            db.Currencies.Remove(currency);
            await db.SaveChangesAsync();

            return Ok(currency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CurrencyExists(int id)
        {
            return db.Currencies.Count(e => e.Id == id) > 0;
        }
    }
}