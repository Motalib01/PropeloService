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
    public class AreaController : ControllerBase
    {
        private readonly IAreaRepository _areaRepository;
        private readonly IMapper _mapper;

        public AreaController(IAreaRepository areaRepository, IMapper mapper)
        {
            _areaRepository = areaRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type=typeof(IEnumerable<Area>))]
        public IActionResult GetAreas()
        {
            var areas=_mapper.Map<List<AreaDTO>>( _areaRepository.GetAreas());

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(areas);
            
        }
    }
}
