using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Movie_Store_WebAPI.Entities
{
    public class Order
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ID { get; set; }
        //public Customer Customer { get; set; }
        //public Movie PurchasedMovies { get; set; }
        public float Price { get; set; }
        public DateTime DateOfPurchase { get; set; }
    }
}
