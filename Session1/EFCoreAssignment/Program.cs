// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
using EFCoreAssignment.Entities;
using Microsoft.EntityFrameworkCore;

Console.WriteLine("Hello, World!");

var connection = @"Server=.\SQLEXPRESS;Database=Frederick.EFCoreMasters.Session01;Trusted_Connection=True"; // TODO : Add your connection string here
var optionsBuilder =
    new DbContextOptionsBuilder
           <AppDbContext>();
optionsBuilder.UseSqlServer(connection);

var options = optionsBuilder.Options;

var dbContext = new AppDbContext(options);

Filtering(dbContext);
SingleOrDefault(dbContext);
LoadingRelatedData_Manual(dbContext);
LoadingRelatedData_ExplicitLoading(dbContext);
LoadingRelatedData_EagerLoading(dbContext);

static void Filtering(AppDbContext dbContext)
{
    // TODO : Filter by Product Name
    var products = dbContext.Products.AsNoTracking().Where(product => product.Name == "Product A");

    foreach (var product in products)
    {
        Console.WriteLine($"Filtering - Product: {product.Name}");
    }
}

static void SingleOrDefault(AppDbContext dbContext)
{
    // TODO : Select using SingleOrDefault by Product Id   
    var product = dbContext.Products.AsNoTracking().SingleOrDefault(product => product.Id == 2);
    if (product != null)
    {
        Console.WriteLine($"SingleOrDefault - Product: {product.Name}");
    }
}

static void LoadingRelatedData_Manual(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data manually
    var product = dbContext.Products.AsNoTracking().FirstOrDefault(product => product.Id == 3);
    if (product != null)
    {
        product.Shop = dbContext.Shops.Single(shop => shop.Id == product.ShopId);
        Console.WriteLine($"LoadingRelatedData_Manual - Product's Shop: {product.Shop.Name}");
    }
}

static void LoadingRelatedData_ExplicitLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related shop data explicitly
    var product = dbContext.Products.SingleOrDefault(product => product.Id == 4);
    if (product != null)
    {
        dbContext.Entry(product)
        .Reference(product => product.Shop)
        .Load();
        Console.WriteLine($"LoadingRelatedData_ExplicitLoading - Product's Shop: {product.Shop.Name}");
    }
}

static void LoadingRelatedData_EagerLoading(AppDbContext dbContext)
{
    // TODO : Load Product with related Shop data eagerly    
    var product = dbContext.Products.AsNoTracking().Include(product => product.Shop).SingleOrDefault(product => product.Id == 5);
    if (product != null)
    {
        Console.WriteLine($"LoadingRelatedData_EagerLoading - Product's Shop: {product.Shop.Name}");
    }
}


Console.WriteLine("EF Core is the best");


/* Session 2 Assignment */
Console.WriteLine("\n\nSession 2 Assignment\n");

InsertProduct(dbContext);
InsertProductWithNewShop(dbContext);
UpdateProduct(dbContext);
DeleteProduct(dbContext);
DeleteProductByKey(dbContext);

static void InsertProduct(AppDbContext dbContext)
{
    // TODO: Insert a new Product
    var product = new Product
    {
        Name = "Products F",
        ShopId = 3
    };

    dbContext.Add(product);
    dbContext.SaveChanges();

    Console.WriteLine($"InsertProduct - {product.Name} has been added with ShopId {product.ShopId}.");
}

static void InsertProductWithNewShop(AppDbContext dbContext)
{
    // TODO: Insert a new Product with a new Shop
    var product = new Product
    {
        Name = "Products G",
        Shop = new Shop(){ Name = "Shop D" }
    };

    dbContext.Add(product);
    dbContext.SaveChanges();

    Console.WriteLine($"InsertProductWithNewShop - {product.Name} has been added with Shop Name {product.Shop.Name}.");
}

static void UpdateProduct(AppDbContext dbContext)
{
    // TODO: Update a Product
    var latestProduct = dbContext.Products.OrderByDescending(p => p.Id).FirstOrDefault();
    if(latestProduct != null)
    {
        latestProduct.Name = $"{latestProduct.Name} - Updated Name";

        dbContext.SaveChanges();

        Console.WriteLine($"UpdateProduct - Latest Product has been updated with the new name ({latestProduct.Name}).");
    }
}

static void DeleteProduct(AppDbContext dbContext)
{
    // TODO: Delete a Product
    var product = dbContext.Products.OrderByDescending(p => p.Id).Skip(2).FirstOrDefault();   // Skip 2 to keep the first 2 requirements
    if (product != null)
    {
        dbContext.Remove(product);
        dbContext.SaveChanges();

        Console.WriteLine($"DeleteProduct - {product.Name} has been hard deleted.");
    }
}

static void DeleteProductByKey(AppDbContext dbContext)
{
    // TODO: Delete a Product with just having a key
    var productId = 1;

    var product = new Product { Id = productId };

    dbContext.Remove(product);
    dbContext.SaveChanges();

    Console.WriteLine($"DeleteProductByKey - Product with Id: {productId}, has been hard deleted.");
}