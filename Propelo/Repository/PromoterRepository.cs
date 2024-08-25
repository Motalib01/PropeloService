using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class PromoterRepository : IPromoterRepository
    {
        private readonly ApplicationDBContext _context;

        public PromoterRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool CreatePromoter(Promoter promoter)
        {
            throw new NotImplementedException();
        }

        public bool PromoterExists(int promoterId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePromoter(Promoter promoter)
        {
            throw new NotImplementedException();
        }
    }
}
