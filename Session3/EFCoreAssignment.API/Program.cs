using EFCoreAssignment.Data;
using EFCoreAssignment.Data.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

//TODO register DbContext 
var connectionString = builder.Configuration.GetConnectionString("AppDbContext") ?? throw new InvalidOperationException("Connection string 'AppDbContext' not found.");
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));

//TODO register DbContext initialiser
builder.Services.AddTransient<AppDbContextInitialiser, AppDbContextInitialiser>();

//TODO register product service
builder.Services.AddScoped<IProductService, ProductService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();

    //TODO create new scoped service provider and run initialise and seed of AppDbContextInitialiser    
    using(var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        var dbContextInitialiser = services.GetRequiredService<AppDbContextInitialiser>();

        await dbContextInitialiser.InitialiseAsync();
        await dbContextInitialiser.SeedAsync();
    }
}
// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
