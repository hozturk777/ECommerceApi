using AutoMapper;
using ECommerceApi.Applications.CategoryOperations.Quaries.GetCategory;
using ECommerceApi.Applications.CategoryOperations.Quaries.GetCategoryById;
using ECommerceApi.Entities;
using static ECommerceApi.Applications.AddressOperations.Commands.CreateAddress.CreateAddressCommand;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAddressById.GetAddresByIdQuery;
using static ECommerceApi.Applications.AddressOperations.Quaries.GetAdress.GetAddressQuery;
using static ECommerceApi.Applications.CategoryOperations.Commands.CreateCategory.CreateCategoryCommand;
using static ECommerceApi.Applications.CategoryOperations.Quaries.GetCategory.GetCategoryQuery;
using static ECommerceApi.Applications.CategoryOperations.Quaries.GetCategoryById.GetCategoryByIdQuery;
using static ECommerceApi.Applications.CountryOperations.Commands.CreateCountry.CreateCountryCommand;
using static ECommerceApi.Applications.CountryOperations.Quaries.GetCountry.GetCountryQuery;
using static ECommerceApi.Applications.CountryOperations.Quaries.GetCountryById.GetCountryByIdQuery;
using static ECommerceApi.Applications.ProductOperations.Commands.CreateProduct.CreateProductCommand;
using static ECommerceApi.Applications.ProductOperations.Quaries.GetProduct.GetProductQuery;
using static ECommerceApi.Applications.ProductOperations.Quaries.GetProductById.GetProductByIdQuery;

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
            // Country Post
            CreateMap<CreateCountryModel, Country>();


            // Category Get
            CreateMap<Category, GetCategoryViewModel>();
            CreateMap<Category, GetCategoryByIdViewModel>();

            // Category Post
            CreateMap<CreateCategoryModel, Category>();


            // Product Get
            CreateMap<Product, GetProductViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => $"{src.Category.Name}"));
            CreateMap<Product, GetProductByIdViewModel>()
                .ForMember(dest => dest.Category, opt => opt.MapFrom(src => $"{src.Category.Name}"));

            // Product Post
            CreateMap<CreateProductModel, Product>();
        }
    }
}
