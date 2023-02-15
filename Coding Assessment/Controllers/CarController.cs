using Microsoft.AspNetCore.Mvc;
using Coding_Assessment.Classes;
using Coding_Assessment.Services;

namespace Coding_Assessment.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private static CarServices CarService = new CarServices();

        private readonly ILogger<CarController> _logger;

        public CarController(ILogger<CarController> logger)
        {
            _logger = logger;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> GetCar(int id)
        {
            try
            {
                Car value = await CarService.GetCar(id);
            if (value == null)
            {
                NotFound();
            }
            return Ok(await Task.Run(() => value));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                return Ok(await Task.Run(() => CarService.GetAll()));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPatch("Update")]
        public async Task<IActionResult> Update(Car reg)
        {
            try
            {
                if (await CarService.UpdateCar(reg))
                {
                    return Ok("Car updated");
                }
                else
                {
                    return NotFound("Car was not found");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(Car reg)
        {
            try
            {
                CarService.InsertCar(reg);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
        [HttpDelete("Delete")]
        public async Task<IActionResult> Delete(int Id)
        {
            try
            {
                if (await CarService.DeleteCar(Id))
            {
                return Ok("Car deleted");
            }
            else
            {
                return NotFound("Car was not found");
            }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}