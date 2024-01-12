using AutoMapper;
using ECommerceApi.Applications.CategoryOperations.Commands.CreateCategory;
using ECommerceApi.Applications.CategoryOperations.Commands.DeleteCategory;
using ECommerceApi.Applications.CategoryOperations.Commands.UpdateCategory;
using ECommerceApi.Applications.CategoryOperations.Quaries.GetCategory;
using ECommerceApi.Applications.CategoryOperations.Quaries.GetCategoryById;
using ECommerceApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECommerceApi.Applications.CategoryOperations.Commands.CreateCategory.CreateCategoryCommand;
using static ECommerceApi.Applications.CategoryOperations.Commands.UpdateCategory.UpdateCategoryCommand;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public CategoryController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult Get()
        {
            GetCategoryQuery query = new GetCategoryQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            GetCategoryByIdQuery query = new GetCategoryByIdQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateCategoryModel model)
        {
            CreateCategoryCommand command = new CreateCategoryCommand(_context, _mapper);
            command.model = model;
            command.Handle();
            return Ok();
        }

        [HttpPut]
        public IActionResult Update(int id, [FromBody] UpdateCategoryModel model)
        {
            UpdateCategoryCommand command = new UpdateCategoryCommand(_context);
            command.model = model;
            command.Id = id;
            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteCategoryCommand command = new DeleteCategoryCommand(_context);
            command.Id = id;
            command.Handle();
            return Ok();
        }
    }
}
