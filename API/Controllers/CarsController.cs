using DataAccess.Entities;
using DataAccess.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CarsController : ControllerBase
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var list = carService.GetAll();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var car = carService.GetById(id);

            return Ok(car);
        }

        [HttpPost]
        public IActionResult Post([FromBody] Car car)
        {
            var postedCar = carService.Create(car);
            if (postedCar is true)
            {
                return Ok("Successfully created");
            }

            return BadRequest("Failed");
        }

        [HttpPut]
        public IActionResult Put([FromBody] Car car)
        {
            var updatedcar = carService.Update(car);
            if (updatedcar is true)
            {
                return Ok("Successfully updated");
            }

            return BadRequest("Failed");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedCar = carService.Delete(id);
            if (deletedCar is true)
            {
                return Ok("Successfully deleted");
            }

            return BadRequest("Failed");
        }
    }
}