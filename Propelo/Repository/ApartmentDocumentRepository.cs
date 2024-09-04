using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;
using System.IO;
using System.Reflection.Metadata;
using System.Xml.Linq;

namespace Propelo.Repository
{
    public class ApartmentDocumentRepository : IApartmentDocumentRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public ApartmentDocumentRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ApartmentDocument> CreateDocumentAsync(ApartmentDocumentDTO apartmentDocumentDTO)
        {
            var document = _mapper.Map<ApartmentDocument>(apartmentDocumentDTO);

            // Save the file to the server
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, document.DocumentName);

            // Save the file to the path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await apartmentDocumentDTO.Document.CopyToAsync(stream);
            }

            document.DocumentPath = filePath;

            _context.ApartmentDocuments.Add(document);

            return document;
        }

        public async Task<ApartmentDocument> GetDocumentByIdAsync(int id)
        {
            return await _context.ApartmentDocuments.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApartmentDocument>> GetDocumentsAsync()
        {
            return await _context.ApartmentDocuments.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            var save = await _context.SaveChangesAsync();
            return save > 0? true:false ;
        }
    }
}
