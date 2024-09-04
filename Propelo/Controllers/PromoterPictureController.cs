using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Repository;

namespace Propelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromoterPictureController : ControllerBase
    {
        private readonly IPromoterPictureRepository _promoterPictureRepository;
        private readonly IMapper _mapper;

        public PromoterPictureController(IPromoterPictureRepository promoterPictureRepository, IMapper mapper)
        {
            _promoterPictureRepository = promoterPictureRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogos()
        {
            var logos = await _promoterPictureRepository.GetPromoterPicturesAsync();
            return Ok(logos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogotById(int id)
        {
            var logo = await _promoterPictureRepository.GetPromoterPictureByIdAsync(id);

            if (logo == null)
                return NotFound();

            return Ok(logo);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePicturet([FromForm] PromoterPictureDTO promoterPictureDto)
        {
            var picture = await _promoterPictureRepository.CreatePromoterPictureAsync(promoterPictureDto);

            if (picture == null)
                return StatusCode(500, "File Upload Failed");

            if (await _promoterPictureRepository.SaveAllAsync())
                return Ok("File Upload Successful");

            return StatusCode(500, "Saving to Database Failed");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateLogo(int id, [FromForm] PromoterPictureDTO promoterPictureDTO)
        {
            if (id <= 0)
            {
                return BadRequest("Invalid logo ID.");
            }

            var logo = await _promoterPictureRepository.UpdatePromoterPicture(promoterPictureDTO, id);

            if (logo == null)
                return StatusCode(500, "File Upload Failed");

            if (await _promoterPictureRepository.SaveAllAsync())
                return Ok("File Upload Successful");

            return StatusCode(500, "Saving to Database Failed");
        }
    }
}
