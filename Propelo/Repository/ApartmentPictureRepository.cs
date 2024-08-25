using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class ApartmentPictureRepository : IApartmentPictureRepository
    {
        private readonly ApplicationDBContext _context;

        public ApartmentPictureRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool ApartmentPictureExists(int apartmentPictureId)
        {
            throw new NotImplementedException();
        }

        public bool CreateApartmentPicture(ApartmentPicture apartmentPicture)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApartmentPicture(ApartmentPicture apartmentPicture)
        {
            throw new NotImplementedException();
        }

        public ICollection<ApartmentPicture> GetApartmentPictures(int apartmentId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateApartmentPicture(ApartmentPicture apartmentPicture)
        {
            throw new NotImplementedException();
        }
    }
}
