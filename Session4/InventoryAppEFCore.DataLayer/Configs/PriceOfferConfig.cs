using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.Configs
{
    internal class PriceOfferConfig : IEntityTypeConfiguration<PriceOffer>
    {
        public void Configure(EntityTypeBuilder<PriceOffer> builder)
        {
            builder.HasKey(x => x.PriceOfferId);

            // ShadowProperty
            builder.Property<DateTime>("CreatedDate");
        }
    }
}
