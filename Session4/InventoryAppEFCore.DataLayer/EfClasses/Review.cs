using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Review
    {
        public int ReviewId { get; set; }
        public string VoterName { get; set; }

        public string Comment { get; set; }
        public int NumStars { get; set; }

        [ForeignKey(nameof(Product))]
        public int ProductId { get; set; }
    }
}
