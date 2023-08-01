using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.Configs
{
    internal class LineItemConfig : IEntityTypeConfiguration<LineItem>
    {
        public void Configure(EntityTypeBuilder<LineItem> builder)
        {
            builder.HasKey(x => x.LineItemId);

            builder.Property(x => x.DiscountedTotalPrice)
                .HasPrecision(18, 2)
                .HasComputedColumnSql("CAST([NumOfProducts] * [ProductPrice] * (1 - [DiscountPercentage] / 100) AS DECIMAL(18, 2))", stored: true);

            builder.HasOne<Order>()
                .WithMany(x => x.LineItems)
                .HasForeignKey(x => x.OrderId);
        }
    }
}
