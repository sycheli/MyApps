namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial6 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Addresses", "id", "dbo.Restaurants");
            DropForeignKey("dbo.Users", "address_id", "dbo.Addresses");
            DropIndex("dbo.Addresses", new[] { "id" });
            DropIndex("dbo.Users", new[] { "address_id" });
            AddColumn("dbo.Restaurants", "cover", c => c.String());
            AddColumn("dbo.Restaurants", "address_street", c => c.String());
            AddColumn("dbo.Restaurants", "address_zipCode", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "address_city", c => c.String());
            AddColumn("dbo.Restaurants", "address_country", c => c.String());
            AddColumn("dbo.Restaurants", "address_latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Restaurants", "address_longitude", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "cover", c => c.String());
            AddColumn("dbo.Users", "address_street", c => c.String());
            AddColumn("dbo.Users", "address_zipCode", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "address_city", c => c.String());
            AddColumn("dbo.Users", "address_country", c => c.String());
            AddColumn("dbo.Users", "address_latitude", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "address_longitude", c => c.Double(nullable: false));
            DropColumn("dbo.Users", "address_id");
            DropTable("dbo.Addresses");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Addresses",
                c => new
                    {
                        id = c.Int(nullable: false),
                        street = c.String(),
                        zipCode = c.Double(nullable: false),
                        city = c.String(),
                        country = c.String(),
                        latitude = c.Double(nullable: false),
                        longitude = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
            AddColumn("dbo.Users", "address_id", c => c.Int());
            DropColumn("dbo.Users", "address_longitude");
            DropColumn("dbo.Users", "address_latitude");
            DropColumn("dbo.Users", "address_country");
            DropColumn("dbo.Users", "address_city");
            DropColumn("dbo.Users", "address_zipCode");
            DropColumn("dbo.Users", "address_street");
            DropColumn("dbo.Users", "cover");
            DropColumn("dbo.Restaurants", "address_longitude");
            DropColumn("dbo.Restaurants", "address_latitude");
            DropColumn("dbo.Restaurants", "address_country");
            DropColumn("dbo.Restaurants", "address_city");
            DropColumn("dbo.Restaurants", "address_zipCode");
            DropColumn("dbo.Restaurants", "address_street");
            DropColumn("dbo.Restaurants", "cover");
            CreateIndex("dbo.Users", "address_id");
            CreateIndex("dbo.Addresses", "id");
            AddForeignKey("dbo.Users", "address_id", "dbo.Addresses", "id");
            AddForeignKey("dbo.Addresses", "id", "dbo.Restaurants", "id");
        }
    }
}
