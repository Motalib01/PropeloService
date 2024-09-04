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
    }
}
