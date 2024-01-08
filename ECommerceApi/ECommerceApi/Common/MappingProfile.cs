using AutoMapper;
using ECommerceApi.Entities;
using static ECommerceApi.Applications.AddressOperations.Commands.CreateAddress.CreateAddressCommand;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAddressById.GetAddresByIdQuery;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAdress.GetAddressQuery;

namespace ECommerceApi.Common
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Address Get
            CreateMap<Address, GetAddressViewModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => $"{src.Country.Name}"));
            CreateMap<Address, GetAddressByIdViewModel>()
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => $"{src.Country.Name}"));

            // Address Post
            CreateMap<CreateAddressModel, Address>();
        }
    }
}
