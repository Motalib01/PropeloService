﻿using Microsoft.EntityFrameworkCore;
using Propelo.Models;

namespace Propelo.Data
{
    public class ApplicationDBContext: DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options)
            : base(options)
        {
        }
        public DbSet<Promoter> Promoters { get; set; }
        public DbSet<Property> Properties { get; set; }
        public DbSet<PropertyPicture> PropertyPictures { get; set; }
        public DbSet<Apartment> Apartments { get; set; }
        public DbSet<ApartmentPicture> ApartmentPictures { get; set; }
        public DbSet<ApartmentDocument> ApartmentDocuments { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Setting> Settings { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Promoter relationships
            modelBuilder.Entity<Promoter>()
                .HasMany(p=>p.properties)
                .WithOne(p=>p.Promoter)
                .HasForeignKey(p=>p.PromoterID)
                .HasPrincipalKey(p=>p.ID);

            //Property relationships
            modelBuilder.Entity<Property>()
                .HasMany(p=>p.Apartments)
                .WithOne(p=>p.Property)
                .HasForeignKey(p=>p.PropertyId)
                .HasPrincipalKey(p=>p.ID);

            modelBuilder.Entity<Property>()
                .HasMany(p=>p.PropertyPictures)
                .WithOne(p=>p.Property)
                .HasForeignKey(p=>p.PropertyId)
                .HasPrincipalKey(p=>p.ID);


            //Apartment relationships
            modelBuilder.Entity<Apartment>()
                .HasMany(p=>p.Areas)
                .WithOne(p=>p.Apartment)
                .HasForeignKey(p=>p.ApartmentId)
                .HasPrincipalKey(p=>p.Id);

            modelBuilder.Entity<Apartment>()
                .HasMany(p=>p.ApartmentDocuments)
                .WithOne(p=>p.Apartment)
                .HasForeignKey(p=>p.ApartmentId)
                .HasPrincipalKey(p=>p.Id);

            modelBuilder.Entity<Apartment>()
                .HasMany(p=>p.ApartmentPictures)
                .WithOne(p=>p.Apartment)
                .HasForeignKey(p=>p.ApartmentId)
                .HasPrincipalKey(p=>p.Id);

        }


    }
    
}
