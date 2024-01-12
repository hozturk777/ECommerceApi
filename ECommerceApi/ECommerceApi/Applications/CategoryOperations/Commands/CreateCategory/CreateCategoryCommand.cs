using AutoMapper;
using ECommerceApi.Context;
using ECommerceApi.Entities;

namespace ECommerceApi.Applications.CategoryOperations.Commands.CreateCategory
{
    public class CreateCategoryCommand
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public CreateCategoryModel model { get; set; }

        public CreateCategoryCommand(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public void Handle()
        {
            var category = _context.Categories
                .FirstOrDefault(x => x.Name.ToLower() == model.Name.ToLower());
            if (category != null)
            {
                if (category.IsActive == true)
                {
                    throw new InvalidOperationException("Böyle Bir Kategori Zaten Mevcut!");
                }
                else
                {
                    category.IsActive = true;
                    category.Name = model.Name;
                    _context.SaveChanges();
                }
            }
            else
            {
                category = _mapper.Map<Category>(model);
                _context.Categories.Add(category);
                _context.SaveChanges();
            }
        }

        public class CreateCategoryModel
        {
            public string? Name { get; set; }
        }
    }
}
