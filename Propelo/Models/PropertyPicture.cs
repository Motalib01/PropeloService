namespace Propelo.Models
{
    public class PropertyPicture
    {
        public int? Id { get; set; }
        public byte[]? Picture { get; set; }

        //one to many
        public int? PropertyId { get; set; }
        public Property? Property { get; set; }

    }
}
