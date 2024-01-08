using AutoMapper;
using ECommerceApi.Applications.CountryOperations.Commands.CreateCountry;
using ECommerceApi.Applications.CountryOperations.Commands.DeleteCountry;
using ECommerceApi.Applications.CountryOperations.Commands.UpdateCountry;
using ECommerceApi.Applications.CountryOperations.Quaries.GetCountry;
using ECommerceApi.Applications.CountryOperations.Quaries.GetCountryById;
using ECommerceApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static ECommerceApi.Applications.CountryOperations.Commands.CreateCountry.CreateCountryCommand;
using static ECommerceApi.Applications.CountryOperations.Commands.UpdateCountry.UpdateCountryCommand;

namespace ECommerceApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public CountryController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Get()
        {
            GetCountryQuery query = new GetCountryQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult Get(int id)
        {
            GetCountryByIdQuery query = new GetCountryByIdQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CreateCountryModel model)
        {
            CreateCountryCommand command = new CreateCountryCommand(_context, _mapper);
            command.model = model;
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, UpdateCountryModel model)
        {
            UpdateCountryCommand command = new UpdateCountryCommand(_context);
            command.model = model;
            command.Id = id;
            command.Handle();
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            DeleteCountryCommand command = new DeleteCountryCommand(_context);
            command.Id = id;
            command.Handle();
            return Ok();
        }
    }
}
