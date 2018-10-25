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
    public class QualificationsController : ControllerBase
    {
        private IQualificationRepository qualificationRepo;

        public QualificationsController(IQualificationRepository qualificationRepo)
        {
            this.qualificationRepo = qualificationRepo;
        }
        // GET: api/Qualification
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<Qualification>))]
        public ActionResult<IEnumerable<Qualification>> Get()
        {

            return Ok(qualificationRepo.Retrieve().ToList());
        }

        // GET: api/Qualification/5
        [HttpGet("{id}", Name = "GetQualificationByID")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Qualification))]
        public async Task<ActionResult<Qualification>> Get(Guid id)
        {
            try
            {
                var result = await qualificationRepo.RetrieveAsync(id);
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

        // GET: api/Qualification/5/5
        [HttpGet("{page}/{itemsPerPage}", Name = "GetQualificationWithPagination")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(PaginationResult<Qualification>))]
        public ActionResult<PaginationResult<Qualification>> Get(int page, int itemsPerPage, string filter)
        {
            try
            {
                var result = new PaginationResult<Qualification>();
                result = qualificationRepo.RetrieveQualificationWithPagination(page, itemsPerPage, filter);
                return result;
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // POST: api/Qualification
        [HttpPost]
        [ProducesResponseType(400)]
        [ProducesResponseType(201, Type = typeof(Qualification))]
        public async Task<ActionResult<Qualification>> Post([FromBody] Qualification qualification)
        {
            try
            {
                qualification.QualificationID = Guid.NewGuid();
                await qualificationRepo.CreateAsync(qualification);
                return CreatedAtRoute("GetQualificationByID",
                    new
                    {
                        id = qualification.QualificationID
                    },
                    qualification);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }

        // PUT: api/Qualification/5
        [HttpPut("{id}")]
        [ProducesResponseType(404)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type = typeof(Qualification))]
        public async Task<ActionResult<Qualification>> Put(Guid id, [FromBody] Qualification qualification)
        {
            try
            {
                var result = qualificationRepo.Retrieve().FirstOrDefault(x => x.QualificationID == id);
                if (result == null)
                {
                    return NotFound();
                }
                await qualificationRepo.UpdateAsync(id, qualification);

                return Ok(qualification);

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
                var result = qualificationRepo.Retrieve().FirstOrDefault(x => x.QualificationID == id);
                if (result == null)
                {
                    return NotFound();
                }

                await qualificationRepo.DeleteAsync(id);
                return NoContent();
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }


    }
}
