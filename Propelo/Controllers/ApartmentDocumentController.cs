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
    public class ApartmentDocumentController : ControllerBase
    {
        private readonly IApartmentDocumentRepository _apartmentDocumentRepository;
        private readonly IMapper _mapper;

        public ApartmentDocumentController(IApartmentDocumentRepository apartmentDocumentRepository, IMapper mapper)
        {
            _apartmentDocumentRepository = apartmentDocumentRepository;
            _mapper = mapper;
        }

        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateApartmentDocument([FromBody] ApartmentDocumentDTO apartmentDocumentCreate)
        {
            if (apartmentDocumentCreate == null)
                return BadRequest(ModelState);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var apartmentDocument = _mapper.Map<ApartmentDocument>(apartmentDocumentCreate);

            if (!_apartmentDocumentRepository.CreateApartmentDocument(apartmentDocument))
            {
                ModelState.AddModelError("", $"Something went wrong saving the apartment document {apartmentDocument.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully created");
        }

        [HttpPut("{apartmentDocumentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult UpdateApartmentDocument(int apartmentDocumentId, [FromBody] ApartmentDocumentDTO apartmentDocumentUpdate)
        {
            if (apartmentDocumentUpdate == null || apartmentDocumentId != apartmentDocumentUpdate.Id)
                return BadRequest(ModelState);

            if (!_apartmentDocumentRepository.ApartmentDocumentExists(apartmentDocumentId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var apartmentDocument = _mapper.Map<ApartmentDocument>(apartmentDocumentUpdate);

            if (!_apartmentDocumentRepository.UpdateApartmentDocument(apartmentDocument))
            {
                ModelState.AddModelError("", $"Something went wrong updating the apartment document {apartmentDocument.Name}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated");
        }

        [HttpDelete("{apartmentDocumentId}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public IActionResult DeleteApartmentDocument(int apartmentDocumentId)
        {
            if (!_apartmentDocumentRepository.ApartmentDocumentExists(apartmentDocumentId))
                return NotFound();

            var apartmentDocumentToDelete = _apartmentDocumentRepository.GetApartmentDocument(apartmentDocumentId);

            if (!_apartmentDocumentRepository.DeleteApartmentDocument(apartmentDocumentToDelete))
            {
                ModelState.AddModelError("", $"Something went wrong deleting the apartment document with id {apartmentDocumentId}");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully deleted");
        }
    }
}
