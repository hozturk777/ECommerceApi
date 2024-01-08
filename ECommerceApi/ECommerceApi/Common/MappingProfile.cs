using AutoMapper;
using ECommerceApi.Entities;
using static ECommerceApi.Applications.AddressOperations.Commands.CreateAddress.CreateAddressCommand;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAddressById.GetAddresByIdQuery;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAdress.GetAddressQuery;
using static ECommerceApi.Applications.CountryOperations.Commands.CreateCountry.CreateCountryCommand;
using static ECommerceApi.Applications.CountryOperations.Quaries.GetCountry.GetCountryQuery;
using static ECommerceApi.Applications.CountryOperations.Quaries.GetCountryById.GetCountryByIdQuery;

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


            // Country Get
            CreateMap<Country, GetCountryViewModel>();
            CreateMap<Country, GetCountryByIdViewModel>();

            //Country Post
            CreateMap<CreateCountryModel, Country>();
        }
    }
}
