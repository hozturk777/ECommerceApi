using ECommerceApi.Context;

namespace ECommerceApi.Applications.AddressOperations.Commands.UpdateAddress
{
    public class UpdateAddressCommand
    {
        private readonly ECommerceContext _context;
        public int? Id { get; set; }
        public UpdateAddressModel model{ get; set; }

        public UpdateAddressCommand(ECommerceContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var address = _context.Addresses
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == Id);
            if (address == null)
            {
                throw new InvalidOperationException("Böyle Bir Adres Yok!");
            }            
            else
            {
                address.Adres = model.Adres != null ? model.Adres : address.Adres;
                address.CountryId = model.CountryId != null ? model.CountryId : address.CountryId;
                _context.SaveChanges();
            }
        }

        public class UpdateAddressModel
        {
            public string? Adres { get; set; }
            public int? CountryId { get; set; }
        }
    }
}
