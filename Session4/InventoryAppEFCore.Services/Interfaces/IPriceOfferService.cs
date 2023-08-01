using InventoryAppEFCore.DataLayer.EfClasses.Views;

namespace InventoryAppEFCore.Services.Interfaces
{
    public interface IPriceOfferService
    {
        Task<List<PriceOfferView>> GetPriceOfferFromView();
    }
}
