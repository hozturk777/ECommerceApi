using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;

namespace ECommerceApi.Applications.AddressOperations.Commands.CreateAddress
{
    public class CreateAddressCommand
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public CreateAddressModel model { get; set; }

        public CreateAddressCommand(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var address = _context.Addresses
                .FirstOrDefault(x => x.Adres.ToLower() == model.Adres.ToLower());
            if (address != null)
            {
                if (address.IsActive == true)
                {
                    throw new InvalidOperationException("Böyle Bir Adres Zaten Kayıtlı!");
                }
                else
                {
                    address.IsActive = true;
                    address.CountryId = model.CountryId;
                    _context.SaveChanges();
                }
            }
            else
            {
                address = _mapper.Map<Address>(model);
                _context.Addresses.Add(address);
                _context.SaveChanges();
            }
        }

        public class CreateAddressModel
        {
            public string? Adres { get; set; }
            public int? CountryId { get; set; }
        }
    }
}
