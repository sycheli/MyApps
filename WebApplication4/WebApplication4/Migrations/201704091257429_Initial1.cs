namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
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
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Address_id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Addresses", t => t.Address_id)
                .Index(t => t.Address_id);
            
            AddColumn("dbo.Restaurants", "UserId", c => c.Int());
            AddColumn("dbo.Restaurants", "Manager_ID", c => c.Int());
            CreateIndex("dbo.Restaurants", "UserId");
            CreateIndex("dbo.Restaurants", "Manager_ID");
            AddForeignKey("dbo.Restaurants", "Manager_ID", "dbo.Users", "ID");
            AddForeignKey("dbo.Restaurants", "UserId", "dbo.Users", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.Users");
            DropForeignKey("dbo.Restaurants", "Manager_ID", "dbo.Users");
            DropForeignKey("dbo.Users", "Address_id", "dbo.Addresses");
            DropIndex("dbo.Users", new[] { "Address_id" });
            DropIndex("dbo.Restaurants", new[] { "Manager_ID" });
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            DropColumn("dbo.Restaurants", "Manager_ID");
            DropColumn("dbo.Restaurants", "UserId");
            DropTable("dbo.Users");
        }
    }
}
