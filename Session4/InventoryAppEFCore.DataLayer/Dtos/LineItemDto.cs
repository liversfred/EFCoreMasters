namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class LineItemDto
    {
        public int LineItemId { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal TotalPrice { get; set; }

        public ProductDto SelectedProduct { get; set; }
    }
}
