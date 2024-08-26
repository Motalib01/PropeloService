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
    }
}
