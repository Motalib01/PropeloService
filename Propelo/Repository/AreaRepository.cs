using Propelo.Data;
using Propelo.Interfaces;
using Propelo.Models;

namespace Propelo.Repository
{
    public class AreaRepository : IAreaRepository
    {
        private readonly ApplicationDBContext _context;

        public AreaRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public bool AreaExists(int areaId)
        {
            throw new NotImplementedException();
        }

        public bool CreateArea(Area area)
        {
            throw new NotImplementedException();
        }

        public bool DeleteArea(Area area)
        {
            throw new NotImplementedException();
        }

        public ICollection<Area> GetAreas(int ApartmentId)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateArea(Area area)
        {
            throw new NotImplementedException();
        }
    }
}
