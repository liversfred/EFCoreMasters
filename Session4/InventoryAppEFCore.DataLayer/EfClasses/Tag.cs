using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{

    public class Tag
    {
        [Key]
        public int TagId { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
