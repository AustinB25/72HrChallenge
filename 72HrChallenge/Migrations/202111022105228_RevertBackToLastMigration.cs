namespace _72HrChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RevertBackToLastMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "Post_PostId" });
            RenameColumn(table: "dbo.Likes", name: "Post_PostId", newName: "PostId");
            AlterColumn("dbo.Likes", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Likes", "PostId");
            AddForeignKey("dbo.Likes", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "PostId", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "PostId" });
            AlterColumn("dbo.Likes", "PostId", c => c.Int());
            RenameColumn(table: "dbo.Likes", name: "PostId", newName: "Post_PostId");
            CreateIndex("dbo.Likes", "Post_PostId");
            AddForeignKey("dbo.Likes", "Post_PostId", "dbo.Posts", "PostId");
        }
    }
}
