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

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
