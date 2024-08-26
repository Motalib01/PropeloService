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
    public class SettingController : ControllerBase
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IMapper _mapper;

        public SettingController(ISettingRepository settingRepository, IMapper mapper)
        {
            _settingRepository = settingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Setting>))]
        public IActionResult GetSettings()
        {
            var settings = _mapper.Map<List<AreaDTO>>(_settingRepository.GetSettings);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(settings);

        }

    }
}
