using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using System;
using _00_Core.Models;
using Microsoft.Extensions.Options;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace _00_Core
{
    public class UefaDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<FootballAward> FootballAwards { get; set; }

        public DbSet<PlayerFootballAward> PlayerFootballAwards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=CREDOLAB-VIPO\\SQLEXPRESS;Database=UEFA2020;Trusted_Connection=True;MultipleActiveResultSets=true")
               .EnableSensitiveDataLogging()
               //             .UseLazyLoadingProxies()
               .UseLoggerFactory(CommandsLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Teams)
                .WithOne(t => t.Country);

            modelBuilder.Entity<Country>()
                .HasQueryFilter(c => c.isEurope);

            modelBuilder.Entity<Team>()
                .HasMany(c => c.Players);

            var playerModelBuilder = modelBuilder.Entity<Player>();

          
        }

        public static readonly LoggerFactory CommandsLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
    }
}
