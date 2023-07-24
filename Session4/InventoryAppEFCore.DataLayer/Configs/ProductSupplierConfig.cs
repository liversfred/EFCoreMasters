using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.Configs
{
    internal class ProductSupplierConfig : IEntityTypeConfiguration<ProductSupplier>
    {
        public void Configure(EntityTypeBuilder<ProductSupplier> builder)
        {
            builder.HasKey(x => new { x.ProductId, x.SupplierId });

            builder.HasOne(x => x.Product)
                .WithMany(y => y.SuppliersLink)
                .HasForeignKey(x => x.ProductId);

            builder.HasOne(x => x.Supplier)
                .WithMany(y => y.ProductsLink)
                .HasForeignKey(x => x.SupplierId);

        }
    }
}