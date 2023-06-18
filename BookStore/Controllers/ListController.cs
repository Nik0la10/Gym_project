using Gym.BL.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class ListController : ControllerBase
    {
        private readonly ListService _listService;
        public ListController(ListService listService)
        {
            _listService = listService;
        }

        [HttpGet(template: "GetAllProductsByManufacturer")]
        public async Task<IActionResult>
            GetAllProductsByManufacturer(Guid manufacturerId)
            {
                var result =
                    await _listService.GetAllProductsByManufacturer(manufacturerId);

                if (result?.Manufacturer == null) return NotFound(manufacturerId);

                return Ok(result);
            }
    }
}