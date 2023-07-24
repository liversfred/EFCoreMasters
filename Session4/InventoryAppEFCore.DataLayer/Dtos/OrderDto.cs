using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class OrderDto
    {
        public int OrderId { get; set; }

        public DateTime DateOrderedUtc { get; set; }

        public OrderStatus Status { get; set; }
    }
}
