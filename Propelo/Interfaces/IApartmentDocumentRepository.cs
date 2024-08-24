using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IApartmentDocumentRepository
    {
        ICollection<ApartmentDocument> GetApartmentDocuments(int apartmentId);
        bool ApartmentDocumentExists(int apartmentDocumentId);
        bool CreateApartmentDocument(ApartmentDocument apartmentDocument);
        bool UpdateApartmentDocument(ApartmentDocument apartmentDocument);
        bool DeleteApartmentDocument(ApartmentDocument apartmentDocument);
        bool Save();
    }
}
