using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    public class WebApplication4Context : DbContext
    {

        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public WebApplication4Context() : base("name=WebApplication4Context")
        {
          this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
          //  this.Configuration.LazyLoadingEnabled = false;
         //   this.Configuration.ProxyCreationEnabled = false;
        }

    

        public DbSet<Restaurant> Restaurants { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Plate> Plates { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Speciality> Specialities { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Reservation> Reservations { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Offer> Offers { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Timing> Timings { get; set; }

        public System.Data.Entity.DbSet<WebApplication4.Models.Point> Points { get; set; }
    }
}
