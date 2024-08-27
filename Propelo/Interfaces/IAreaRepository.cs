using Propelo.Models;

namespace Propelo.Interfaces
{
    //Mabey
    public interface IAreaRepository
    {
        bool AreaExists(int areaId);
        bool CreateArea(Area area);
        bool UpdateArea(Area area);
        bool DeleteArea(Area area);
        bool Save();
    }
}
