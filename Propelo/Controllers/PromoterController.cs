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
    public class PromoterController : ControllerBase
    {
        private readonly IPromoterRepository _promoterRepository;
        private readonly IMapper _mapper;

        public PromoterController(IPromoterRepository promoterRepository, IMapper mapper)
        {
            _promoterRepository = promoterRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type= typeof(IEnumerable<Promoter>))]
        public IActionResult GetPromoters()
        {
            var promoters =_mapper.Map<List<PromoterDTO>>(_promoterRepository.GetPromoters());
            
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(promoters);
        }

        [HttpGet("{promoterId}")]
        [ProducesResponseType(200, Type= typeof(Promoter))]
        [ProducesResponseType(400)]
        public IActionResult GetPromoter(int promoterId)
        {
            if(!_promoterRepository.PromoterExists(promoterId))
                return NotFound();

            var promoter = _mapper.Map<List<PromoterDTO>>(_promoterRepository.GetPromoter(promoterId));

            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(promoter);

        }
    }
}
