﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Console;
using _00_Core.Models;

namespace _00_Core
{
    public class UefaDbContext : DbContext
    {
        public DbSet<Team> Teams { get; set; }

        public DbSet<Country> Countries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
               .UseSqlServer("Server=CREDOLAB-VIPO\\SQLEXPRESS;Database=UEFA2020;Trusted_Connection=True;MultipleActiveResultSets=true")
               .EnableSensitiveDataLogging()
               .UseLoggerFactory(CommandsLoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                .HasMany(c => c.Teams)
                .WithOne(t => t.Country)
                .OnDelete(DeleteBehavior.Cascade);

            SeedData.Seed(modelBuilder);
        }

        public static readonly LoggerFactory CommandsLoggerFactory
            = new LoggerFactory(new[] {
                new ConsoleLoggerProvider((category, level)
                    => category == DbLoggerCategory.Database.Command.Name
                       && level == LogLevel.Information, true) });
    }
}
