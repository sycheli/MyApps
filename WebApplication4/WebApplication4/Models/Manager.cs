using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class Manager : User
    {
        public Manager()
        {
            this.Restaurants = new HashSet<Restaurant>();
        }
        //Liste des restau
        public virtual ICollection<Restaurant> Restaurants { get; set; }
    }
}