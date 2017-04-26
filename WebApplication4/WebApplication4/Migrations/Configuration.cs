namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using WebApplication4.Models;
    internal sealed class Configuration : DbMigrationsConfiguration<WebApplication4.Models.WebApplication4Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(WebApplication4.Models.WebApplication4Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            

          /*  context.Users.AddOrUpdate(x => x.ID,
                new User()
                {
                    ID = 6,
                    firstName = "Adil",
                    lastName = "chekati",
                    userName = "sp17",
                    password = "0000",
                    email = "Comedy of manners",
                    img ="alg",
                    
                }
                );
         context.Restaurants.AddOrUpdate(x => x.id,
       new Restaurant()
       {
           id = 12,
           name = "MegaPizza",
           rate = 9,
           img = "url image",
           WinPointMin = 100,
           UserId = 1,

       }
       );
            context.Plates.AddOrUpdate(x => x.id,
                new Plate()
                {
                    id = 2,
                    name = "Kouskous",
                    price = 200,
                    rate = 7,
                    restaurantId = 1,
                    pointValue =10,
                    img = "alg",
                    description ="miaaam",
                    

                }
                ); **/
        }
    }
}
