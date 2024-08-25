using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Propelo.Data;
using Propelo.Interfaces;

namespace Propelo.Repository
{
    public class PropertyRepository : IPropertyRepository
    {
        private readonly ApplicationDBContext _context;

        public PropertyRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool CreateProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public bool DeleteProperty(Property property)
        {
            throw new NotImplementedException();
        }

        public ICollection<Property> GetProperties()
        {
            throw new NotImplementedException();
        }

        public bool PropertyExists(int propertyId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateProperty(Property property)
        {
            throw new NotImplementedException();
        }
    }

}
