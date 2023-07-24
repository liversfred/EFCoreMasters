using InventoryAppEFCore.DataLayer.Dtos;

namespace InventoryAppEFCore.Services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
    }
}
