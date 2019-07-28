using System;
using System.Linq;
using _00_Core;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _09_ValueConvertor
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                foreach (var player in context.Players)
                {
                    Console.WriteLine($"{player.Name} {player.Position} {player.CardCode}");
                }

                //foreach (var player in context.Players.Where(p => p.CardCode == "ewq-1234-5678"))
                //{
                //    Console.WriteLine($"{player.Name} {player.Position} {player.CardCode}");
                //}
            };
        }
    }
}
