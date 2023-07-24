using InventoryAppEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventoryController : Controller
    {
        private readonly IProductService _service;

        public InventoryController(IProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var result = await _service.GetProducts();
            return Ok(result);
        }
    }
}
