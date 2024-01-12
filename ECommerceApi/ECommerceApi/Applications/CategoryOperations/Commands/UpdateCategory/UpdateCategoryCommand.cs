using ECommerceApi.Context;

namespace ECommerceApi.Applications.CategoryOperations.Commands.UpdateCategory
{
    public class UpdateCategoryCommand
    {
        private readonly ECommerceContext _context;
        public int Id { get; set; }
        public UpdateCategoryModel model { get; set; }

        public UpdateCategoryCommand(ECommerceContext context)
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
                category.Name = model.Name != null ? model.Name : category.Name;
                _context.SaveChanges();
            }
        }

        public class UpdateCategoryModel
        {
            public string? Name { get; set; }
        }
    }
}
