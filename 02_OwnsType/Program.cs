using System;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _02_OwnsType
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();
                context.Players.Add(new Player()
                {
                    Name = "Yarik",
                    Address = new Address() { City = "Donetsk" }
                });
                context.SaveChanges();
                foreach (var player in context.Players)
                {
                    Console.WriteLine($"{player.Name} {player.Address?.City}");
                }
            }
        }
    }
}
