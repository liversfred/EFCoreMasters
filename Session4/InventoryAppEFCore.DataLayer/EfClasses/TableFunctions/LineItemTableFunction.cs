namespace InventoryAppEFCore.DataLayer.EfClasses.TableFunctions
{
    public class LineItemTableFunction
    {
        public string ProductName { get; set; }
        public short NumOfProducts { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal DiscountPercentage { get; set; }
        public double DiscountedPrice { get; set; }
        public decimal DiscountedTotalPrice { get; set; }
    }
}
