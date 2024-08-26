using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : ControllerBase
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly IMapper _mapper;

        public PropertyController(IPropertyRepository propertyRepository, IMapper mapper)
        {
            _propertyRepository = propertyRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType (200, Type=typeof(IEnumerable<Property>))]
        public IActionResult GetProperties()
        {
            var properties = _mapper.Map<List<PropertyDTO>>(_propertyRepository.GetProperties);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(properties);
        }
    }
}
