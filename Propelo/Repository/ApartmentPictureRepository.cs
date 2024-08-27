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
            return _context.ApartmentPictures.Any(a =>a.Id == apartmentPictureId);
        }

        public bool CreateApartmentPicture(ApartmentPicture apartmentPicture)
        {
            _context.Add(apartmentPicture);
            return Save();
        }

        public bool DeleteApartmentPicture(ApartmentPicture apartmentPicture)
        {
            _context.Remove(apartmentPicture);
            return Save();
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdateApartmentPicture(ApartmentPicture apartmentPicture)
        {
            _context.Update(apartmentPicture);
            return Save();
        }
    }
}
