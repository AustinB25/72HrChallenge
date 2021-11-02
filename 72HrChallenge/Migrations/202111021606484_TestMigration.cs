namespace _72HrChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TestMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropColumn("dbo.Posts", "UserId");
            RenameColumn(table: "dbo.Posts", name: "User_UserId", newName: "UserId");
            AlterColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            AlterColumn("dbo.Posts", "UserId", c => c.Int(nullable: false));
            CreateIndex("dbo.Posts", "UserId");
            AddForeignKey("dbo.Posts", "UserId", "dbo.Users", "UserId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "UserId", "dbo.Users");
            DropIndex("dbo.Posts", new[] { "UserId" });
            AlterColumn("dbo.Posts", "UserId", c => c.Int());
            AlterColumn("dbo.Posts", "UserId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Posts", name: "UserId", newName: "User_UserId");
            AddColumn("dbo.Posts", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Posts", "User_UserId");
            AddForeignKey("dbo.Posts", "User_UserId", "dbo.Users", "UserId");
        }
    }
}
