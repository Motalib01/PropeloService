using Propelo.Models;

namespace Propelo.Interfaces
{
    //Done
    public interface IPropertyRepository
    {
        ICollection<Property> GetProperties();
        bool PropertyExists(int propertyId);
        bool CreateProperty(Property property);
        bool UpdateProperty(Property property);
        bool DeleteProperty(Property property);
        bool Save();
    }
}
