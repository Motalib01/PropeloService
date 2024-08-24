namespace Propelo.Models
{
    public class ApartmentPicture
    {
        public int Id { get; set; }
        public byte[] Picture { get; set; }

        //one to many
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

    }
}
