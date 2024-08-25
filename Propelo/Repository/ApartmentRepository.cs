using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class ApartmentRepository : IApartmentRepository
    {
        private readonly ApplicationDBContext _context;

        public ApartmentRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool ApartmentExists(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public bool CreateApartment(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApartment(Apartment apartment)
        {
            throw new NotImplementedException();
        }

        public ICollection<Apartment> GetApartments()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateApartment(Apartment apartment)
        {
            throw new NotImplementedException();
        }
    }
}
