using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class ApartmentPictureRepository : IApartmentPictureRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApartmentPictureRepository(ApplicationDBContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<List<ApartmentPicture>> CreateApartmentPictureAsync(ApartmentPictureDTO apartmentPictureDTO)
        {
            var pictures = new List<ApartmentPicture>();
            string path = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "apaartment-picture");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in apartmentPictureDTO.Pictures)
            {
                if (file == null || file.Length == 0)
                {
                    throw new InvalidOperationException("One or more files are empty.");
                }

                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var filePath = Path.Combine(path, fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var request = _httpContextAccessor.HttpContext.Request;
                var fileUrl = $"{request.Scheme}://{request.Host}/apartment-pictures/{fileName}";

                var picture = new ApartmentPicture
                {
                    ApartmentId = apartmentPictureDTO.ApartmentId,
                    PictureName = fileName,
                    PicturePath = fileUrl,
                    PictureSize = file.Length
                };

                pictures.Add(picture);
                _context.ApartmentPictures.Add(picture);
            }

            await _context.SaveChangesAsync();

            return pictures;
        }

        public async Task<ApartmentPicture> GetPictureByIdAsync(int id)
        {
            return await _context.ApartmentPictures.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<ApartmentPicture>> GetPicturesAsync()
        {
            return await _context.ApartmentPictures.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            var save = await _context.SaveChangesAsync();
            return save > 0 ? true : false;
        }
    }
}
