using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Speciality
    {
        public Speciality()
        {
            this.Plates = new HashSet<Plate>();
        }
        [Key]
        public int id { get; set; }
        [Required]
        public string name { get; set; }

        public virtual ICollection<Plate> Plates { get; set; }
    }
}