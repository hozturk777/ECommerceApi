using AutoMapper;
using ECommerceApi.Context;

namespace ECommerceApi.Applications.CategoryOperations.Quaries.GetCategoryById
{
    public class GetCategoryByIdQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;
        public int Id { get; set; }

        public GetCategoryByIdQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public GetCategoryByIdViewModel Handle()
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
                GetCategoryByIdViewModel result = _mapper.Map<GetCategoryByIdViewModel>(category);
                return result;
            }
        }

        public class GetCategoryByIdViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
