using InventoryAppEFCore.DataLayer.EfClasses;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace InventoryAppEFCore.DataLayer
{
    public class InventoryAppEfCoreContextInitializer
    {
        private readonly ILogger<InventoryAppEfCoreContextInitializer> logger;
        private readonly InventoryAppEfCoreContext context;

        public InventoryAppEfCoreContextInitializer(ILogger<InventoryAppEfCoreContextInitializer> logger, InventoryAppEfCoreContext context)
        {
            this.logger = logger;
            this.context = context;
        }
        public async Task InitialiseAsync()
        {
            try
            {
                if (this.context.Database.IsSqlServer())
                {
                    await this.context.Database.MigrateAsync();
                }
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while initializing the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        public async Task SeedAsync()
        {
            try
            {
                await this.SeedClientsTable();
                await this.SeedOrdersTable();
                await this.SeedProductsTable();
                await this.SeedLineItemsTable();
                await this.SeedPriceOffersTable();
                await this.SeedReviewsTable();
                await this.SeedSuppliersTable();
                await this.SeedProductSupplierTable();
            }
            catch (Exception ex)
            {
#pragma warning disable CA1848 // Use the LoggerMessage delegates
                this.logger.LogError(ex, "An error occurred while seeding the database.");
#pragma warning restore CA1848 // Use the LoggerMessage delegates
                throw;
            }
        }

        private async Task SeedClientsTable()
        {
            if (!this.context.Clients.Any())
            {
                this.context.Clients.Add(new Client()
                {
                    Name = "Client A",
                });

                this.context.Clients.Add(new Client()
                {
                    Name = "Client B",
                });

                this.context.Clients.Add(new Client()
                {
                    Name = "Client C",
                });

                await this.context.SaveChangesAsync();
            }
        }

        private async Task SeedOrdersTable()
        {
            if (!this.context.Orders.Any())
            {
                this.context.Orders.Add(new Order()
                {
                    DateOrderedUtc = DateTime.Now.AddDays(-5),
                    Status = OrderStatus.Pending,
                    ClientId = 1
                });

                this.context.Orders.Add(new Order()
                {
                    DateOrderedUtc = DateTime.Now.AddDays(-4),
                    Status = OrderStatus.InProgress,
                    ClientId = 2
                });

                this.context.Orders.Add(new Order()
                {
                    DateOrderedUtc = DateTime.Now.AddDays(-3),
                    Status = OrderStatus.Complete,
                    ClientId = 3
                });

                await this.context.SaveChangesAsync();
            }
        }

        private async Task SeedProductsTable()
        {
            if (!this.context.Products.Any())
            {
                this.context.Products.Add(new Product()
                {
                    Name = "Product A"
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Product B"
                });

                this.context.Products.Add(new Product()
                {
                    Name = "Product C"
                });

                await this.context.SaveChangesAsync();
            }
        }

        private async Task SeedLineItemsTable()
        {
            if (!this.context.LineItems.Any())
            {
                this.context.LineItems.Add(new LineItem()
                {
                    NumOfProducts = 3,
                    ProductPrice = 100,
                    OrderId = 1,
                    ProductId = 1
                });

                this.context.LineItems.Add(new LineItem()
                {
                    NumOfProducts = 2,
                    ProductPrice = 200,
                    OrderId = 2,
                    ProductId = 2
                });

                this.context.LineItems.Add(new LineItem()
                {
                    NumOfProducts = 1,
                    ProductPrice = 300,
                    OrderId = 3,
                    ProductId = 3
                });

                await this.context.SaveChangesAsync();
            }
        }

        private async Task SeedPriceOffersTable()
        {
            if (!this.context.PriceOffers.Any())
            {
                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 100,
                    PromotinalText = "Promotional Text 1",
                    ProductId = 1
                });
                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 200,
                    PromotinalText = "Promotional Text 2",
                    ProductId = 2
                });
                this.context.PriceOffers.Add(new PriceOffer()
                {
                    NewPrice = 300,
                    PromotinalText = "Promotional Text 3",
                    ProductId = 3
                });

                await this.context.SaveChangesAsync();
            }
        }

        private async Task SeedReviewsTable()
        {
            if (!this.context.Reviews.Any())
            {
                this.context.Reviews.Add(new Review()
                {
                    VoterName = "Voter A",
                    Comment = "This is a Comment 1",
                    NumStars = 5,
                    ProductId = 1
                });

                this.context.Reviews.Add(new Review()
                {
                    VoterName = "Voter B",
                    Comment = "This is a Comment 2",
                    NumStars = 3,
                    ProductId = 2
                });

                this.context.Reviews.Add(new Review()
                {
                    VoterName = "Voter 3",
                    Comment = "This is a Comment 3",
                    NumStars = 4,
                    ProductId = 3
                });

                await this.context.SaveChangesAsync();
            }
        }
        private async Task SeedSuppliersTable()
        {
            if (!this.context.Suppliers.Any())
            {
                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier A",
                    Description = "Description of Supplier A"
                });

                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier B",
                    Description = "Description of Supplier B"
                });

                this.context.Suppliers.Add(new Supplier()
                {
                    Name = "Supplier C",
                    Description = "Description of Supplier C"
                });

                await this.context.SaveChangesAsync();
            }
        }
        private async Task SeedProductSupplierTable()
        {
            if (!this.context.ProductSupplier.Any())
            {
                this.context.ProductSupplier.Add(new ProductSupplier()
                {
                    ProductId = 1,
                    SupplierId = 1,
                    Order = 1
                });

                this.context.ProductSupplier.Add(new ProductSupplier()
                {
                    ProductId = 2,
                    SupplierId = 2,
                    Order = 2
                });

                this.context.ProductSupplier.Add(new ProductSupplier()
                {
                    ProductId = 3,
                    SupplierId = 3,
                    Order = 3
                });

                await this.context.SaveChangesAsync();
            }
        }
    }
}
