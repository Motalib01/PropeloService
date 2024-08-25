using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Propelo.Interfaces;

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
    }
}
