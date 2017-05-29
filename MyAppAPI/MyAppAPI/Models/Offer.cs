using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Offer
    {
        [Key]
        public int id { get; set; }
        [Required]
        public double discount { get; set; }

        [ForeignKey("Plate")]
        public int? PlateId { get; set; }
        public Plate Plate { get; set; }

        //Timing
        public virtual Timing timing { get; set; }
    }
}