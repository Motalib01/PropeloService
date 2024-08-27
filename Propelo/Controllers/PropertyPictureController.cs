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
    public class PropertyPictureController : ControllerBase
    {
        private readonly IPropertyPictureRepository _propertyPictureRepository;
        private readonly IMapper _mapper;

        public PropertyPictureController(IPropertyPictureRepository propertyPictureRepository, IMapper mapper)
        {
            _propertyPictureRepository = propertyPictureRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePropertyPicture([FromBody] PropertyPictureDTO propertyPictureCreate)
        {
            if (propertyPictureCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propertyPicture = _mapper.Map<PropertyPicture>(propertyPictureCreate);

            if (!_propertyPictureRepository.CreatePropertyPicture(propertyPicture))
            {
                ModelState.AddModelError("", $"Something went wrong saving the property picture {propertyPicture.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{propertyPictureId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdatePropertyPicture(int propertyPictureId, [FromBody] PropertyPictureDTO propertyPictureUpdate)
        {
            if (propertyPictureUpdate == null || propertyPictureId != propertyPictureUpdate.Id)
                return BadRequest(ModelState);

            if (!_propertyPictureRepository.PropertyPictureExists(propertyPictureId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var propertyPicture = _mapper.Map<PropertyPicture>(propertyPictureUpdate);

            if (!_propertyPictureRepository.UpdatePropertyPicture(propertyPicture))
            {
                ModelState.AddModelError("", $"Something went wrong updating the property picture {propertyPicture.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{propertyPictureId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeletePropertyPicture(int propertyPictureId)
        {
            if (!_propertyPictureRepository.PropertyPictureExists(propertyPictureId))
                return NotFound();

            var propertyPictureToDelete = _propertyPictureRepository.GetPropertyPicture(propertyPictureId);

            if (!_propertyPictureRepository.DeletePropertyPicture(propertyPictureToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the property picture {propertyPictureId}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
