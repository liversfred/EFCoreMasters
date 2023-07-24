namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class TagDto
    {
        public int TagId { get; set; }

        public ICollection<ProductDto> Products { get; set; }
    }
}
