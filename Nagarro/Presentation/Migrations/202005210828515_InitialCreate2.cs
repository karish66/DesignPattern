namespace Presentation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Notification", "UserId", "dbo.User");
            DropIndex("dbo.Notification", new[] { "UserId" });
            CreateTable(
                "dbo.MapRelation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        NotificationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Notification", t => t.NotificationId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.NotificationId);
            
            DropColumn("dbo.Notification", "UserId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Notification", "UserId", c => c.Int(nullable: false));
            DropForeignKey("dbo.MapRelation", "UserId", "dbo.User");
            DropForeignKey("dbo.MapRelation", "NotificationId", "dbo.Notification");
            DropIndex("dbo.MapRelation", new[] { "NotificationId" });
            DropIndex("dbo.MapRelation", new[] { "UserId" });
            DropTable("dbo.MapRelation");
            CreateIndex("dbo.Notification", "UserId");
            AddForeignKey("dbo.Notification", "UserId", "dbo.User", "Id", cascadeDelete: true);
        }
    }
}
