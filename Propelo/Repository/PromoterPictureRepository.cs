using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class PromoterPictureRepository : IPromoterPictureRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public PromoterPictureRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<PromoterPicture> CreatePromoterPictureAsync(PromoterPictureDTO promoterPictureDTO)
        {
            var picture = _mapper.Map<PromoterPicture>(promoterPictureDTO);

            // Save the file to the server
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, picture.PictureName);

            // Save the file to the path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await promoterPictureDTO.Picture.CopyToAsync(stream);
            }

            picture.PicturePath = filePath;

            _context.PromoterPictures.Add(picture);

            return picture;
        }

        public async Task<PromoterPicture> GetPromoterPictureByIdAsync(int id)
        {
            return await _context.PromoterPictures.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<PromoterPicture>> GetPromoterPicturesAsync()
        {
            return await _context.PromoterPictures.OrderBy(a => a.Id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            var save= await _context.SaveChangesAsync();
            return save >0 ? true: false;
        }

        public async Task<PromoterPicture> UpdatePromoterPicture(PromoterPictureDTO promoterPictureDTO, int promoterPictureId)
        {
            // Retrieve the existing logo from the database
            var picture = await _context.PromoterPictures.Where(l => l.Id == promoterPictureId).FirstOrDefaultAsync();

            if (picture == null)
            {
                // Handle the case where the logo is not found (e.g., throw an exception or return null)
                throw new Exception("Logo not found");
            }

            // Update the properties of the logo
            _mapper.Map(promoterPictureDTO, picture);

            // Check if a new file is provided
            if (promoterPictureDTO.Picture != null)
            {
                // Save the new file to the server
                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Construct the new file path
                string newFilePath = Path.Combine(path, picture.PictureName);

                // Save the new file to the path
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await promoterPictureDTO.Picture.CopyToAsync(stream);
                }

                // Delete the old file if it exists
                if (!string.IsNullOrEmpty(picture.PicturePath) && File.Exists(picture.PicturePath))
                {
                    File.Delete(picture.PicturePath);
                }

                // Update the logo path to the new file path
                picture.PicturePath = newFilePath;
            }

            // Update the logo entity in the context
            _context.PromoterPictures.Update(picture);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return picture;
        }
    }
}
