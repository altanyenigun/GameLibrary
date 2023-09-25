using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using GameLibraryApi.Common;
using GameLibraryApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GameLibraryApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Game> Games { get; set; } // Creating the Games table that will hold the Game object in the database.
        public DbSet<User> Users { get; set; } // Creating the User table that will hold the User object in the database.
        public DbSet<UserGame> UserGames { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserGame>().HasKey(us=> new {us.UserId, us.GameId}); // Method of defining both fields as foreign keys.
            base.OnModelCreating(modelBuilder);
        }
    }
}