// See https://aka.ms/new-console-template for more information
using EFCoreAssignment;
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
