
using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

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
            _context.Add(property);
            return Save();
        }

        public bool DeleteProperty(Property property)
        {
            _context.Remove(property);
            return Save();
        }

        public ICollection<Property> GetProperties()
        {
            return _context.Properties.OrderBy(a => a.Id).ToList();
        }

        public bool PropertyExists(int propertyId)
        {
            return _context.Properties.Any(a => a.Id == propertyId);
        }

        public bool Save()
        {
            var save = _context.SaveChanges();
            return save >= 0 ? true : false;
        }

        public bool UpdateProperty(Property property)
        {
            _context.Update(property);
            return Save();
        }
    }

}
