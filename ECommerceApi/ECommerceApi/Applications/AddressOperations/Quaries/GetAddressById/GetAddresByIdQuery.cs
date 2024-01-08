using AutoMapper;
using ECommerceApi.Context;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Applications.AddressOperations.Quaries.GetAddressById
{
    public class GetAddresByIdQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetAddresByIdQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetAddressByIdViewModel Handle()
        {
            var address = _context.Addresses
                .Where(x => x.IsActive == true)
                .Include(x => x.Country)
                .FirstOrDefault(x => x.Id == Id);
            if (address == null)
            {
                throw new InvalidOperationException("Böyle Bir Adres Yok!");
            }
            GetAddressByIdViewModel addressById = _mapper.Map<GetAddressByIdViewModel>(address);
            return addressById;
        }

        public class GetAddressByIdViewModel
        {
            public int Id { get; set; }
            public string? Adres { get; set; }
            public int? CountryId { get; set; }
            public string? Country { get; set; }
        }
    }
}
