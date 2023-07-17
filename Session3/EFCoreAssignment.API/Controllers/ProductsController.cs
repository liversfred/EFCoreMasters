using EFCoreAssignment.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreAssignment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            if(!await _service.IsProductExisting(id)) return NotFound($"Product with id = {id} not found.");

            return Ok(await _service.GetProduct(id));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductApiModel vm)
        {
            var result = await _service.CreateProduct(new CreateProductDto(vm.Name, vm.ShopId));
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProductApiModel vm)
        {
            if (!await _service.IsProductExisting(vm.Id)) return NotFound($"Product with id = {vm.Id} not found.");

            await _service.UpdateProduct(new UpdateProductDto(vm.Id, vm.Name, vm.ShopId));

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!await _service.IsProductExisting(id)) return NotFound($"Product with id = {id} not found.");

            await _service.DeleteProduct(id);

            return Ok();
        }
    }

    public record CreateProductApiModel(string Name, int ShopId);
    public record UpdateProductApiModel(int Id, string Name, int ShopId);
}
