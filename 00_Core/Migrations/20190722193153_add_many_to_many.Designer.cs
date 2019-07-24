﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _00_Core;

namespace _00_Core.Migrations
{
    [DbContext(typeof(UefaDbContext))]
    [Migration("20190722193153_add_many_to_many")]
    partial class add_many_to_many
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("_00_Core.Models.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<bool>("isEurope");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Ukraine",
                            isEurope = true
                        },
                        new
                        {
                            Id = 2,
                            Name = "Spain",
                            isEurope = true
                        },
                        new
                        {
                            Id = 3,
                            Name = "USA",
                            isEurope = false
                        });
                });

            modelBuilder.Entity("_00_Core.Models.FootballAward", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("FootballAward");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Golden Ball"
                        });
                });

            modelBuilder.Entity("_00_Core.Models.Player", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CardCode");

                    b.Property<string>("LastName")
                        .HasColumnName("LastName");

                    b.Property<string>("Name");

                    b.Property<string>("Phone");

                    b.Property<string>("Position")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasDefaultValue("CF");

                    b.Property<int?>("TeamId");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Players");
                });

            modelBuilder.Entity("_00_Core.Models.PlayerFootballAward", b =>
                {
                    b.Property<int>("PlayerId");

                    b.Property<int>("FootballAwardId");

                    b.HasKey("PlayerId", "FootballAwardId");

                    b.HasIndex("FootballAwardId");

                    b.ToTable("PlayerFootballAward");

                    b.HasData(
                        new
                        {
                            PlayerId = 1,
                            FootballAwardId = 1
                        });
                });

            modelBuilder.Entity("_00_Core.Models.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CountryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Teams");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CountryId = 1,
                            Name = "Dynamo"
                        },
                        new
                        {
                            Id = 2,
                            CountryId = 1,
                            Name = "Shahtar"
                        });
                });

            modelBuilder.Entity("_00_Core.Models.Player", b =>
                {
                    b.HasOne("_00_Core.Models.Team", "Team")
                        .WithMany("Players")
                        .HasForeignKey("TeamId");

                    b.OwnsOne("_00_Core.Models.Address", "Address", b1 =>
                        {
                            b1.Property<int>("PlayerId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<string>("City");

                            b1.HasKey("PlayerId");

                            b1.ToTable("Players");

                            b1.HasOne("_00_Core.Models.Player")
                                .WithOne("Address")
                                .HasForeignKey("_00_Core.Models.Address", "PlayerId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("_00_Core.Models.PlayerFootballAward", b =>
                {
                    b.HasOne("_00_Core.Models.FootballAward", "FootballAward")
                        .WithMany("PlayerFootballAwards")
                        .HasForeignKey("FootballAwardId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("_00_Core.Models.Player", "Player")
                        .WithMany("PlayerFootballAwards")
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("_00_Core.Models.Team", b =>
                {
                    b.HasOne("_00_Core.Models.Country", "Country")
                        .WithMany("Teams")
                        .HasForeignKey("CountryId");
                });
#pragma warning restore 612, 618
        }
    }
}
