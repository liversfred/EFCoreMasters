using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class ClientDto
    {
        public int ClientId { get; set; }

        public string Name { get; set; }

        public Order Order { get; set; }
    }
}
