using ECommerceApi.Context;

namespace ECommerceApi.Applications.CountryOperations.Commands.UpdateCountry
{
    public class UpdateCountryCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }
        public UpdateCountryModel model { get; set; }

        public UpdateCountryCommand(ECommerceContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var country = _context.Countries
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == Id);
            if (country == null) 
            {
                throw new InvalidOperationException("Böyle Bir Ülke Yok!");
            }
            else
            {
                country.Name = model.Name != null ? model.Name : country.Name;
                _context.SaveChanges();
            }
        }

        public class UpdateCountryModel
        {
            public string? Name { get; set; }
        }
    }
}
