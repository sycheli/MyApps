namespace MyAppAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Offers",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        discount = c.Double(nullable: false),
                        PlateId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Plates", t => t.PlateId)
                .Index(t => t.PlateId);
            
            CreateTable(
                "dbo.Plates",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        price = c.Double(nullable: false),
                        rate = c.Double(nullable: false),
                        description = c.String(),
                        img = c.String(),
                        pointValue = c.Int(nullable: false),
                        specialityId = c.Int(),
                        restaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Restaurants", t => t.restaurantId)
                .ForeignKey("dbo.Specialities", t => t.specialityId)
                .Index(t => t.specialityId)
                .Index(t => t.restaurantId);
            
            CreateTable(
                "dbo.Reservations",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        reservationPrice = c.Double(nullable: false),
                        reservationDate = c.DateTime(nullable: false),
                        deliveryDate = c.DateTime(nullable: false),
                        state = c.String(),
                        ConsumerId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.ConsumerId)
                .Index(t => t.ConsumerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        userName = c.String(nullable: false),
                        password = c.String(nullable: false),
                        firstName = c.String(nullable: false),
                        lastName = c.String(nullable: false),
                        email = c.String(nullable: false),
                        img = c.String(),
                        cover = c.String(),
                        address_street = c.String(),
                        address_zipCode = c.Double(nullable: false),
                        address_city = c.String(),
                        address_country = c.String(),
                        address_latitude = c.Double(nullable: false),
                        address_longitude = c.Double(nullable: false),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Points",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        value = c.Double(nullable: false),
                        lastUpdate = c.DateTime(nullable: false),
                        restaurantId = c.Int(nullable: false),
                        ConsumerId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.ConsumerId, cascadeDelete: true)
                .ForeignKey("dbo.Restaurants", t => t.restaurantId, cascadeDelete: true)
                .Index(t => t.restaurantId)
                .Index(t => t.ConsumerId);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        rate = c.Double(nullable: false),
                        img = c.String(),
                        cover = c.String(),
                        WinPointMin = c.Int(nullable: false),
                        ManagerId = c.Int(),
                        address_street = c.String(),
                        address_zipCode = c.Double(nullable: false),
                        address_city = c.String(),
                        address_country = c.String(),
                        address_latitude = c.Double(nullable: false),
                        address_longitude = c.Double(nullable: false),
                        timing_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.ManagerId)
                .ForeignKey("dbo.Timings", t => t.timing_id)
                .Index(t => t.ManagerId)
                .Index(t => t.timing_id);
            
            CreateTable(
                "dbo.Timings",
                c => new
                    {
                        id = c.Int(nullable: false),
                        begin = c.DateTime(nullable: false),
                        end = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Offers", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Specialities",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.ReservationPlates",
                c => new
                    {
                        Reservation_id = c.Int(nullable: false),
                        Plate_id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Reservation_id, t.Plate_id })
                .ForeignKey("dbo.Reservations", t => t.Reservation_id, cascadeDelete: true)
                .ForeignKey("dbo.Plates", t => t.Plate_id, cascadeDelete: true)
                .Index(t => t.Reservation_id)
                .Index(t => t.Plate_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Offers", "PlateId", "dbo.Plates");
            DropForeignKey("dbo.Plates", "specialityId", "dbo.Specialities");
            DropForeignKey("dbo.Plates", "restaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.ReservationPlates", "Plate_id", "dbo.Plates");
            DropForeignKey("dbo.ReservationPlates", "Reservation_id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "ConsumerId", "dbo.Users");
            DropForeignKey("dbo.Points", "restaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Restaurants", "timing_id", "dbo.Timings");
            DropForeignKey("dbo.Timings", "id", "dbo.Offers");
            DropForeignKey("dbo.Restaurants", "ManagerId", "dbo.Users");
            DropForeignKey("dbo.Points", "ConsumerId", "dbo.Users");
            DropIndex("dbo.ReservationPlates", new[] { "Plate_id" });
            DropIndex("dbo.ReservationPlates", new[] { "Reservation_id" });
            DropIndex("dbo.Timings", new[] { "id" });
            DropIndex("dbo.Restaurants", new[] { "timing_id" });
            DropIndex("dbo.Restaurants", new[] { "ManagerId" });
            DropIndex("dbo.Points", new[] { "ConsumerId" });
            DropIndex("dbo.Points", new[] { "restaurantId" });
            DropIndex("dbo.Reservations", new[] { "ConsumerId" });
            DropIndex("dbo.Plates", new[] { "restaurantId" });
            DropIndex("dbo.Plates", new[] { "specialityId" });
            DropIndex("dbo.Offers", new[] { "PlateId" });
            DropTable("dbo.ReservationPlates");
            DropTable("dbo.Specialities");
            DropTable("dbo.Timings");
            DropTable("dbo.Restaurants");
            DropTable("dbo.Points");
            DropTable("dbo.Users");
            DropTable("dbo.Reservations");
            DropTable("dbo.Plates");
            DropTable("dbo.Offers");
        }
    }
}
