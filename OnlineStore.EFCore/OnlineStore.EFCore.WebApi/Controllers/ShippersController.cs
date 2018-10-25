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
    public class ShippersController : ControllerBase
    {
        private IShipperRepository shipperRepo;

        public ShippersController(IShipperRepository shipperRepo)
        {
            this.shipperRepo = shipperRepo;
        }
        // GET: api/Employee
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Shipper>))]
        public IEnumerable<Shipper> Get()
        {
            return shipperRepo.Retrieve().ToList();
        }

        // GET: api/Shipper/5
        [HttpGet("{id}", Name = "GetShipperById")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Shipper))]
        public async Task<ActionResult<Shipper>> Get(Guid id)
        {
            try
            {
                var result = shipperRepo.Retrieve().FirstOrDefault(s => s.ShipperID == id);
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

        // GET: api/Shipper/5/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetShipperWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Shipper>))]
        public async Task<ActionResult<PaginationResult<Shipper>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Shipper>();
                result = shipperRepo.RetrieveShipperWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Shipper
        [HttpPost]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        public async Task<ActionResult<Shipper>> Post([FromBody] Shipper shipper)
        {
            try
            {
                shipper.ShipperID = Guid.NewGuid();

                shipperRepo.Create(shipper);

                return CreatedAtRoute("GetShipperById",
                    new
                    {
                        id = shipper.ShipperID
                    },
                        shipper);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Shipper/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Shipper))]
        public async Task<ActionResult<Shipper>> Put(Guid id, [FromBody] Shipper shipper)
        {
            try
            {
                var result = shipperRepo.Retrieve().FirstOrDefault(s => s.ShipperID == id);
                if (result == null)
                {
                    return NotFound();
                }
                shipperRepo.Update(id, shipper);
                await shipperRepo.UpdateAsync(id, shipper);

                return Ok(shipper);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(401)]
        [ProducesResponseType(204, Type = typeof(Shipper))]
        public async Task<ActionResult<Shipper>> Delete(Guid id)
        {
            try
            {
                var result = shipperRepo.Retrieve().FirstOrDefault(s => s.ShipperID == id);
                if (result == null)
                {
                    return NotFound();
                }
                shipperRepo.Delete(id);
                return NoContent();

            }
            catch (Exception)
            {
                return BadRequest();
            }


        }
    }
}
