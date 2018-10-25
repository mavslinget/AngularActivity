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
    public class ActorsController : ControllerBase
    {
        private IActorRepository actorRepo;

        public ActorsController(IActorRepository actorRepo)
        {
            this.actorRepo = actorRepo;
        }
        // GET: api/Actor
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Actor>))]
        public ActionResult<IEnumerable<Actor>> Get()
        {

            return Ok(actorRepo.Retrieve().ToList());
        }

        // GET: api/Actor/5
        [HttpGet("{id}", Name = "GetActorByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Actor))]
        public async Task<ActionResult<Actor>> Get(Guid id)
        {
            try
            {
                var result = await actorRepo.RetrieveAsync(id);
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

        // GET: api/Actor/5/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetActorWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Actor>))]
        public ActionResult<PaginationResult<Actor>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Actor>();
                result = actorRepo.RetrieveActorWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Actor
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Actor))]
        public async Task<ActionResult<Actor>> Post([FromBody] Actor actor)
        {
            try
            {
                actor.ActorID = Guid.NewGuid();
                await actorRepo.CreateAsync(actor);
                return CreatedAtRoute("GetActorByID",
                    new
                    {
                        id = actor.ActorID
                    },
                    actor);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Actor/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Actor))]
        public async Task<ActionResult<Actor>> Put(Guid id, [FromBody] Actor actor)
        {
            try
            {
                var result = actorRepo.Retrieve().FirstOrDefault(a => a.ActorID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await actorRepo.UpdateAsync(id, actor);

                return Ok(actor);

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
                var result = actorRepo.Retrieve().FirstOrDefault(a => a.ActorID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await actorRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        
    }
}
