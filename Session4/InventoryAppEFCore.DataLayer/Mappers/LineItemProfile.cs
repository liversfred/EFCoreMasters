using AutoMapper;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Mappers
{
    public class LineItemProfile : Profile
    {
        public LineItemProfile() 
        {
            CreateMap<LineItem, LineItemDto>()
                .ForMember(x => x.TotalPrice,
                    y => y.MapFrom(s => s.NumOfProducts * s.ProductPrice))
                .ForMember(x => x.SelectedProduct,
                    y => y.MapFrom(s => s.SelectedProduct));
        }
    }
}
