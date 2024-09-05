using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class PropertyPictureRepository : IPropertyPictureRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public PropertyPictureRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PropertyPicture>> CreatePropertyPictureAsync(PropertyPictureDTO propertyPictureDTO)
        {
            var pictures = new List<PropertyPicture>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in propertyPictureDTO.Pictures)
            {
                var picture = new PropertyPicture
                {
                    PropertyId = propertyPictureDTO.PropertyId,
                    PictureName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName),
                    // Set the PicturePath and PictureSize manually
                    PictureSize = file.Length
                };

                string filePath = Path.Combine(path, picture.PictureName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                picture.PicturePath = filePath;

                pictures.Add(picture);
                _context.PropertyPictures.Add(picture);
            }

            return pictures;
        }

        public async Task<PropertyPicture> GetPropertyPictureByIdAsync(int id)
        {
            return await _context.PropertyPictures.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PropertyPicture>> GetPropertyPicturesAsync()
        {
            return await _context.PropertyPictures.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            var save = await _context.SaveChangesAsync();
            return save > 0 ? true : false;
        }
    }
}
