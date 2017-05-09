using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Restaurant
    {
        public Restaurant()
        {
            this.Plates = new HashSet<Plate>();
            this.Points = new HashSet<Point>();
            this.address = new Address();

        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }
        public Double rate { get; set; }
        public string img { get; set; }
        public string cover { get; set; }
        public int WinPointMin { get; set; }

        [ForeignKey("Manager")]
        public int? ManagerId { get; set; }
        public Manager Manager { get; set; }

        //Plates
        public virtual ICollection<Plate> Plates { get; set; }

        //points
        public virtual ICollection<Point> Points { get; set; }

        //Address
        public Address address { get; set; }

        //Timing
        public virtual Timing timing { get; set; }

        

    }
}