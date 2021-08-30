using Microsoft.EntityFrameworkCore;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.DbOperations
{
    public interface IMovieStoreDbContext
    {
        DbSet<Movie> Movies { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<Director> Directors { get; set; }
        DbSet<Actor> Actors { get; set; }
        DbSet<Order> Orders { get; set; }
        int SaveChanges();
        
    }
}
