namespace WebApplication4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Restaurants", "UserId", "dbo.Users");
            DropIndex("dbo.Restaurants", new[] { "UserId" });
            RenameColumn(table: "dbo.Restaurants", name: "Manager_ID", newName: "ManagerId");
            RenameIndex(table: "dbo.Restaurants", name: "IX_Manager_ID", newName: "IX_ManagerId");
            DropColumn("dbo.Restaurants", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Restaurants", "UserId", c => c.Int());
            RenameIndex(table: "dbo.Restaurants", name: "IX_ManagerId", newName: "IX_Manager_ID");
            RenameColumn(table: "dbo.Restaurants", name: "ManagerId", newName: "Manager_ID");
            CreateIndex("dbo.Restaurants", "UserId");
            AddForeignKey("dbo.Restaurants", "UserId", "dbo.Users", "ID");
        }
    }
}
