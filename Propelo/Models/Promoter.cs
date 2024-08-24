namespace Propelo.Models
{
    public class Promoter
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public byte[] Picture { get; set; }


        //one to many relationship
        public ICollection<Property> properties { get; set; }

    }
}
