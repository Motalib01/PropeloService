﻿namespace Propelo.Models
{
    public class Property
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateOnly ConstractionDate { get; set; }
        public DateOnly EndConstractionDate { get; set; }
        public int ApartmentsNumber { get; set; }
        public string Description { get; set; }

        //many to one
        public int PromoterID { get; internal set; }
        public Promoter Promoter { get; set; }

        //one to many
        public ICollection<Apartment> Apartments { get; set; }
        public ICollection<PropertyPicture> PropertyPictures { get; set; }
        
    }
}
