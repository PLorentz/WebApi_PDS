using ProductsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ProductsApp.Controllers
{
    public class ProductsController : ApiController
    {
        static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Tomato Soup", Category = "Groceries", Price = 1 },
            new Product { Id = 2, Name = "Yo-yo", Category = "Toys", Price = 3.75M },
            new Product { Id = 3, Name = "Hammer", Category = "Hardware", Price = 16.99M }
        };

        static int nextId = 4;

        public IEnumerable<Product> GetAllProducts()
        {
            return products;
        }

        public IHttpActionResult GetProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        public IHttpActionResult PostProduct([FromBody] Product product)
        {
            lock (products)
            {
                product.Id = nextId++;
                products.Add(product);
            }
            return CreatedAtRoute("DefaultApi", new { Controller = "Products", Id = product.Id }, product);
        }

        public IHttpActionResult PutProduct(int id, [FromBody] Product product)
        {
            var productDB = products.FirstOrDefault((p) => p.Id == id);
            if (productDB == null)
                return NotFound();

            product.Id = id;
            products[products.IndexOf(productDB)] = product;

            return StatusCode(HttpStatusCode.NoContent);
        }

        public IHttpActionResult DeleteProduct(int id)
        {
            var product = products.FirstOrDefault((p) => p.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product);

            return Ok(product);
        }
    }
}
