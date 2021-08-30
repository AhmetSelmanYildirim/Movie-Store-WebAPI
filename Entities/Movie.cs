using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Entities
{
    public class Movie
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public string Name { get; set; }
        public DateTime Year { get; set; }
        public float Price { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public int DirectorId { get; set; }
        public string Actors { get; set; }
        public int ActorIds { get; set; }
    }
}
