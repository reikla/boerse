using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using StockExchange.Models;

namespace StockExchange.Controllers
{
    public class OrdersController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: api/Orders
        public IQueryable<OrdersModel> GetOrdersModels()
        {
            return db.OrdersModels;
        }

        // GET: api/Orders/5
        [ResponseType(typeof(OrdersModel))]
        public async Task<IHttpActionResult> GetOrdersModel(int id)
        {
            OrdersModel ordersModel = await db.OrdersModels.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            return Ok(ordersModel);
        }

        // PUT: api/Orders/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutOrdersModel(int id, OrdersModel ordersModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ordersModel.Id)
            {
                return BadRequest();
            }

            db.Entry(ordersModel).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrdersModelExists(id))
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

        // POST: api/Orders
        [ResponseType(typeof(OrdersModel))]
        public async Task<IHttpActionResult> PostOrdersModel(OrdersModel ordersModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.OrdersModels.Add(ordersModel);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (OrdersModelExists(ordersModel.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ordersModel.Id }, ordersModel);
        }

        // DELETE: api/Orders/5
        [ResponseType(typeof(OrdersModel))]
        public async Task<IHttpActionResult> DeleteOrdersModel(string id)
        {
            OrdersModel ordersModel = await db.OrdersModels.FindAsync(id);
            if (ordersModel == null)
            {
                return NotFound();
            }

            db.OrdersModels.Remove(ordersModel);
            await db.SaveChangesAsync();

            return Ok(ordersModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool OrdersModelExists(int id)
        {
            return db.OrdersModels.Count(e => e.Id == id) > 0;
        }
    }
}