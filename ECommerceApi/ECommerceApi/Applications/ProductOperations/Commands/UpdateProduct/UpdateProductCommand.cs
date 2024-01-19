using ECommerceApi.Context;

namespace ECommerceApi.Applications.ProductOperations.Commands.UpdateProduct
{
    public class UpdateProductCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }
        public UpdateProductModel model { get; set; }

        public UpdateProductCommand(ECommerceContext context)
        {
            _context = context;
        }
        
        public void Handle()
        {
            var product = _context.Products
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == Id);
            if (product == null)
            {
                throw new InvalidOperationException("Böyle Bir Ürün Yok!");
            }
            else
            {
                product.Name = model.Name != null ? model.Name : product.Name;
                product.Photo = model.Photo != null ? model.Photo : product.Photo;
                product.Price = model.Price != null ? model.Price : product.Price;
                product.Description = model.Description != null ? model.Description : product.Description;
                product.Stock = model.Stock != null ? model.Stock : product.Stock;
                product.CategoryId = model.CategoryId != null ? model.CategoryId : product.Id;
                _context.SaveChanges();
            }
        }

        public class UpdateProductModel
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
