using ECommerceApi.Context;

namespace ECommerceApi.Applications.ProductOperations.Commands.DeleteProduct
{
    public class DeleteProductCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }

        public DeleteProductCommand(ECommerceContext context)
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
                product.IsActive = false;
                _context.SaveChanges();
            }
        }
    }
}
