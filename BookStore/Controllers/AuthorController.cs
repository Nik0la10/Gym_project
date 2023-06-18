using Gym.BL.Interfaces;
using Gym.Models.Data;
using Gym.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerService _manufacturerService;
        public ManufacturerController(IManufacturerService manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Manufacturer>))]
        [HttpGet(template: "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Ok(await _manufacturerService.GetAll()));
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(Manufacturer))]
        [ProducesResponseType(
            StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
            StatusCodes.Status404NotFound)]
        [HttpGet(template: "GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _manufacturerService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost(template: "Add")]
        public async Task<IActionResult> Add([FromBody] AddManufacturerRequest manufacturer)
        {
            await _manufacturerService.AddManufacturer(manufacturer);
            return Ok();
        }

        [HttpDelete(template: "Delete")]
        public async Task<IActionResult> Delete(Guid manufacturerId)
        {
            await _manufacturerService.DeleteManufacturer(manufacturerId);
            return Ok();
        }
    }
}