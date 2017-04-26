namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Plates", new[] { "SpecialityId" });
            DropIndex("dbo.Plates", new[] { "RestaurantId" });
            DropIndex("dbo.Users", new[] { "Address_id" });
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
            
            CreateIndex("dbo.Plates", "specialityId");
            CreateIndex("dbo.Plates", "restaurantId");
            CreateIndex("dbo.Users", "address_id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Points", "restaurantId", "dbo.Restaurants");
            DropForeignKey("dbo.Points", "ConsumerId", "dbo.Users");
            DropIndex("dbo.Points", new[] { "ConsumerId" });
            DropIndex("dbo.Points", new[] { "restaurantId" });
            DropIndex("dbo.Users", new[] { "address_id" });
            DropIndex("dbo.Plates", new[] { "restaurantId" });
            DropIndex("dbo.Plates", new[] { "specialityId" });
            DropTable("dbo.Points");
            CreateIndex("dbo.Users", "Address_id");
            CreateIndex("dbo.Plates", "RestaurantId");
            CreateIndex("dbo.Plates", "SpecialityId");
        }
    }
}
