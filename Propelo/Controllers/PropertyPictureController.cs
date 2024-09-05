using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;
using Propelo.Repository;

namespace Propelo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyPictureController : ControllerBase
    {
        private readonly IPropertyPictureRepository _propertyPictureRepository;
        private readonly IMapper _mapper;

        public PropertyPictureController(IPropertyPictureRepository propertyPictureRepository, IMapper mapper)
        {
            _propertyPictureRepository = propertyPictureRepository;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetPicturets()
        {
            var Picturets = await _propertyPictureRepository.GetPropertyPicturesAsync();
            return Ok(Picturets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetPropertyPicturesAsync(int id)
        {
            var Picturet = await _propertyPictureRepository.GetPropertyPictureByIdAsync(id);

            if (Picturet == null)
                return NotFound();

            return Ok(Picturet);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePictures([FromForm] PropertyPictureDTO pictureDto)
        {
            if (pictureDto.Pictures == null || !pictureDto.Pictures.Any())
            {
                return BadRequest("No files uploaded.");
            }

            // Call the repository method to save multiple pictures
            var pictures = await _propertyPictureRepository.CreatePropertyPictureAsync(pictureDto);

            if (pictures == null)
                return StatusCode(500, "File Upload Failed");

            if (await _propertyPictureRepository.SaveAllAsync())
                return Ok("Files Uploaded Successfully");

            return StatusCode(500, "Saving to Database Failed");
        }

    }
}
