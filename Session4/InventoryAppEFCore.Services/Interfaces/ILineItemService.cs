using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses.TableFunctions;

namespace InventoryAppEFCore.Services.Interfaces
{
    public interface ILineItemService
    {
        Task<List<LineItemDto>> GetLineItems();
        LineItemTableFunction GetLineItemsByProductId(int productId);
    }
}
