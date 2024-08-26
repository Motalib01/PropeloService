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
    public class ApartmentPictureController : ControllerBase
    {
        private readonly IApartmentPictureRepository _apartmentPictureRepository;
        private readonly IMapper _mapper;

        public ApartmentPictureController(IApartmentPictureRepository apartmentPictureRepository, IMapper mapper)
        {
            _apartmentPictureRepository = apartmentPictureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<ApartmentPicture>))]
        public IActionResult GetApartmentPictures()
        {
            var apartmentPictures = _mapper.Map<List<ApartmentPictureDTO>>(_apartmentPictureRepository.GetApartmentPictures());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(apartmentPictures);

        }
    }
}
