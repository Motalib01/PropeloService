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

        [HttpPut("{apartmentPictureId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateApartmentPicture(int apartmentPictureId, [FromBody] ApartmentPictureDTO apartmentPictureUpdate)
        {
            if (apartmentPictureUpdate == null || apartmentPictureId != apartmentPictureUpdate.Id)
                return BadRequest(ModelState);

            if (!_apartmentPictureRepository.ApartmentPictureExists(apartmentPictureId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var apartmentPicture = _mapper.Map<ApartmentPicture>(apartmentPictureUpdate);

            if (!_apartmentPictureRepository.UpdateApartmentPicture(apartmentPicture))
            {
                ModelState.AddModelError("", $"Something went wrong updating the apartment picture {apartmentPicture.Id}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{apartmentPictureId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteApartmentPicture(int apartmentPictureId)
        {
            if (!_apartmentPictureRepository.ApartmentPictureExists(apartmentPictureId))
                return NotFound();

            var apartmentPictureToDelete = _apartmentPictureRepository.GetApartmentPicture(apartmentPictureId);

            if (!_apartmentPictureRepository.DeleteApartmentPicture(apartmentPictureToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the apartment picture {apartmentPictureId}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
