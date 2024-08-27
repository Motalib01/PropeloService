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
    public class ApartmentPictureController : ControllerBase
    {
        private readonly IApartmentPictureRepository _apartmentPictureRepository;
        private readonly IMapper _mapper;

        public ApartmentPictureController(IApartmentPictureRepository apartmentPictureRepository, IMapper mapper)
        {
            _apartmentPictureRepository = apartmentPictureRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApartmentPicture([FromBody] ApartmentPictureDTO apartmentPictureCreate)
        {
            if (apartmentPictureCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var apartmentPicture = _mapper.Map<ApartmentPicture>(apartmentPictureCreate);

            if (!_apartmentPictureRepository.CreateApartmentPicture(apartmentPicture))
            {
                ModelState.AddModelError("", $"Something went wrong saving the apartment picture {apartmentPicture.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }
    }
}
