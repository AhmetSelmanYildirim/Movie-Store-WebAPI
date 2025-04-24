using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Entities
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        //public Array PurchasedMovies { get; set; }
        //public Array FavoriteGenres { get; set; }
    }
}
