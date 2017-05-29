using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models

{
    public class Reservation
    {

        public Reservation()
        {
            this.Plates = new HashSet<Plate>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        public double reservationPrice { get; set; }
        public DateTime reservationDate { get; set; }
        public DateTime deliveryDate { get; set; }
        public string state { get; set; }

        [ForeignKey("Consumer")]
        public int? ConsumerId { get; set; }
        public Consumer Consumer { get; set; }


        //plate
        public virtual ICollection<Plate> Plates { get; set; }

       

    }
}