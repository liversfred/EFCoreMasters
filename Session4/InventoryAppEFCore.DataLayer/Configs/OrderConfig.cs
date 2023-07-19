using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.Configs
{
    internal class OrderConfig : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(x => x.OrderId);

            builder.Property(x => x.Status).HasConversion(x => x.ToString(), x => (OrderStatus)Enum.Parse(typeof(OrderStatus), x));
        }
    }
}
