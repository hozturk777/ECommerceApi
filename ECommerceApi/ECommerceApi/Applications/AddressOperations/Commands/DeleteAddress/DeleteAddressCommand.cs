using ECommerceApi.Context;

namespace ECommerceApi.Applications.AddressOperations.Commands.DeleteAddress
{
    public class DeleteAddressCommand
    {
        private readonly ECommerceContext _context;
        public int? Id { get; set; }

        public DeleteAddressCommand(ECommerceContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var address = _context.Addresses
                .Where(x => x.IsActive == true)
                .FirstOrDefault(a => a.Id == Id);
            if (address == null)
            {
                throw new InvalidOperationException("Böyle Bir Adres Yok!");
            }
            else
            {
                address.IsActive = false;
                _context.SaveChanges(); 
            }
        }
    }
}
