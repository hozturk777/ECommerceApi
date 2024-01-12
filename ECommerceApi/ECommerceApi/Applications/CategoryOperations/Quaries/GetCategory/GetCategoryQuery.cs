using AutoMapper;
using ECommerceApi.Context;

namespace ECommerceApi.Applications.CategoryOperations.Quaries.GetCategory
{
    public class GetCategoryQuery
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public GetCategoryQuery(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<GetCategoryViewModel> Handle()
        {
            var category = _context.Categories
                .Where(x => x.IsActive == true)
                .OrderBy(x => x.Id)
                .ToList();
            List<GetCategoryViewModel> categoryList = _mapper.Map<List<GetCategoryViewModel>>(category);
            return categoryList;
        }

        public class GetCategoryViewModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
        }
    }
}
