using AutoMapper;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.EfClasses.Views;
using InventoryAppEFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.Services
{
    public class PriceOfferService : IPriceOfferService
    {
        private readonly InventoryAppEfCoreContext _dbContext;

        public PriceOfferService(InventoryAppEfCoreContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<PriceOfferView>> GetPriceOfferFromView()
        {
            return await _dbContext.PriceOfferView.ToListAsync();
        }
    }
}
