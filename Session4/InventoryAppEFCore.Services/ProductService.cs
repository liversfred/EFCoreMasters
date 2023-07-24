using AutoMapper;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace InventoryAppEFCore.Services
{
    public class ProductService : IProductService
    {
        private readonly InventoryAppEfCoreContext _dbContext;
        private readonly IMapper _mapper;

        public ProductService(InventoryAppEfCoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await _dbContext.Products.ProjectTo<ProductDto>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}