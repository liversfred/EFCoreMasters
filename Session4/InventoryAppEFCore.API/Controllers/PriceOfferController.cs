using InventoryAppEFCore.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace InventoryAppEFCore.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PriceOfferController : Controller
    {
        private readonly IPriceOfferService _priceOfferService;
        public PriceOfferController(IPriceOfferService priceOfferService)
        {
            _priceOfferService = priceOfferService;
        }

        [HttpGet]
        public async Task<IActionResult> PriceOffers()
        {
            var result = await _priceOfferService.GetPriceOfferFromView();
            return Ok(result);
        }
    }
}
