using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MyAppAPI.Models
{
    public class MyAppAPIContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public MyAppAPIContext() : base("name=MyAppAPIContext")
        {
            //this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
           // this.Configuration.LazyLoadingEnabled = false;
            //this.Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Speciality> Specialities { get; set; }

        public DbSet<Timing> Timings { get; set; }

        public System.Data.Entity.DbSet<MyAppAPI.Models.Offer> Offers { get; set; }

        public System.Data.Entity.DbSet<MyAppAPI.Models.Reservation> Reservations { get; set; }

        public System.Data.Entity.DbSet<MyAppAPI.Models.Restaurant> Restaurants { get; set; }

        public System.Data.Entity.DbSet<MyAppAPI.Models.Point> Points { get; set; }

        public System.Data.Entity.DbSet<MyAppAPI.Models.Plate> Plates { get; set; }
    }
}
