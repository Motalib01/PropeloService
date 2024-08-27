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
    public class ApartmentController : ControllerBase
    {
        private readonly IApartmentRepository _apartmentRepository;
        private readonly IMapper _mapper;

        public ApartmentController(IApartmentRepository apartmentRepository, IMapper mapper)
        {
            _apartmentRepository = apartmentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Apartment>))]
        public IActionResult GetApartments()
        {
            var Apartments = _mapper.Map<List<ApartmentDTO>>(_apartmentRepository.GetApartments());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(Apartments);

        }

        [HttpGet("{apartmentId}")]
        [ProducesResponseType(200, Type = typeof(Apartment))]
        [ProducesResponseType(400)]
        public IActionResult GetApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var apartment = _mapper.Map<List<ApartmentDTO>>(_apartmentRepository.GetApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartment);

        }

        [HttpGet("apartment-pictures/{apartmentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApartmentPicture>))]
        [ProducesResponseType(400)]
        public IActionResult GetApartmentPicturesByApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var apartmentPictures = _mapper.Map<List<ApartmentPictureDTO>>(_apartmentRepository.GetApartmentPicturesByApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartmentPictures);

        }

        [HttpGet("apartment-documents/{apartmentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApartmentDocument>))]
        [ProducesResponseType(400)]
        public IActionResult GetApartmentDocumentsByApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var apartmentDocuments = _mapper.Map<List<ApartmentDocumentDTO>>(_apartmentRepository.GetApartmentDocumentsByApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartmentDocuments);

        }

        [HttpGet("areas/{apartmentId}")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Area>))]
        [ProducesResponseType(400)]
        public IActionResult GetAreasByApartment(int apartmentId)
        {
            if (!_apartmentRepository.ApartmentExists(apartmentId))
                return NotFound();

            var areas = _mapper.Map<List<AreaDTO>>(_apartmentRepository.GetAreasByApartment(apartmentId));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(areas);

        }
    }
}
