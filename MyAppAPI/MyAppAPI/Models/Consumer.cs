using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class Consumer : User
    {
        public Consumer()
        {
            this.Points = new HashSet<Point>();
            this.Reservations = new HashSet<Reservation>();

        }

        //Reservation
        public virtual ICollection<Reservation> Reservations { get; set; }

        //points
        public virtual ICollection<Point> Points { get; set; }
    }
}