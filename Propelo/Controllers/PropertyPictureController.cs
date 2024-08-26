using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;
using Propelo.Repository;

namespace Propelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyPictureController : ControllerBase
    {
        private readonly IPropertyPictureRepository _propertyPictureRepository;
        private readonly IMapper _mapper;

        public PropertyPictureController(IPropertyPictureRepository propertyPictureRepository, IMapper mapper)
        {
            _propertyPictureRepository = propertyPictureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<PropertyPicture>))]
        public IActionResult GetPropertyPictures()
        {
            var propertyPictures = _mapper.Map<List<PropertyPictureDTO>>(_propertyPictureRepository.GetPropertyPictures);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(propertyPictures);
        }
    }
}
