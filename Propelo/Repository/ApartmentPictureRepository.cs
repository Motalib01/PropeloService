﻿using AutoMapper;
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

        public async Task<ApartmentPicture> CreatePictureAsync(ApartmentPictureDTO apartmentPictureDTO)
        {
            var picture = _mapper.Map<ApartmentPicture>(apartmentPictureDTO);

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
                await apartmentPictureDTO.Picture.CopyToAsync(stream);
            }

            picture.PicturePath = filePath;

            _context.ApartmentPictures.Add(picture);

            return picture;
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
