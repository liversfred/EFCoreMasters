using InventoryAppEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LineItemsController : Controller
    {
        private readonly ILineItemService _service;

        public LineItemsController(ILineItemService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> LineItems()
        {
            var result = await _service.GetLineItems();
            return Ok(result);
        }

        [HttpGet("{productId}")]
        public IActionResult GetLineItemsByProductId(int productId)
        {
            var result = _service.GetLineItemsByProductId(productId);
            return Ok(result);
        }
    }
}
