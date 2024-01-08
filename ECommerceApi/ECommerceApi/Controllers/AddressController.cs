using AutoMapper;
using ECommerceApi.Applications.AddressOperations.Commands.CreateAddress;
using ECommerceApi.Applications.AddressOperations.Quaries.GetAddressById;
using ECommerceApi.Applications.AddressOperations.Quaries.GetAdress;
using ECommerceApi.Context;
using Microsoft.AspNetCore.Mvc;
using static ECommerceApi.Applications.AddressOperations.Commands.CreateAddress.CreateAddressCommand;

namespace ECommerceApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AddressController : ControllerBase
    {
        private readonly ECommerceContext _context;
        private readonly IMapper _mapper;

        public AddressController(ECommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet (Name = "GetAddress")]
        public IActionResult Get()
        {
            GetAddressQuery query = new GetAddressQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("id")]
        public IActionResult GetById(int id)
        {
            GetAddresByIdQuery query = new GetAddresByIdQuery(_context, _mapper);
            query.Id = id;
            var result = query.Handle();
            return Ok(result);
        }

        [HttpPost (Name = "CreateAddress")]
        public IActionResult Create([FromBody] CreateAddressModel model)
        {
            CreateAddressCommand command = new CreateAddressCommand(_context, _mapper);
            command.model = model;
            command.Handle();
            return Ok();
        }
    }
}
