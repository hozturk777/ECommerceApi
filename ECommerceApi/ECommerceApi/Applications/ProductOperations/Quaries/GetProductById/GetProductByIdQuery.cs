using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace ECommerceApi.Applications.ProductOperations.Quaries.GetProductById
{
    public class GetProductByIdQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetProductByIdQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetProductByIdViewModel Handle()
        {
            var product = _context.Products
                .Where(x => x.IsActive == true)
                .Include(x => x.Category)
                .FirstOrDefault(x => x.Id == Id);
            if (product is null)
            {
                throw new InvalidOperationException("Böyle Bir Ürün Yok!");
            }
            GetProductByIdViewModel productList = _mapper.Map<GetProductByIdViewModel>(product);
            return productList;
        }

        public class GetProductByIdViewModel
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
