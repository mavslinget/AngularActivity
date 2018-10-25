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
    public class OrdersController : ControllerBase
    {
        private IOrderRepository orderRepo;

        public OrdersController(IOrderRepository orderRepo)
        {
            this.orderRepo = orderRepo;
        }
        // GET: api/Products
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Order>))]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            return Ok(orderRepo.Retrieve().ToList());
        }

        // GET: api/Products/5
        [HttpGet("{id}", Name = "GetOrderByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<ActionResult<Order>> Get(Guid id)
        {
            try
            {
                var result = orderRepo.Retrieve().FirstOrDefault(x => x.OrderID == id);
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
        [ProducesResponseType(201, Type = typeof(Order))]
        public async Task<ActionResult<Order>> Post([FromBody] Order order)
        {
            try
            {
                order.OrderID = Guid.NewGuid();

                orderRepo.Create(order);

                return CreatedAtRoute("GetOrderById",
                    new
                    {
                        id = order.OrderID

                    },
                        order);
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
        [ProducesResponseType(200, Type = typeof(Order))]
        public async Task<ActionResult<Product>> Put(Guid id, [FromBody] Order order)
        {
            try
            {
                var result = orderRepo.Retrieve().FirstOrDefault(x => x.OrderID == id);
                if (result == null)
                {
                    return NotFound();
                }
                orderRepo.Update(id, order);
                await orderRepo.UpdateAsync(id, order);

                return Ok(order);
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
        public async Task<ActionResult<Order>> Delete(Guid id)
        {
            try
            {
                var result = orderRepo.Retrieve().FirstOrDefault(x => x.OrderID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await orderRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }

        }
    }
}
