﻿// <auto-generated />
using System;
using GameLibraryApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GameLibraryApi.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GameLibraryApi.Models.Game", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Developer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("GameMode")
                        .HasColumnType("int");

                    b.Property<int>("Genre")
                        .HasColumnType("int");

                    b.Property<int>("Metascore")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Platform")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReleaseDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Userscore")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Games");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Developer = "Larian Studios Games",
                            GameMode = 1,
                            Genre = 4,
                            Metascore = 96,
                            Name = "Baldur's Gate 3",
                            Platform = 1,
                            ReleaseDate = new DateTime(2023, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 7.7999999999999998
                        },
                        new
                        {
                            Id = 2,
                            Developer = "From Software",
                            GameMode = 1,
                            Genre = 4,
                            Metascore = 96,
                            Name = "Elden Ring",
                            Platform = 1,
                            ReleaseDate = new DateTime(2022, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 7.7999999999999998
                        },
                        new
                        {
                            Id = 3,
                            Developer = "SCE Santa Monica",
                            GameMode = 1,
                            Genre = 6,
                            Metascore = 94,
                            Name = "God of War:Ragnarok",
                            Platform = 2,
                            ReleaseDate = new DateTime(2022, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 7.9000000000000004
                        },
                        new
                        {
                            Id = 4,
                            Developer = "Valve Software",
                            GameMode = 1,
                            Genre = 1,
                            Metascore = 96,
                            Name = "Half-Life 2",
                            Platform = 1,
                            ReleaseDate = new DateTime(2004, 11, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 9.1999999999999993
                        },
                        new
                        {
                            Id = 5,
                            Developer = "Rockstar North",
                            GameMode = 2,
                            Genre = 6,
                            Metascore = 96,
                            Name = "GTA 5",
                            Platform = 1,
                            ReleaseDate = new DateTime(2015, 4, 13, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 7.9000000000000004
                        },
                        new
                        {
                            Id = 6,
                            Developer = "Rockstar North",
                            GameMode = 1,
                            Genre = 1,
                            Metascore = 96,
                            Name = "Bioshock",
                            Platform = 1,
                            ReleaseDate = new DateTime(2007, 8, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 8.5999999999999996
                        },
                        new
                        {
                            Id = 7,
                            Developer = "LucasArts",
                            GameMode = 1,
                            Genre = 2,
                            Metascore = 94,
                            Name = "Grim Fandango",
                            Platform = 1,
                            ReleaseDate = new DateTime(1998, 10, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 9.0
                        },
                        new
                        {
                            Id = 8,
                            Developer = "Rockstar Games",
                            GameMode = 1,
                            Genre = 6,
                            Metascore = 97,
                            Name = "Red Dead Redemption 2",
                            Platform = 1,
                            ReleaseDate = new DateTime(2018, 11, 26, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 8.3000000000000007
                        },
                        new
                        {
                            Id = 9,
                            Developer = "CD Projekt Red Studio",
                            GameMode = 1,
                            Genre = 4,
                            Metascore = 91,
                            Name = "The Wither 3: Wild Hunt",
                            Platform = 1,
                            ReleaseDate = new DateTime(2015, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 9.0999999999999996
                        },
                        new
                        {
                            Id = 10,
                            Developer = "Sickhead Games",
                            GameMode = 1,
                            Genre = 4,
                            Metascore = 89,
                            Name = "Stardew Valley",
                            Platform = 1,
                            ReleaseDate = new DateTime(2016, 12, 14, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Userscore = 7.7999999999999998
                        });
                });

            modelBuilder.Entity("GameLibraryApi.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            PasswordHash = "$2a$11$fUnQUFbf4M60oemaV26EUOFkigpSqCMg2JowjStVWVVkntQmXMorm",
                            Role = "Admin",
                            Username = "admin"
                        },
                        new
                        {
                            Id = 2,
                            PasswordHash = "$2a$11$WJH5AOwlL.H7IkHhA6IvSOuovdUbrJYcI4.jAaFoqj6DMTB.hyYbO",
                            Role = "User",
                            Username = "altan"
                        },
                        new
                        {
                            Id = 3,
                            PasswordHash = "$2a$11$sLKC.xd0xpjzgfioUEjgf.3orBL7Gvdl7wIFq9.DLaQVR0SgOcZGi",
                            Role = "User",
                            Username = "patika"
                        });
                });

            modelBuilder.Entity("GameLibraryApi.Models.UserGame", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("GameId")
                        .HasColumnType("int");

                    b.HasKey("UserId", "GameId");

                    b.HasIndex("GameId");

                    b.ToTable("UserGames");

                    b.HasData(
                        new
                        {
                            UserId = 2,
                            GameId = 1
                        },
                        new
                        {
                            UserId = 2,
                            GameId = 2
                        },
                        new
                        {
                            UserId = 2,
                            GameId = 9
                        },
                        new
                        {
                            UserId = 3,
                            GameId = 3
                        },
                        new
                        {
                            UserId = 3,
                            GameId = 4
                        },
                        new
                        {
                            UserId = 3,
                            GameId = 5
                        });
                });

            modelBuilder.Entity("GameLibraryApi.Models.UserGame", b =>
                {
                    b.HasOne("GameLibraryApi.Models.Game", "Game")
                        .WithMany()
                        .HasForeignKey("GameId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GameLibraryApi.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Game");

                    b.Navigation("User");
                });
#pragma warning restore 612, 618
        }
    }
}
