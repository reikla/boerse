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
using StockExchange.Models;

namespace StockExchange.Controllers
{
    public class StocksController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/StockModels
        public IQueryable<StockModels> GetStockModels()
        {
            return db.StockModels;
        }

        // GET: api/StockModels/5
        [ResponseType(typeof(StockModels))]
        public async Task<IHttpActionResult> GetStockModels(string id)
        {
            StockModels stockModels = await db.StockModels.FindAsync(id);
            if (stockModels == null)
            {
                return NotFound();
            }

            return Ok(stockModels);
        }

        // PUT: api/StockModels/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutStockModels(string id, StockModels stockModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stockModels.Id)
            {
                return BadRequest();
            }

            db.Entry(stockModels).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StockModelsExists(id))
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

        // POST: api/StockModels
        [ResponseType(typeof(StockModels))]
        public async Task<IHttpActionResult> PostStockModels(StockModels stockModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StockModels.Add(stockModels);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StockModelsExists(stockModels.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = stockModels.Id }, stockModels);
        }

        // DELETE: api/StockModels/5
        [ResponseType(typeof(StockModels))]
        public async Task<IHttpActionResult> DeleteStockModels(string id)
        {
            StockModels stockModels = await db.StockModels.FindAsync(id);
            if (stockModels == null)
            {
                return NotFound();
            }

            db.StockModels.Remove(stockModels);
            await db.SaveChangesAsync();

            return Ok(stockModels);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StockModelsExists(string id)
        {
            return db.StockModels.Count(e => e.Id == id) > 0;
        }
    }
}