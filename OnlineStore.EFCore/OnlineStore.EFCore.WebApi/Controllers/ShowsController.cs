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
    public class ShowsController : ControllerBase
    {
        private IShowRepository showRepo;

        public ShowsController(IShowRepository showRepo)
        {
            this.showRepo = showRepo;
        }
        // GET: api/Show
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Show>))]
        public ActionResult<IEnumerable<Show>> Get()
        {

            return Ok(showRepo.Retrieve().ToList());
        }

        // GET: api/Show/5
        [HttpGet("{id}", Name = "GetShowByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Show))]
        public async Task<ActionResult<Show>> Get(Guid id)
        {
            try
            {
                var result = await showRepo.RetrieveAsync(id);
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

        // GET: api/Show/5/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetShowWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Show>))]
        public async Task<ActionResult<PaginationResult<Show>>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Show>();
                result = showRepo.RetrieveShowWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Show
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Show))]
        public async Task<ActionResult<Show>> Post([FromBody] Show show)
        {
            try
            {
                show.ShowID = Guid.NewGuid();
                await showRepo.CreateAsync(show);
                return CreatedAtRoute("GetShowByID",
                    new
                    {
                        id = show.ShowID
                    },
                    show);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Show/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Show))]
        public async Task<ActionResult<Show>> Put(Guid id, [FromBody] Show show)
        {
            try
            {
                var result = showRepo.Retrieve().FirstOrDefault(t => t.ShowID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await showRepo.UpdateAsync(id, show);

                return Ok(show);

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
                var result = showRepo.Retrieve().FirstOrDefault(t => t.ShowID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await showRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
