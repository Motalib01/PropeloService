namespace Propelo.DTO
{
    public class ApartmentDocumentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public byte[]? Document { get; set; }
        public int? ApartmentId { get; set; }
    }
}
