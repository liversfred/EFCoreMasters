using AutoMapper;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Mappers
{
    public class ReviewProfile : Profile
    {
        public ReviewProfile()
        {
            CreateMap<Review, ReviewDto>();
        }
    }
}
