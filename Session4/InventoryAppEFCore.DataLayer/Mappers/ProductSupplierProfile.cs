using AutoMapper;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Mappers
{
    public class ProductSupplierProfile : Profile
    {
        public ProductSupplierProfile()
        {
            CreateMap<ProductSupplier, ProductSupplierDto>();
        }
    }
}
