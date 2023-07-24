namespace InventoryAppEFCore.DataLayer.Dtos
{
    public class PriceOfferDto
    {
        public int PriceOfferId { get; set; }

        public decimal NewPrice { get; set; }
        public string PromotinalText { get; set; }
    }
}
