using Microsoft.EntityFrameworkCore;
using MovieManagement.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieManagement.Infrastructure.Context
{
    public class MovieManagementDbContext : DbContext
    {
        public MovieManagementDbContext(DbContextOptions<MovieManagementDbContext> options) : base(options) { }
        public DbSet<Actor> tblActors { get; set; }
        public DbSet<Movie> tblMovies { get; set; }
        public DbSet<Biography> tblBiographies { get; set; }
        public DbSet<Genre> tblGenres { get; set; }

        //we want to seed some data on migration 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Actor>().HasData(
                new Actor { Id = 1, FirstName = "Gilbert", LastName = "Kibet" },
                new Actor { Id = 2, FirstName = "Jack", LastName = "Norris" },
                new Actor { Id =3, FirstName = "Jadniwik", LastName = "The bossman" },
                new Actor { Id = 4, FirstName = "Brian", LastName = "Guniess" });

            modelBuilder.Entity<Movie>().HasData(
                new Movie { Id = 1, Name = "Game  of trones", Description = "This is description", ActorId = 1 },
                new Movie { Id = 2, Name = "Game  of tr", Description = "This is deiii", ActorId = 2 },
                new Movie { Id = 3, Name = "Game  of ", Description = "This is desc", ActorId = 1 },
                new Movie { Id = 4, Name = "Game ", Description = "This is desc", ActorId = 3}
                
                );
        }

        
    }
}
