using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Entities
{
    public class Director
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Fullname
        {
            get => Name + " " + Surname;
        }

        //public ICollection<Movie> directedMovies { get; set; }


    }
}
