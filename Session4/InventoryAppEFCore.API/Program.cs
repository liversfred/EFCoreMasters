using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.Mappers;
using InventoryAppEFCore.Services;
using InventoryAppEFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);

builder.Services.AddDbContext<InventoryAppEfCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<InventoryAppEfCoreContextInitializer, InventoryAppEfCoreContextInitializer>();

builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ILineItemService, LineItemService>();
builder.Services.AddScoped<IPriceOfferService, PriceOfferService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContextInitialiser = services.GetRequiredService<InventoryAppEfCoreContextInitializer>();

        await dbContextInitialiser.InitialiseAsync();
        //await dbContextInitialiser.SeedAsync();
    }
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
