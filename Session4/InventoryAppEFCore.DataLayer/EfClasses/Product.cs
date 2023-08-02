using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InventoryAppEFCore.DataLayer.EfClasses
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public DateTime CreatedDate { get; set; }

        // Backing Field
        private string _productUrl;

        [BackingField(nameof(_productUrl))]
        public string ProductUrl 
        { 
            get { return _productUrl; }   
        }

        public void SetProductUrl(string productUrl)
        {
            _productUrl = productUrl;
        }

        //relationships---
        public PriceOffer Promotion { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Tag> Tags { get; set; }

        public ICollection<ProductSupplier> SuppliersLink { get; set; }

        public bool IsDeleted { get; set; }
    }
}
