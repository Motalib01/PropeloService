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
    public class LogoController : ControllerBase
    {
        private readonly ILogoRepository _logoRepository;
        private readonly IMapper _mapper;

        public LogoController(ILogoRepository logoRepository, IMapper mapper)
        {
            _logoRepository = logoRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLogos()
        {
            var logos = await _logoRepository.GetLogosAsync();
            return Ok(logos);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLogotById(int id)
        {
            var logo = await _logoRepository.GetLogoByIdAsync(id);

            if (logo == null)
                return NotFound();

            return Ok(logo);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePicturet([FromForm] LogoDTO logoDto)
        {
            var logo = await _logoRepository.CreateLogoAsync(logoDto);

            if (logo == null)
                return StatusCode(500, "File Upload Failed");

            if (await _logoRepository.SaveAllAsync())
                return Ok("File Upload Successful");

            return StatusCode(500, "Saving to Database Failed");
        }
    }
}
