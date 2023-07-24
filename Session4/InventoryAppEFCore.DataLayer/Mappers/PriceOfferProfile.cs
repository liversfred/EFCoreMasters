using AutoMapper;
using InventoryAppEFCore.DataLayer.Dtos;
using InventoryAppEFCore.DataLayer.EfClasses;

namespace InventoryAppEFCore.DataLayer.Mappers
{
    public class PriceOfferProfile : Profile
    {
        public PriceOfferProfile()
        {
            CreateMap<PriceOffer, PriceOfferDto>();
        }
    }
}
