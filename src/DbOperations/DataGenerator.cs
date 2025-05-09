﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movie_Store_WebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieStoreDbContext(serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()))
            {
                if (context.Movies.Any())
                {
                    return;
                }

                context.Actors.AddRange(
                    new Actor
                    {
                        Name = "Tom",
                        Surname = "Cruise"
                    },
                    new Actor
                    {
                        Name = "Robert",
                        Surname = "Downey"
                    },
                    new Actor
                    {
                        Name = "Baska",
                        Surname = "Biri"
                    }
                    );

                context.Directors.AddRange(
                    new Director
                    {
                        Name = "Steven",
                        Surname = "Zailian",

                    },
                    new Director
                    {
                        Name = "Jon",
                        Surname = "Favreau",
                    }
                );

                context.Movies.AddRange(
                    new Movie
                    {
                        Name = "Schindler's List",
                        Genre = "History",
                        Year = new DateTime(1994, 3, 4),
                        Price = (float)13.14,
                        DirectorId = 1,

                    },
                    new Movie
                    {
                        Name = "Mission: Impossible",
                        Genre = "Action",
                        Year = new DateTime(1996, 5, 22),
                        Price = (float)6.86,
                        DirectorId = 1,
                    },
                    new Movie
                    {
                        Name = "Iron Man",
                        Genre = "Action",
                        Year = new DateTime(2008, 5, 2),
                        Price = (float)8.53,
                        DirectorId = 2,

                    }
                );


                context.MovieActors.AddRange(
                    new MovieActor { MovieId = 1, ActorId = 1 },
                    new MovieActor { MovieId = 1, ActorId = 2 },
                    new MovieActor { MovieId = 3, ActorId = 2 },
                    new MovieActor { MovieId = 3, ActorId = 3 },
                    new MovieActor { MovieId = 2, ActorId = 2 }
                );


                context.SaveChanges();

            }
        }
    }
}
