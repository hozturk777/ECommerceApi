using AutoMapper;
using ECommerceApi.Context;

namespace ECommerceApi.Applications.CountryOperations.Quaries.GetCountryById
{
    public class GetCountryByIdQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCountryByIdQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCountryByIdViewModel Handle()
        {
            var country = _context.Countries
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == Id);
            GetCountryByIdViewModel countryList = _mapper.Map<GetCountryByIdViewModel>(country);
            return countryList;
        }

        public class GetCountryByIdViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
