using _00_Core;
using System;
using _00_Core.Models;
using Microsoft.EntityFrameworkCore;

namespace _03_ObjectMapping
{
    //    Use Shadow Properties with Entity Framework Core
    //    The value and state of Shadow properties are maintained in the Change Tracker API.Shadow Properties are a useful in following conditions,

    //    When you can’t make changes to existing entity class (third party) and you want to add some fields to your model.
    //When you want certain properties to be part of your context, but don’t wish to expose them.
    //So these properties are available for all database operations, but not available in the application as they are not exposed via entity class. Let’s see how to create and use them.
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new UefaDbContext())
            {
                context.Database.Migrate();

                ShowPrivateProperty(context);
                ShowShadowProperty(context);
            }
        }

        private static void ShowShadowProperty(UefaDbContext context)
        {
            Player firstPlayer = context.Players.Find(1);
            var lastName = context.Entry(firstPlayer).Property<string>("LastName").CurrentValue;
            Console.WriteLine($"Get property value {lastName}");

            context.Entry(firstPlayer).Property<string>("LastName").CurrentValue = "Ivanov";
            context.SaveChanges();

            foreach (var player in context.Players)
            {
                Console.WriteLine(
                    $"{player.Name} {player.Phone} {context.Entry(player).Property<string>("LastName").CurrentValue}");
            }
        }

        private static void ShowPrivateProperty(UefaDbContext context)
        {
            var firstPlayer = context.Players.Find(1);
            firstPlayer.Phone = "093-344-44-19";
            context.SaveChanges();
            foreach (var player in context.Players)
            {
                Console.WriteLine($"{player.Name} {player.Phone}");
            }
        }
    }
}
