using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IApartmentPictureRepository
    {
        bool ApartmentPictureExists(int apartmentPictureId);
        bool CreateApartmentPicture(ApartmentPicture apartmentPicture);
        bool UpdateApartmentPicture(ApartmentPicture apartmentPicture);
        bool DeleteApartmentPicture(ApartmentPicture apartmentPicture);
        bool Save();

    }
}
