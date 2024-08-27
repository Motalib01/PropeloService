using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IApartmentPictureRepository
    {
        ApartmentPicture GetApartmentPicture(int apartmentPictureId);
        bool ApartmentPictureExists(int apartmentPictureId);
        bool CreateApartmentPicture(ApartmentPicture apartmentPicture);
        bool UpdateApartmentPicture(ApartmentPicture apartmentPicture);
        bool DeleteApartmentPicture(ApartmentPicture apartmentPicture);
        bool Save();

    }
}
