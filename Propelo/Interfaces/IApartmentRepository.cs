using Propelo.Models;

namespace Propelo.Interfaces
{
    //Done
    public interface IApartmentRepository
    {
        ICollection<Apartment> GetApartments();
        //Apartment GetApartment(int apartmentId);
        //Apartment GetApartmentByName(string apartmentName);
        //Apartment GetApartmentByRoomsNumber(int roomsNumber);
        //Apartment GetApartmentByFloor(int floorNumber);
        bool ApartmentExists(int apartmentId);
        bool CreateApartment(Apartment apartment);
        bool UpdateApartment(Apartment apartment);
        bool DeleteApartment(Apartment apartment);
        bool Save();
    }
}
