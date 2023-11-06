using DataAccess.Entities;
using DataAccess.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OwnersController : ControllerBase
    {
        private readonly IOwnerService ownerService;

        public OwnersController(IOwnerService ownerService)
        {
            this.ownerService = ownerService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var list = ownerService.GetAll();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Owner = ownerService.GetById(id);

            return Ok(Owner);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Owner owner)
        {
            var postedOwner = ownerService.Create(owner);
            if (postedOwner is true)
            {
                return Ok("Successfully created");
            }

            return BadRequest("Failed");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Owner owner)
        {
            var updatedOwner = ownerService.Update(owner);
            if (updatedOwner is true)
            {
                return Ok("Successfully updated");
            }

            return BadRequest("Failed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedOwner = ownerService.Delete(id);
            if (deletedOwner is true)
            {
                return Ok("Successfully deleted");
            }

            return BadRequest("Failed");
        }
    }
}