﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
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

        [HttpGet("{propertyId}")]
        [ProducesResponseType(200, Type=typeof(Property))]
        [ProducesResponseType(400)]
        public IActionResult GetProperty(int propertyId)
        {
            if (!_propertyRepository.PropertyExists(propertyId))
                return NotFound();

            var property = _mapper.Map<List<PropertyDTO>>(_propertyRepository.GetProperty(propertyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(property);
        }

        [HttpGet("apartments/{apartmentId}")]
        [ProducesResponseType(200, Type=typeof(Property))]
        [ProducesResponseType(400)]
        public IActionResult GetPropertyByApartment(int apartmentId)
        {
            if (!_propertyRepository.PropertyExists(apartmentId))
                return NotFound();

            var property = _mapper.Map<List<PropertyDTO>>(_propertyRepository.GetPropertyByApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(property);
        }

        [HttpGet("property-pictures/{propertyId}")]
        [ProducesResponseType(200, Type=typeof(IEnumerable<PropertyPicture>))]
        [ProducesResponseType(400)]
        public IActionResult GetPropertyPicturesByProperty(int propertyId)
        {
            if (!_propertyRepository.PropertyExists(propertyId))
                return NotFound();

            var propertyPictures = _mapper.Map<List<PropertyPictureDTO>>(_propertyRepository.GetPropertyPicturesByProperty(propertyId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(propertyPictures);
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateProperty([FromBody] PropertyDTO propertyCreate)
        {
            if (propertyCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var property = _mapper.Map<Property>(propertyCreate);

            if (!_propertyRepository.CreateProperty(property))
                return StatusCode(500, "A problem happened while handling your request.");

            return Ok("Successfully created");
        }

        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreatePropertyPicture([FromBody] PropertyDTO propertyUpdate)
        {
            if (propertyUpdate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var property = _mapper.Map<Property>(propertyUpdate);

            if (!_propertyRepository.UpdateProperty(property))
                return StatusCode(500, "A problem happened while handling your request.");

            return Ok("Successfully Update");
        }

        [HttpDelete("{propertyId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteProperty(int propertyId)
        {
            if (!_propertyRepository.PropertyExists(propertyId))
                return NotFound();

            var propertyToDelete= _propertyRepository.GetProperty(propertyId);

            if (!_propertyRepository.DeleteProperty(propertyToDelete))
                return StatusCode(500, "A problem happened while handling your request.");

            return Ok("Successfully deleted");
        }
    }
}
