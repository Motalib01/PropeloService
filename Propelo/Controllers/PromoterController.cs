using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.Interfaces;

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
    }
}
