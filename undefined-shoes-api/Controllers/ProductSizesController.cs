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
    public class ProductSizesController : ApiController
    {
        private MyDatabaseContext db = new MyDatabaseContext();

        // GET: api/ProductSizes
        public IQueryable<ProductSize> GetProductSizes()
        {
            return db.ProductSizes;
        }

        // GET: api/ProductSizes/5
        [ResponseType(typeof(ProductSize))]
        public IHttpActionResult GetProductSize(int id)
        {
            ProductSize productSize = db.ProductSizes.Find(id);
            if (productSize == null)
            {
                return NotFound();
            }

            return Ok(productSize);
        }

        // PUT: api/ProductSizes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProductSize(int id, ProductSize productSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != productSize.Id)
            {
                return BadRequest();
            }

            db.Entry(productSize).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductSizeExists(id))
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

        // POST: api/ProductSizes
        [ResponseType(typeof(ProductSize))]
        public IHttpActionResult PostProductSize(ProductSize productSize)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ProductSizes.Add(productSize);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = productSize.Id }, productSize);
        }

        // DELETE: api/ProductSizes/5
        [ResponseType(typeof(ProductSize))]
        public IHttpActionResult DeleteProductSize(int id)
        {
            ProductSize productSize = db.ProductSizes.Find(id);
            if (productSize == null)
            {
                return NotFound();
            }

            db.ProductSizes.Remove(productSize);
            db.SaveChanges();

            return Ok(productSize);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProductSizeExists(int id)
        {
            return db.ProductSizes.Count(e => e.Id == id) > 0;
        }
    }
}