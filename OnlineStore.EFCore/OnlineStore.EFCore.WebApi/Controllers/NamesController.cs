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
    public class NamesController : ControllerBase
    {
        private INameRepository nameRepo;

        public NamesController(INameRepository nameRepo)
        {
            this.nameRepo = nameRepo;
        }
        // GET: api/Name
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Name>))]
        public ActionResult<IEnumerable<Name>> Get()
        {

            return Ok(nameRepo.Retrieve().ToList());
        }

        // GET: api/Name/5
        [HttpGet("{id}", Name = "GetNameByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Name))]
        public async Task<ActionResult<Name>> Get(Guid id)
        {
            try
            {
                var result = await nameRepo.RetrieveAsync(id);
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

        // GET: api/Name/5/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetNameWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Name>))]
        public ActionResult<PaginationResult<Name>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Name>();
                result = nameRepo.RetrieveNameWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Name
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Name))]
        public async Task<ActionResult<Name>> Post([FromBody] Name name)
        {
            try
            {
                name.NameID = Guid.NewGuid();
                await nameRepo.CreateAsync(name);
                return CreatedAtRoute("GetNameByID",
                    new
                    {
                        id = name.NameID
                    },
                    name);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Name/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Name))]
        public async Task<ActionResult<Name>> Put(Guid id, [FromBody] Name name)
        {
            try
            {
                var result = nameRepo.Retrieve().FirstOrDefault(a => a.NameID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await nameRepo.UpdateAsync(id, name);

                return Ok(name);

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
        public async Task<ActionResult> Delete(Guid id)
        {
            try
            {
                var result = nameRepo.Retrieve().FirstOrDefault(a => a.NameID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await nameRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
