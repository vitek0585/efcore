using System;
using System.Collections.Generic;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _05_LazyLoading
{
    class Program
    {

        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();
              
                //Console.Clear();
                //Insert(context);
                //Update(context);
            }

            //SeedDataUpdateExamples();
            //Update_1();
            //Update_1_1();
            //Update_2();
            //Update_3();
            //Update_4();
            //Update_5();
            
        }

        private static void Insert(UefaDbContext context)
        {
            var countries = new List<Country>();
            for (int i = 0; i < 2; i++)
            {
                countries.Add(new Country
                {
                    Name = $"France {i}"
                });
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();

            countries = new List<Country>();
            for (int i = 0; i < 10; i++)
            {
                countries.Add(new Country
                {
                    Name = $"France {i}"
                });
            }

            context.Countries.AddRange(countries);
            context.SaveChanges();
        }

        private static void Update(UefaDbContext context)
        {
            foreach (var country in context.Countries.TagWith("Update Countries"))
            {
                country.Name = country.Name + " (Updated)";
            }

            context.SaveChanges();
        }

        private static void Update_1()
        {
            using (var context = new UefaDbContext())
            {
                var team = context.Teams.Find(1);

                var teamToUpdate = new Team()
                {
                    Id = 1,
                    Country = context.Countries.Find(1),
                    Name = "Shahtar (Updated)"
                };

                // update all properties include country
                context.Teams.Update(teamToUpdate);
                context.SaveChanges();
            }
        }

        private static void Update_1_1()
        {
            using (var context = new UefaDbContext())
            {
                Console.WriteLine("Update");
                var team = context.Teams.Find(1);

                var teamToUpdate = new Team()
                {
                    Id = 1,
                    Country = context.Countries.Find(1),
                    Name = "Shahtar (Updated)"
                };

                context.Entry(team).State = EntityState.Detached;
                context.Teams.Update(teamToUpdate);
                context.SaveChanges();
            }
        }

        private static void Update_2()
        {
            using (var context = new UefaDbContext())
            {
                Console.WriteLine("Update_2 EntityState.Modified");
                var teamToUpdate = new Team()
                {
                    Id = 1,
                    Country = context.Countries.Find(1),
                    Name = "Shahtar (Updated_2)"
                };

                context.Entry(teamToUpdate).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        private static void Update_3()
        {
            using (var context = new UefaDbContext())
            {
                Console.WriteLine("Update_3 Explicit property modified");
                var teamToUpdate = new Team()
                {
                    Id = 1,
                    Country = context.Countries.Find(1),
                    Name = "Shahtar (Updated_3)"
                };

                context.Attach(teamToUpdate);
                context.Entry(teamToUpdate).Property(t => t.Name).IsModified = true;
                context.SaveChanges();
            }
        }

        private static void Update_4()
        {
            using (var context = new UefaDbContext())
            {
                Console.WriteLine("Update_4 Update properties");
                var teamToUpdate = new Team()
                {
                    Id = 1
                };

                context.Attach(teamToUpdate);
                teamToUpdate.Name = "Shahtar (Updated_4)";
                
                // Cannot insert explicit value for identity column in table 'Countries' when
                // IDENTITY_INSERT is set to OFF.
                var country2 = new Country() { Id = 2 };
                teamToUpdate.Country = country2;

                context.SaveChanges();
            }
        }

        private static void Update_5()
        {
            using (var context = new UefaDbContext())
            {
                Console.WriteLine("Update_5 Update properties");
                var teamToUpdate = new Team()
                {
                    Id = 1
                };

                context.Attach(teamToUpdate);
                teamToUpdate.Name = "Shahtar (Updated_5)";

                var country2 = new Country() { Id = 2 };
                context.Attach(country2);

                teamToUpdate.Country = country2;

                context.SaveChanges();
            }
        }

        private static void SeedDataUpdateExamples()
        {
            using (var context = new UefaDbContext())
            {
                context.Countries.AddRange(new Country()
                {
                    Name = "Ukraine"
                }, new Country()
                {
                    Name = "Spain"
                });

                context.Teams.Add(new Team()
                {
                    Name = "Shahtar"
                });

                context.SaveChanges();
                Console.Clear();
            }
        }
    }
}
