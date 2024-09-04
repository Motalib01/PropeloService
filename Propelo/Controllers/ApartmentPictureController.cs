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
        public async Task<IActionResult> GetPicturets()
        {
            var Picturets = await _apartmentPictureRepository.GetPicturesAsync();
            return Ok(Picturets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPicturetById(int id)
        {
            var Picturet = await _apartmentPictureRepository.GetPictureByIdAsync(id);

            if (Picturet == null)
                return NotFound();

            return Ok(Picturet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePicturet([FromForm] ApartmentPictureDTO PicturetDto)
        {
            var Picturet = await _apartmentPictureRepository.CreatePictureAsync(PicturetDto);

            if (Picturet == null)
                return StatusCode(500, "File Upload Failed");

            if (await _apartmentPictureRepository.SaveAllAsync())
                return Ok("File Upload Successful");

            return StatusCode(500, "Saving to Database Failed");
        }

    }
}
