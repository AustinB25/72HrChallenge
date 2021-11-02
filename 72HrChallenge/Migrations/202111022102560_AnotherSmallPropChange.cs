namespace _72HrChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AnotherSmallPropChange : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Likes", "PostId", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "PostId" });
            RenameColumn(table: "dbo.Likes", name: "PostId", newName: "Post_PostId");
            AlterColumn("dbo.Likes", "Post_PostId", c => c.Int());
            CreateIndex("dbo.Likes", "Post_PostId");
            AddForeignKey("dbo.Likes", "Post_PostId", "dbo.Posts", "PostId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Likes", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Likes", new[] { "Post_PostId" });
            AlterColumn("dbo.Likes", "Post_PostId", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Likes", name: "Post_PostId", newName: "PostId");
            CreateIndex("dbo.Likes", "PostId");
            AddForeignKey("dbo.Likes", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
    }
}
