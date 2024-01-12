using ECommerceApi.Context;

namespace ECommerceApi.Applications.CategoryOperations.Commands.DeleteCategory
{
    public class DeleteCategoryCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }

        public DeleteCategoryCommand(ECommerceContext context)
        {
            _context = context;
        }

        public void Handle()
        {
            var category = _context.Categories
                .Where(x => x.IsActive == true)
                .FirstOrDefault(x => x.Id == Id);
            if (category == null)
            {
                throw new InvalidOperationException("Böyle Bir Kategori Yok!");
            }
            else
            {
                category.IsActive = false;
                _context.SaveChanges();
            }
        }
    }
}
