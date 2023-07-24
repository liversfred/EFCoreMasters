namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class ProductSupplierDto
    {
        public byte Order { get; set; }
        public SupplierDto Supplier { get; set; }
        public ProductDto Product { get; set; }
    }
}
