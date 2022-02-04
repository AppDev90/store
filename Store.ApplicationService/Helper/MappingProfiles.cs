using AutoMapper;
using Store.Core.Baskets.Dto;
using Store.Core.CustomerBaskets.Entity;
using Store.Core.Identity.Addresses;
using Store.Core.Identity.Addresses.Dto;

namespace Store.ApplicationService.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {

            CreateMap<Address, AddressDto>()
                .ReverseMap();
            CreateMap<BasketDto, Basket>();
            CreateMap<BasketItemDto, BasketItem>();

        }
    }
}
