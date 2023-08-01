using InventoryAppEFCore.DataLayer.Configs;
using InventoryAppEFCore.DataLayer.EfClasses;
using InventoryAppEFCore.DataLayer.EfClasses.Views;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContext : DbContext
    {
      
        public InventoryAppEfCoreContext(DbContextOptions<InventoryAppEfCoreContext> options)
          : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<PriceOffer> PriceOffers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<LineItem> LineItems { get; set; }
        public DbSet<ProductSupplier> ProductSupplier { get; set; }

        // Views
        public DbSet<PriceOfferView> PriceOfferView { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TO DO Fluent API
            modelBuilder.ApplyConfiguration(new ClientConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new LineItemConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new PriceOfferConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new SupplierConfig());
            modelBuilder.ApplyConfiguration(new ProductSupplierConfig());
            
            // View config
            modelBuilder.Entity<PriceOfferView>().ToView("PriceOfferView").HasNoKey();

            // Seed Data
            modelBuilder.Entity<Client>().HasData(
                new { ClientId = 1, Name = "Client A" },
                new { ClientId = 2, Name = "Client B" },
                new { ClientId = 3, Name = "Client C" });
            modelBuilder.Entity<Product>().HasData(
                new { ProductId = 1, Name = "Product A" },
                new { ProductId = 2, Name = "Product B" },
                new { ProductId = 3, Name = "Product C" });
            modelBuilder.Entity<Supplier>().HasData(
                new { SupplierId = 1, Name = "Supplier A", Description = "Description of Supplier A" },
                new { SupplierId = 2, Name = "Supplier B", Description = "Description of Supplier B" },
                new { SupplierId = 3, Name = "Supplier C", Description = "Description of Supplier C" });
            modelBuilder.Entity<Tag>().HasData(
                new { TagId = 1 },
                new { TagId = 2 },
                new { TagId = 3 });
            modelBuilder.Entity<Order>().HasData(
                new { OrderId = 1, DateOrderedUtc = DateTime.Now.AddDays(-5), Status = OrderStatus.Pending, ClientId = 1 },
                new { OrderId = 2, DateOrderedUtc = DateTime.Now.AddDays(-4), Status = OrderStatus.InProgress, ClientId = 2 },
                new { OrderId = 3, DateOrderedUtc = DateTime.Now.AddDays(-3), Status = OrderStatus.Complete, ClientId = 3 });
            modelBuilder.Entity<PriceOffer>().HasData(
                new { PriceOfferId = 1, NewPrice = 100M, PromotinalText = "Promotional Text 1", ProductId = 1, CreatedDate = DateTime.Now },
                new { PriceOfferId = 2, NewPrice = 200M, PromotinalText = "Promotional Text 2", ProductId = 2, CreatedDate = DateTime.Now },
                new { PriceOfferId = 3, NewPrice = 300M, PromotinalText = "Promotional Text 3", ProductId = 3, CreatedDate = DateTime.Now });
            modelBuilder.Entity<Review>().HasData(
                new { ReviewId = 1, VoterName = "Voter A", Comment = "This is a Comment 1", ProductId = 1 },
                new { ReviewId = 2, VoterName = "Voter B", Comment = "This is a Comment 2", ProductId = 2 },
                new { ReviewId = 3, VoterName = "Voter C", Comment = "This is a Comment 3", ProductId = 3 });
            modelBuilder.Entity<ProductSupplier>().HasData(
                new { ProductId = 1, SupplierId = 1, Order = (byte)1 },
                new { ProductId = 2, SupplierId = 2, Order = (byte)2 },
                new { ProductId = 3, SupplierId = 3, Order = (byte)3 });
            modelBuilder.Entity<LineItem>().HasData(
                new { LineItemId = 1, NumOfProducts = (short)3, ProductPrice = 100M, OrderId = 1, ProductId = 1 },
                new { LineItemId = 2, NumOfProducts = (short)2, ProductPrice = 200M, OrderId = 2, ProductId = 2 },
                new { LineItemId = 3, NumOfProducts = (short)1, ProductPrice = 300M, OrderId = 3, ProductId = 3 });
        }
    }
}