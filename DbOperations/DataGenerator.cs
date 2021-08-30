using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using( var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie {
                        Name= "Schindler List",
                        Genre= "History",
                        Year = new DateTime(1994,3,4),
                        Price= (float)13.14,
                        Director= "Steven Zailian",
                        DirectorId= 1,
                        Actors= "Liam Neeson",
                        ActorIds = 1,

                    }
                    );
                context.SaveChanges();

            }
        }
    }
}
