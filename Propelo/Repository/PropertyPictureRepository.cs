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
        private readonly IHttpContextAccessor _httpContextAccessor;

        public PropertyPictureRepository(ApplicationDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<PropertyPicture>> CreatePropertyPictureAsync(PropertyPictureDTO propertyPictureDTO)
        {
            var pictures = new List<PropertyPicture>();
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "property-pictures");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in propertyPictureDTO.Pictures)
            {
                if (file == null || file.Length == 0)
                {
                    throw new InvalidOperationException("One or more files are empty.");
                }

                // Generate a unique file name
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(path, fileName);

                // Save the file to the path
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                // Generate the public URL
                var request = _httpContextAccessor.HttpContext.Request;
                var fileUrl = $"{request.Scheme}://{request.Host}/property-pictures/{fileName}";

                // Create and map the picture entity
                var picture = new PropertyPicture
                {
                    PropertyId = propertyPictureDTO.PropertyId,
                    PictureName = fileName,
                    PicturePath = fileUrl,
                    PictureSize = file.Length
                };

                pictures.Add(picture);
                _context.PropertyPictures.Add(picture);
            }

            // Save all pictures to the database
            await _context.SaveChangesAsync();

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
