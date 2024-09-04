using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Propelo.Data;
using Propelo.DTO;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class LogoRepository : ILogoRepository
    {
        private readonly ApplicationDBContext _context;
        private readonly IMapper _mapper;

        public LogoRepository(ApplicationDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<Logo> CreateLogoAsync(LogoDTO logoDTO)
        {
            var logo = _mapper.Map<Logo>(logoDTO);

            // Save the file to the server
            string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFile");
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            string filePath = Path.Combine(path, logo.LogoName);

            // Save the file to the path
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await logoDTO.Logo.CopyToAsync(stream);
            }
            logo.LogoPath = filePath;

            _context.Logos.Add(logo);

            return logo;
        }

        public async Task<Logo> GetLogoByIdAsync(int id)
        {
            return await _context.Logos.Where(l => l.Id == id).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Logo>> GetLogosAsync()
        {
            return await _context.Logos.OrderBy(l => l.Id).ToListAsync();
        }

        public async Task<bool> SaveAllAsync()
        {
            var save= await _context.SaveChangesAsync();
            return save > 0? true:false;
        }

        public async Task<Logo> UpdateLogoAsync(LogoDTO logoDTO, int logoId)
        {
            // Retrieve the existing logo from the database
            var logo = await _context.Logos.Where(l => l.Id == logoId).FirstOrDefaultAsync();

            if (logo == null)
            {
                // Handle the case where the logo is not found (e.g., throw an exception or return null)
                throw new Exception("Logo not found");
            }

            // Update the properties of the logo
            _mapper.Map(logoDTO, logo);

            // Check if a new file is provided
            if (logoDTO.Logo != null)
            {
                // Save the new file to the server
                string path = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFile");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                // Construct the new file path
                string newFilePath = Path.Combine(path, logo.LogoName);

                // Save the new file to the path
                using (var stream = new FileStream(newFilePath, FileMode.Create))
                {
                    await logoDTO.Logo.CopyToAsync(stream);
                }

                // Delete the old file if it exists
                if (!string.IsNullOrEmpty(logo.LogoPath) && File.Exists(logo.LogoPath))
                {
                    File.Delete(logo.LogoPath);
                }

                // Update the logo path to the new file path
                logo.LogoPath = newFilePath;
            }

            // Update the logo entity in the context
            _context.Logos.Update(logo);

            // Save the changes to the database
            await _context.SaveChangesAsync();

            return logo;
        }
    }
}
