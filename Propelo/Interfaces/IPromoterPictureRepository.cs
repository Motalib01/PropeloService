using Propelo.DTO;
using Propelo.Models;

namespace Propelo.Interfaces
{
    public interface IPromoterPictureRepository
    {
        Task<PromoterPicture> CreatePromoterPictureAsync(PromoterPictureDTO promoterPictureDTO);
        Task<IEnumerable<PromoterPicture>> GetPromoterPicturesAsync();
        Task<PromoterPicture> GetPromoterPictureByIdAsync(int id);
        Task<bool> SaveAllAsync();
    }
}
