using Propelo.DTO;
using Propelo.Models;

namespace Propelo.Interfaces
{
    //Maybe
    public interface IPropertyPictureRepository
    {
        Task<List<PropertyPicture>> CreatePropertyPictureAsync(PropertyPictureDTO propertyPictureDTO);
        Task<IEnumerable<PropertyPicture>> GetPropertyPicturesAsync();
        Task<PropertyPicture> GetPropertyPictureByIdAsync(int id);
        Task<bool> SaveAllAsync();
    }
}
