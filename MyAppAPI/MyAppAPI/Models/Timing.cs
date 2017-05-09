using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Timing
    {
        [Key, ForeignKey("Offer")]
        public int id { get; set; }

        [Required]
        public DateTime begin { get; set; }
        public DateTime end { get; set; }

        public Offer Offer { get; set; }



    }
}