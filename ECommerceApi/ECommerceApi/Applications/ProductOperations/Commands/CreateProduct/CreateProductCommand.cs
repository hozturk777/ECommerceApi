using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;

namespace ECommerceApi.Applications.ProductOperations.Commands.CreateProduct
{
    public class CreateProductCommand
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public CreateProductModel model { get; set; }

        public CreateProductCommand(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var product = _context.Products
                .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
            if (product != null)
            {
                if(product.IsActive == true)
                {
                    throw new InvalidOperationException("Böyle Bir Ürün Zaten Mevcut!");
                }
                else
                {
                    product.IsActive = true;
                    _context.SaveChanges();
                }
            }
            else
            {
                product = _mapper.Map<Product>(model);
                _context.Products.Add(product);
                _context.SaveChanges();
            }
        }

        public class CreateProductModel
        {
            public string? Name { get; set; }
            public byte[]? Photo { get; set; }
            public float? Price { get; set; }
            public string? Description { get; set; }
            public int? Stock { get; set; }
            public int? CategoryId { get; set; }
        }
    }
}
