using System;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;
using Player = _02_OwnsType.Models.Player;

namespace _02_OwnsType
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                //context.Database.EnsureDeleted();
                //context.Database.EnsureCreated();

                //AddPlayers(context);
                AddPlayersThenError(context);

                foreach (var player in context.Players)
                {
                    Console.WriteLine($"{player.Name} {player.Address?.City}");
                }
            }
        }

        private static void AddPlayers(UefaDbContext context)
        {
            context.Players.Add(new Player
            {
                Name = "Rakitskiy",
                Address = new Address {City = "Donetsk"}
            });

            context.Players.Add(new Player
            {
                Name = "Milevskiy",
                // cannot be null 
                // cannot be shared by multiple owners 
                Address = new Address()
            });

            context.SaveChanges();
        }

        private static void AddPlayersThenError(UefaDbContext context)
        {
            var address = new Address { City = "Donetsk" };
            context.Players.Add(new Player
            {
                Name = "Rakitskiy",
                Address = address
            });

            context.Players.Add(new Player
            {
                Name = "Milevskiy",
                // cannot be shared by multiple owners 
                Address = address
            });

            context.Players.Add(new Player
            {
                Name = "RaHitich",
                // cannot be null 
            });

            context.SaveChanges();
        }
    }
}
