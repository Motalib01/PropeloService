using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class PropertyPictureRepository : IPropertyPictureRepository
    {
        private readonly ApplicationDBContext _context;

        public PropertyPictureRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool CreatePropertyPicture(PropertyPicture propertyPicture)
        {
            _context.Add(propertyPicture);
            return Save();
        }

        public bool DeletePropertyPicture(PropertyPicture propertyPicture)
        {
            _context.Remove(propertyPicture);
            return Save();
        }

        public bool PropertyPictureExists(int propertyPictureId)
        {
            return _context.PropertyPictures.Any(a => a.Id == propertyPictureId);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save > 0 ? true : false;
        }

        public bool UpdatePropertyPicture(PropertyPicture propertyPicture)
        {
            _context.Update(propertyPicture);
            return Save();
        }
    }
}
