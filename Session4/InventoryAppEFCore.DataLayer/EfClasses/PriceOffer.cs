namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class PriceOffer
    {
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }
        public string PromotinalText { get; set; }

        //relationship---
        public int ProductId { get; set; }
    }
}
