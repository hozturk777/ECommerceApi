using AutoMapper;
using ECommerceApi.Context;

namespace ECommerceApi.Applications.CountryOperations.Quaries.GetCountry
{
    public class GetCountryQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public GetCountryQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCountryViewModel> Handle()
        {
            var country = _context.Countries
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetCountryViewModel> countryList = _mapper.Map<List<GetCountryViewModel>>(country);
            return countryList;
        }

        public class GetCountryViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
