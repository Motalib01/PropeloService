using Propelo.Models;

namespace Propelo.DTO
{
    public class ApartmentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public type Type { get; set; }
        public int Floor { get; set; }
        public int Surface { get; set; }
        public string Description { get; set; }
    }
}
