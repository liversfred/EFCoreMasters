using InventoryAppEFCore.DataLayer.Dtos;

namespace InventoryAppEFCore.Services.Interfaces
{
    public interface ILineItemService
    {
        Task<List<LineItemDto>> GetLineItems();
    }
}
