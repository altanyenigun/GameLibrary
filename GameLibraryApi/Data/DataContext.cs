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

        public DbSet<Game> Games { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // this is a way to store a List<x> prop on Model in a column in table in database 
            // Source: https://learn.microsoft.com/en-us/ef/core/modeling/value-comparers?tabs=ef5#mutable-classes
            // --

            modelBuilder.Entity<Game>()
               .Property(e => e.GameMode)
               .HasConversion(
                t => JsonSerializer.Serialize(t, (JsonSerializerOptions?)null),
                t => JsonSerializer.Deserialize<List<GameMode>>(t, (JsonSerializerOptions?)null),
                new ValueComparer<List<GameMode>>(
                   (c1, c2) => c1!.SequenceEqual(c1!),
                   c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                   c => c.ToList()
                )
            );

            modelBuilder.Entity<Game>()
            .Property(e => e.Genre)
            .HasConversion(
                t => JsonSerializer.Serialize(t, (JsonSerializerOptions?)null),
                t => JsonSerializer.Deserialize<List<GenreEnum>>(t, (JsonSerializerOptions?)null),
                new ValueComparer<List<GenreEnum>>(
                    (c1, c2) => c1!.SequenceEqual(c2!),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                )
            );

            modelBuilder.Entity<Game>()
            .Property(e => e.Platform)
            .HasConversion(
                t => JsonSerializer.Serialize(t, (JsonSerializerOptions?)null),
                t => JsonSerializer.Deserialize<List<PlatformEnum>>(t, (JsonSerializerOptions?)null),
                new ValueComparer<List<PlatformEnum>>(
                    (c1, c2) => c1!.SequenceEqual(c2!),
                    c => c.Aggregate(0, (a, v) => HashCode.Combine(a, v.GetHashCode())),
                    c => c.ToList()
                )
            );

            // --

            base.OnModelCreating(modelBuilder);
        }

    }
}