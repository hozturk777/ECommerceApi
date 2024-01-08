using ECommerceApi.Context;

namespace ECommerceApi.Applications.CountryOperations.Commands.DeleteCountry
{
    public class DeleteCountryCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }

        public DeleteCountryCommand(ECommerceContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var country = _context.Countries
                .FirstOrDefault(c => c.Id == Id);
            if (country == null)
            {
                throw new InvalidOperationException("Böyle Bir Ülke Yok!");
            }
            else
            {
                country.IsActive = false;
                _context.SaveChanges();
            }
        }
    }
}
