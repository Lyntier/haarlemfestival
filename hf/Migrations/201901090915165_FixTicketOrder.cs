namespace hf.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixTicketOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Tickets", "OrderId", c => c.Int(nullable: false));
            CreateIndex("dbo.Tickets", "OrderId");
            AddForeignKey("dbo.Tickets", "OrderId", "dbo.Orders", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tickets", "OrderId", "dbo.Orders");
            DropIndex("dbo.Tickets", new[] { "OrderId" });
            DropColumn("dbo.Tickets", "OrderId");
        }
    }
}
