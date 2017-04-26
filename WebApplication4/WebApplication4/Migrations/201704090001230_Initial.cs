namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
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
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Restaurants", t => t.id)
                .Index(t => t.id);
            
            CreateTable(
                "dbo.Restaurants",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        rate = c.Double(nullable: false),
                        img = c.String(),
                        WinPointMin = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Addresses", "id", "dbo.Restaurants");
            DropIndex("dbo.Addresses", new[] { "id" });
            DropTable("dbo.Restaurants");
            DropTable("dbo.Addresses");
        }
    }
}
