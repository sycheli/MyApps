using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Plate
    {
        public Plate()
        {
            this.Reservations = new HashSet<Reservation>();
            this.Offers = new HashSet<Offer>();
        }

        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public double price { get; set; }
        public double rate { get; set; }
        public string description { get; set; }
        public string img { get; set; }
        public int pointValue { get; set; }

        
        [ForeignKey ("Speciality")]
        public int? specialityId { get; set; }
        public virtual Speciality Speciality { get; set; }

        [ForeignKey("Restaurant")]
        public int? restaurantId { get; set; }
        public virtual Restaurant Restaurant { get; set; }

        //Reservation
        public virtual ICollection<Reservation> Reservations { get; set; }

        //Offer
        public virtual ICollection<Offer> Offers { get; set; }


    }
}