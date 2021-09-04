using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.DbOperations
{
    public class MovieStoreDbContext : DbContext, IMovieStoreDbContext
    {

        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        {
        }


        public DbSet<Movie> Movies { get ; set; }
        public DbSet<Customer> Customers { get ; set; }
        public DbSet<Director> Directors { get ; set; }
        public DbSet<Actor> Actors { get ; set ; }
        public DbSet<Order> Orders { get ; set ; }
        public DbSet<MovieActor> MovieActors { get ; set ; }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "MovieStoreDB");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<MovieActor>()
            .HasKey(bc => new { bc.MovieId, bc.ActorId });
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Movie)
                .WithMany(b => b.MovieActors)
                .HasForeignKey(bc => bc.MovieId);
            modelBuilder.Entity<MovieActor>()
                .HasOne(bc => bc.Actor)
                .WithMany(c => c.MovieActors)
                .HasForeignKey(bc => bc.ActorId);


            //modelBuilder.Entity<Movie>()
            //    .HasOne(m => m.Director)
            //    .WithMany(d => d.Movies)
            //    .HasForeignKey(m => m.DirectorId)
            //    .HasPrincipalKey(m => m.ID);

            //modelBuilder.Entity<Director>()
            //    .HasMany(d => d.Movies)
            //    .WithOne();
            //modelBuilder.Entity<Director>()
            //    .Navigation(d => d.Movies)
            //    .UsePropertyAccessMode(PropertyAccessMode.Property);
        }


    }
}
