﻿using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _00_Core
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(new Country
            {
                // The primary key value needs to be specified even if it's usually generated by the database.
                // Previously seeded data will be removed if the primary key is changed in any way.
                Id = 2,
                Name = "Ukraine"
            });

            modelBuilder.Entity<Team>().HasData(new
            {
                Id = 1,
                Name = "Dynamo",
                CountryId = 1
            },
            new
            {
                Id = 2,
                Name = "Shahtar",
                CountryId = 1
            });
        }
    }
}