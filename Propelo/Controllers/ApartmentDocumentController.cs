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

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApartmentDocument>))]
        public IActionResult GetApartmentDocuments()
        {
            var documents = _mapper.Map<List<ApartmentDocumentDTO>>(_apartmentDocumentRepository.GetApartmentDocuments());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(documents);

        }

    }
}
