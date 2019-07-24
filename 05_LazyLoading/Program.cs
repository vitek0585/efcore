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
        // since 2.1
        // Install-Package Microsoft.EntityFrameworkCore.Proxies -Version 2.2.6
        // optionsBuilder.UseLazyLoadingProxies()
        // all navigaion properties must be virtual 
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();

                Console.Clear();
                //Insert(context);
                //Update(context);
                UpdateIssue(context);
            }
        }

        private static void Insert(UefaDbContext context)
        {
            context.Countries.AddRange(new Country()
            {
                Name = "France",
            }, new Country()
            {
                Name = "Italy",
            });
            context.SaveChanges();

            context.AddRange(new List<Player>()
            {
                new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },new Player()
                {
                    Name = "RaHitich",
                    Address = new Address()
                },
                new Player()
                {
                    Name = "Milevskiy",
                    Address = new Address()
                    {
                        City = "Kiev"
                    }
                },
            });
            context.SaveChanges();
        }

        private static void Update(UefaDbContext context)
        {
            var team = context.Teams.TagWith("Update Range").Single(t => t.Id.Equals(2));
            var players = new List<Player>();
            foreach (var player in context.Players)
            {
                player.Team = team;
                players.Add(player);
            }

            //context.UpdateRange(players);
            context.SaveChanges();
        }

        private static void UpdateIssue(UefaDbContext context)
        {
            var team = context.Teams.Single(t => t.Id.Equals(2));
            var teamToUpdate = new Team()
            {
                Country = new Country() {Id = 1},
                Id = 2,
                Name = "Shahtar 3"
            };

            //context.Entry(team).State = EntityState.Detached;

            // track properties related to teamToUpdate only
            //context.Entry(teamToUpdate).State = EntityState.Modified;
            //teamToUpdate.Name = "Shahtar 77";
            //var country2 = new Country() { Id = 2 };
            //context.Attach(country2);
            //teamToUpdate.Country = country2;

            // track all properties include countries
            //context.Attach(teamToUpdate);
            //teamToUpdate.Name = "Shahtar 77";

            //var country2 = new Country() { Id = 2 };
            //context.Attach(country2);
            //teamToUpdate.Country = country2;

            // update all properties include country
            //context.Teams.Update(teamToUpdate);
            //context.Entry(teamToUpdate).State = EntityState.Modified;

            context.SaveChanges();
        }
    }
}
