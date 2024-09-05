using Propelo.DTO;
using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IApartmentPictureRepository
    {
        Task<List<ApartmentPicture>> CreateApartmentPictureAsync(ApartmentPictureDTO apartmentPictureDTO);
        Task<IEnumerable<ApartmentPicture>> GetPicturesAsync();
        Task<ApartmentPicture> GetPictureByIdAsync(int id);
        Task<bool> SaveAllAsync();

    }
}
