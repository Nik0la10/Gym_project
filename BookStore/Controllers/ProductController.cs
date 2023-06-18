using Gym.BL.Interfaces;
using Gym.Models.Data;
using Gym.Models.Request;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gym.Controllers
{
    [ApiController]
    [Route(template: "[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [ProducesResponseType(
            StatusCodes.Status200OK,
            Type = typeof(IEnumerable<Product>))]
        [HttpGet(template: "GetAll")]
        public async Task<IActionResult> GetAll()
        {
            return Ok(Ok(await _productService.GetAll()));
        }

        [ProducesResponseType(
          StatusCodes.Status200OK,
          Type = typeof(Product))]
        [ProducesResponseType(
          StatusCodes.Status400BadRequest)]
        [ProducesResponseType(
          StatusCodes.Status404NotFound)]
        [HttpGet(template: "GetById")]
        public async Task<IActionResult> GetById(Guid id)
        {

            var result = await _productService.GetById(id);

            if (result == null) return NotFound();

            return Ok(result);
        }

        [HttpPost(template: "Add")]
        public async Task<IActionResult> Add([FromBody] AddProductRequest product)
        {
            await _productService.AddProduct(product);
            return Ok();
        }

        [HttpDelete(template: "Delete")]
        public async Task<IActionResult> Delete(Guid productId)
        {
            await _productService.DeleteProduct(productId);
            return Ok();
        }
    }
}