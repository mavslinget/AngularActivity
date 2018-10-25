using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineStore.EFCore.Domain;
using OnlineStore.EFCore.Domain.Models;

namespace OnlineStore.EFCore.WebApi.Controllers
{
    [EnableCors("OnlineStoreAngular6")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository productRepo;

        public ProductsController(IProductRepository productRepo)
        {
            this.productRepo = productRepo;
        }
        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Product>))]
        public async Task<ActionResult<IEnumerable<Product>>> Get()
        {
            return Ok(productRepo.Retrieve().ToList());
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetProductByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<ActionResult<Product>> Get(Guid id)
        {
            try
            {
                var result = productRepo.Retrieve().FirstOrDefault(p => p.ProductID == id);
                if (result == null)
                {
                    return NotFound();
                }

                return Ok(result);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Products
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(201, Type = typeof(Product))]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            try
            {
                product.ProductID = Guid.NewGuid();

                productRepo.Create(product);

                return CreatedAtRoute("GetProductById",
                    new
                    {
                        id = product.ProductID
                    },
                        product);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Product))]
        public async Task<ActionResult<Product>> Put(Guid id, [FromBody] Product product)
        {
            try
            {
                var result = productRepo.Retrieve().FirstOrDefault(p => p.ProductID == id);
                if (result == null)
                {
                    return NotFound();
                }
                productRepo.Update(id, product);
                await productRepo.UpdateAsync(id, product);

                return Ok(product);
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(204)]
        public async Task<ActionResult<Product>> Delete(Guid id)
        {
            try
            {
                var result = productRepo.Retrieve().FirstOrDefault(p => p.ProductID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await productRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
