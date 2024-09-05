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

        public async Task<List<ApartmentDocument>> CreateDocumentAsync(ApartmentDocumentDTO apartmentDocumentDTO)
        {
            var documents = new List<ApartmentDocument>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in apartmentDocumentDTO.Documents)
            {
                var document = new ApartmentDocument
                {
                    ApartmentId = apartmentDocumentDTO.ApartmentId,
                    DocumentName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName),
                    // Set the PicturePath and PictureSize manually
                    DocumentSize = file.Length
                };

                string filePath = Path.Combine(path, document.DocumentName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                document.DocumentPath = filePath;

                documents.Add(document);
                _context.ApartmentDocuments.Add(document);
            }

            return documents;
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
