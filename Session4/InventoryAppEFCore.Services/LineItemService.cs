using AutoMapper;
using AutoMapper.QueryableExtensions;
using InventoryAppEFCore.DataLayer;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses.TableFunctions;
using InventoryAppEFCore.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace InventoryAppEFCore.Services
{
    public class LineItemService : ILineItemService
    {
        private readonly InventoryAppEfCoreContext _dbContext;
        private readonly IMapper _mapper;

        public LineItemService(InventoryAppEfCoreContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<List<LineItemDto>> GetLineItems()
        {
            return await _dbContext.LineItems.ProjectTo<LineItemDto>(_mapper.ConfigurationProvider).ToListAsync();
        }

        public LineItemTableFunction GetLineItemsByProductId(int productId)
        {
            return _dbContext.GetLineItemsByProductId(productId).First();
        }
    }
}
