namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class ProductDto
    {
        public int ProductId { get; set; }
        public string Name { get; set; }

        public PriceOfferDto Promotion { get; set; }
        public ICollection<ReviewDto> Reviews { get; set; }
        public ICollection<TagDto> Tags { get; set; }
    }
}
