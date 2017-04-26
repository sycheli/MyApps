namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
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
                        SpecialityId = c.Int(),
                        RestaurantId = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Restaurants", t => t.RestaurantId)
                .ForeignKey("dbo.Specialities", t => t.SpecialityId)
                .Index(t => t.SpecialityId)
                .Index(t => t.RestaurantId);
            
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
            
            AddColumn("dbo.Restaurants", "timing_id", c => c.Int());
            CreateIndex("dbo.Restaurants", "timing_id");
            AddForeignKey("dbo.Restaurants", "timing_id", "dbo.Timings", "id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "timing_id", "dbo.Timings");
            DropForeignKey("dbo.Plates", "SpecialityId", "dbo.Specialities");
            DropForeignKey("dbo.Plates", "RestaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.ReservationPlates", "Plate_id", "dbo.Plates");
            DropForeignKey("dbo.ReservationPlates", "Reservation_id", "dbo.Reservations");
            DropForeignKey("dbo.Reservations", "ConsumerId", "dbo.Users");
            DropForeignKey("dbo.Timings", "id", "dbo.Offers");
            DropForeignKey("dbo.Offers", "PlateId", "dbo.Plates");
            DropIndex("dbo.ReservationPlates", new[] { "Plate_id" });
            DropIndex("dbo.ReservationPlates", new[] { "Reservation_id" });
            DropIndex("dbo.Reservations", new[] { "ConsumerId" });
            DropIndex("dbo.Timings", new[] { "id" });
            DropIndex("dbo.Offers", new[] { "PlateId" });
            DropIndex("dbo.Plates", new[] { "RestaurantId" });
            DropIndex("dbo.Plates", new[] { "SpecialityId" });
            DropIndex("dbo.Restaurants", new[] { "timing_id" });
            DropColumn("dbo.Restaurants", "timing_id");
            DropTable("dbo.ReservationPlates");
            DropTable("dbo.Specialities");
            DropTable("dbo.Reservations");
            DropTable("dbo.Timings");
            DropTable("dbo.Offers");
            DropTable("dbo.Plates");
        }
    }
}
