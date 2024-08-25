using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.Interfaces;

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
    }
}
