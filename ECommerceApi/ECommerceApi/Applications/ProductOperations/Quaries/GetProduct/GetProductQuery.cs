using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Applications.ProductOperations.Quaries.GetProduct
{
    public class GetProductQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public GetProductQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetProductViewModel> Handle()
        {
            var product = _context.Products
                .Where(x => x.IsActive == true)
                .Include(x => x.Category)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetProductViewModel> productList = _mapper.Map<List<GetProductViewModel>>(product);
            return productList;
        }

        public class GetProductViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public byte[]? Photo { get; set; }
            public float? Price { get; set; }
            public string? Description { get; set; }
            public int? Stock { get; set; }
            public int? CategoryId { get; set; }
            public string? Category { get; set; }
          
        }

    }
}
