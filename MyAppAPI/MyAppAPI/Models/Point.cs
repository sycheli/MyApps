using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    
    public class Point
    {
       [Key]
        public int id { get; set; }
        public Double value { get; set; }
        public DateTime lastUpdate { get; set; }

       [ForeignKey("Restaurant")]
        public int restaurantId { get; set; }
        public Restaurant Restaurant { get; set; }

       [ForeignKey("Consumer")]
        public int ConsumerId { get; set; }
        public Consumer Consumer { get; set; }

    }
}