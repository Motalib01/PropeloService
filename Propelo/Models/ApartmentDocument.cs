namespace Propelo.Models
{
    public class ApartmentDocument
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Document { get; set; }

        //many to one
        public int? ApartmentId { get; set; }
        public Apartment? Apartment { get; set; }
    }
}
