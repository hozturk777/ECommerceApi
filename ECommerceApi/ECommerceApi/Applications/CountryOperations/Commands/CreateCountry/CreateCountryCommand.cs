using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;

namespace ECommerceApi.Applications.CountryOperations.Commands.CreateCountry
{
    public class CreateCountryCommand
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public CreateCountryModel model {  get; set; }

        public CreateCountryCommand(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var country = _context.Countries
                .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
            if (country != null)
            {
                if(country.IsActive == true)
                {
                    throw new InvalidOperationException("Böyle Bir Ülke Zaten Var!");
                }
                else
                {
                    country.IsActive = true;
                    country.Name = model.Name;
                    _context.SaveChanges();
                }
            }
            else
            {
                country = _mapper.Map<Country>(model);
                _context.Countries.Add(country);
                _context.SaveChanges();
            }
        }

        public class CreateCountryModel
        {
            public string? Name { get; set; }
        }
    }
}
