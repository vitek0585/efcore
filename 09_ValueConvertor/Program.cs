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
            //UpdatePlayers();

            using (var context = new UefaDbContext())
            {
                foreach (var player in context.Players.Where(p => p.CardCode == "1234-5678"))
                {
                    Console.WriteLine($"{player.Name} {player.Position} {player.CardCode}");
                }
            };
        }

        private static void UpdatePlayers()
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();

                foreach (var player in context.Players)
                {
                    player.CardCode = "1234-5678";
                    player.Position = Position.CF;
                }

                context.SaveChanges();
            }
        }
    }
}
