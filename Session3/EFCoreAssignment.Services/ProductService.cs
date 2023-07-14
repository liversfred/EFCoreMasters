using EFCoreAssignment.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreAssignment.Data.Services
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _dbContext;

        public ProductService(AppDbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            // TODO get products
            return await _dbContext.Products.Select(x => new ProductDto(x.Id, x.Name, x.ShopId)).ToListAsync();
        }

        public async Task<ProductDto> GetProduct(int id)
        {
            // TODO get product
            var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id) 
                    ?? throw new NullReferenceException($"Product with id = {id} not found.");

            return new ProductDto(product.Id, product.Name, product.ShopId);
        }

        public async Task<int> CreateProduct(CreateProductDto productForCreation)
        {
            // TODO create a product
            var product = new Product
            {
                Name = productForCreation.Name,
                ShopId = productForCreation.ShopId
            };

            _dbContext.Add(product);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateProduct(UpdateProductDto productForUpdate)
        {
            //TODO update a product
            var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == productForUpdate.Id) 
                ?? throw new NullReferenceException($"Product with id = {productForUpdate.Id} not found.");

            product.Name = productForUpdate.Name;
            product.ShopId = productForUpdate.ShopId;
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteProduct(int id)
        {
            //TODO delete a product
            var product = await _dbContext.Products.SingleOrDefaultAsync(x => x.Id == id) 
                ?? throw new NullReferenceException($"Product with id = {id} not found.");

            _dbContext.Remove(product);
            await _dbContext.SaveChangesAsync();
        }
    }

    public interface IProductService
    {
        Task<List<ProductDto>> GetProducts();
        Task<ProductDto> GetProduct(int id);
        Task<int> CreateProduct(CreateProductDto productForCreation);
        Task UpdateProduct(UpdateProductDto productForUpdate);
        Task DeleteProduct(int id);
    }

    public record ProductDto(int Id, string Name, int ShopId);
    public record CreateProductDto(string Name, int ShopId);
    public record UpdateProductDto(int Id, string Name, int ShopId);
}