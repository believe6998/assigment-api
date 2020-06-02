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
using undefined_shoes_api.Models;

namespace undefined_shoes_api.Controllers
{
    public class ProductsController : ApiController
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: api/Products
        public IHttpActionResult GetProducts(int currentPage = 1, int pageSize = 25, string name = null, double? startPrice = null, double? endPrice = null)
        {
            var skip = (currentPage - 1) * pageSize;

            var total = db.Products.Count();

            var products = db.Products.AsQueryable();

            if (name != null)
            {
                products = products.Where(p => p.Name.Contains(name));
            }
            if (startPrice != null)
            {
                products = products.Where(p => p.Price >= startPrice);
            }
            if (endPrice != null)
            {
                products = products.Where(p => p.Price <= endPrice);
            }
            products = products.OrderBy(c => c.Id).Skip(skip).Take(pageSize);
            return Ok(new PagedResult<Product>(products.ToList(), currentPage, pageSize, total));
        }

        // GET: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult GetProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProduct(int id, Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            db.Entry(product).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
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

        // POST: api/Products
        [ResponseType(typeof(Product))]
        public IHttpActionResult PostProduct(Product product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Products.Add(product);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // DELETE: api/Products/5
        [ResponseType(typeof(Product))]
        public IHttpActionResult DeleteProduct(int id)
        {
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }

            db.Products.Remove(product);
            db.SaveChanges();

            return Ok(product);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductExists(int id)
        {
            return db.Products.Count(e => e.Id == id) > 0;
        }
    }
}