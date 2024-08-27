using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IApartmentDocumentRepository
    {
        ApartmentDocument GetApartmentDocument(int apartmentDocumentId);
        bool ApartmentDocumentExists(int apartmentDocumentId);
        bool CreateApartmentDocument(ApartmentDocument apartmentDocument);
        bool UpdateApartmentDocument(ApartmentDocument apartmentDocument);
        bool DeleteApartmentDocument(ApartmentDocument apartmentDocument);
        bool Save();
    }
}
