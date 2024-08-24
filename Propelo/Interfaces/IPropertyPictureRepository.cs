using Propelo.Models;

namespace Propelo.Interfaces
{
    //Maybe
    public interface IPropertyPictureRepository
    {
        ICollection<PropertyPicture> GetPropertyPictures(int propertyId);
        bool PropertyPictureExists(int propertyPictureId);
        bool CreatePropertyPicture(PropertyPicture propertyPicture);
        bool UpdatePropertyPicture(PropertyPicture propertyPicture);
        bool DeletePropertyPicture(PropertyPicture propertyPicture);
        bool Save();
    }
}
