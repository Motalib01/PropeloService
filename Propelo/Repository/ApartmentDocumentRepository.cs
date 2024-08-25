using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class ApartmentDocumentRepository : IApartmentDocumentRepository
    {
        private readonly ApplicationDBContext _context;

        public ApartmentDocumentRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public bool ApartmentDocumentExists(int apartmentDocumentId)
        {
            return _context.ApartmentDocuments.Any(a=>a.Id == apartmentDocumentId);
        }

        public bool CreateApartmentDocument(ApartmentDocument apartmentDocument)
        {
            _context.Add(apartmentDocument);
            return Save();
        }

        public bool DeleteApartmentDocument(ApartmentDocument apartmentDocument)
        {
            _context.Remove(apartmentDocument);
            return Save();
        }

        public ICollection<ApartmentDocument> GetApartmentDocuments()
        {
            return _context.ApartmentDocuments.OrderBy(a => a.Id).ToList();
        }

        public bool Save()
        {
            var save= _context.SaveChanges();
            return save>0? true: false;
        }

        public bool UpdateApartmentDocument(ApartmentDocument apartmentDocument)
        {
            _context.Update(apartmentDocument);
            return Save();
        }
    }
}
