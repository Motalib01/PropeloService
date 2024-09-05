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

        public ApartmentPictureRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<ApartmentPicture>> CreateApartmentPictureAsync(ApartmentPictureDTO apartmentPictureDTO)
        {
            var pictures = new List<ApartmentPicture>();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");

            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            foreach (var file in apartmentPictureDTO.Pictures)
            {
                var picture = new ApartmentPicture
                {
                    ApartmentId = apartmentPictureDTO.ApartmentId,
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
                _context.ApartmentPictures.Add(picture);
            }

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
