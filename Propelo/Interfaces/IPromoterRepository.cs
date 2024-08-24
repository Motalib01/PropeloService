using Propelo.Models;

namespace Propelo.Interfaces
{
    //Done
    public interface IPromoterRepository
    {
        bool PromoterExists(int promoterId);
        bool CreatePromoter(Promoter promoter);
        bool UpdatePromoter(Promoter promoter);
        bool Save();
    }
}
