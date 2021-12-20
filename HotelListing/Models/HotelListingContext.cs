using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class HotelListingContext : DbContext
    {
        public HotelListingContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData
                (
                    new Country { Id = 1, Name = "Australia", Code = 110 },
                    new Country { Id = 2, Name = "Austria", Code = 111 },
                    new Country { Id = 3, Name = "Bangladesh", Code = 112 },
                    new Country { Id = 4, Name = "Belgium", Code = 113 },
                    new Country { Id = 5, Name = "Benin", Code = 114 },
                    new Country { Id = 6, Name = "Cambodia", Code = 115 },
                    new Country { Id = 7, Name = "Canada", Code = 116 },
                    new Country { Id = 8, Name = "Denmark", Code = 117 },
                    new Country { Id = 9, Name = "Ecuador", Code = 118 },
                    new Country { Id = 10, Name = "Finland", Code = 119 }
                );

            builder.Entity<Hotel>().HasData
                (
                    new Hotel 
                    { 
                        Id = 1, Name = "Australia Hotel", Address = "Australia", Rating = 4.5, CountryId = 1
                    },

                    new Hotel
                    {
                        Id = 2, Name = "Belgium Hotel", Address = "Belgium",
                        Rating = 4.1, CountryId = 4
                    },

                    new Hotel
                    {
                        Id = 3,
                        Name = "Bangladesh Hotel",
                        Address = "Bangladesh",
                        Rating = 3.8,
                        CountryId = 3
                    },

                    new Hotel
                    {
                        Id = 4,
                        Name = "Canada Hotel",
                        Address = "Canada",
                        Rating = 4.3,
                        CountryId = 7
                    },

                    new Hotel
                    {
                        Id = 5,
                        Name = "Denmark Hotel",
                        Address = "Denmark",
                        Rating = 4.0,
                        CountryId = 8
                    }


                );
        }
    }
}
