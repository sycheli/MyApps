using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    //[ComplexType]
    public class Address
    {
     
        //public int id { get; set; }

        public string street { get; set; }
        public Double zipCode { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public Double latitude { get; set; }
        public Double longitude { get; set; }

        /* [ForeignKey("User")]
        public int? userId { get; set; }
        public virtual User User { get; set; } **/


       /* [ForeignKey("Restaurant")]
        public int? RestaurantId { get; set; }*/
       // public Restaurant Restaurant { get; set; }
    }
}