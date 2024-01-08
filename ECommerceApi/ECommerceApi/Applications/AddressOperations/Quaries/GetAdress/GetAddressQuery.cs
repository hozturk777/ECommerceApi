using AutoMapper;
using ECommerceApi.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Applications.AddressOperations.Quaries.GetAdress
{
    public class GetAddressQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public GetAddressQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetAddressViewModel> Handle()
        {
            var address = _context.Addresses
                .Where(x => x.IsActive == true)
                .Include(x => x.Country)
                .OrderBy(x => x.Id)
                .ToList();

            List<GetAddressViewModel> addressList = _mapper.Map<List<GetAddressViewModel>>(address);
            return addressList;
        }

        public class GetAddressViewModel
        {
            public int Id { get; set; }
            public string? Adres { get; set; }
            public int? CountryId { get; set; }
            public string? Country { get; set; }

        }
    }
}
