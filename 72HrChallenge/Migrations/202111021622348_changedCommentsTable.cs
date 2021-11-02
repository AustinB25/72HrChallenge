namespace _72HrChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changedCommentsTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropColumn("dbo.Comments", "PostId");
            RenameColumn(table: "dbo.Comments", name: "Post_PostId", newName: "PostId");
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            AlterColumn("dbo.Comments", "PostId", c => c.Int(nullable: false));
            CreateIndex("dbo.Comments", "PostId");
            AddForeignKey("dbo.Comments", "PostId", "dbo.Posts", "PostId", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Comments", "PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "PostId" });
            AlterColumn("dbo.Comments", "PostId", c => c.Int());
            AlterColumn("dbo.Comments", "PostId", c => c.Guid(nullable: false));
            RenameColumn(table: "dbo.Comments", name: "PostId", newName: "Post_PostId");
            AddColumn("dbo.Comments", "PostId", c => c.Guid(nullable: false));
            CreateIndex("dbo.Comments", "Post_PostId");
            AddForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts", "PostId");
        }
    }
}
