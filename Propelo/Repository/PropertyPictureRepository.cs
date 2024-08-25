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
            throw new NotImplementedException();
        }

        public bool DeletePropertyPicture(PropertyPicture propertyPicture)
        {
            throw new NotImplementedException();
        }

        public ICollection<PropertyPicture> GetPropertyPictures(int propertyId)
        {
            throw new NotImplementedException();
        }

        public bool PropertyPictureExists(int propertyPictureId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdatePropertyPicture(PropertyPicture propertyPicture)
        {
            throw new NotImplementedException();
        }
    }
}
