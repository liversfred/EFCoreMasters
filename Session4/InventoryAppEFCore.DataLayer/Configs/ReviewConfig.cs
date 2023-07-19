using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryAppEFCore.DataLayer.Configs
{
    internal class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(x => x.ReviewId);

            builder.Ignore(x => x.NumStars);
        }
    }
}
