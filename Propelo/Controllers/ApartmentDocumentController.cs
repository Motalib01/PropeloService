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
    public class ApartmentDocumentController : ControllerBase
    {
        private readonly IApartmentDocumentRepository _apartmentDocumentRepository;
        private readonly IMapper _mapper;

        public ApartmentDocumentController(IApartmentDocumentRepository apartmentDocumentRepository, IMapper mapper)
        {
            _apartmentDocumentRepository = apartmentDocumentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetDocuments()
        {
            var documents = await _apartmentDocumentRepository.GetDocumentsAsync();
            return Ok(documents);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDocumentById(int id)
        {
            var document = await _apartmentDocumentRepository.GetDocumentByIdAsync(id);

            if (document == null)
                return NotFound();

            return Ok(document);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDocument([FromForm] ApartmentDocumentDTO documentDto)
        {
            var document = await _apartmentDocumentRepository.CreateDocumentAsync(documentDto);

            if (document == null)
                return StatusCode(500, "File Upload Failed");

            if (await _apartmentDocumentRepository.SaveAllAsync())
                return Ok("File Upload Successful");

            return StatusCode(500, "Saving to Database Failed");
        }
    }
}
