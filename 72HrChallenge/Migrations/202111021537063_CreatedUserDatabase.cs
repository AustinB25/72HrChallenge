namespace _72HrChallenge.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatedUserDatabase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        PostId = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        UserId = c.Guid(nullable: false),
                        User_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.PostId)
                .ForeignKey("dbo.Users", t => t.User_UserId)
                .Index(t => t.User_UserId);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        CommentId = c.Int(nullable: false, identity: true),
                        CommentText = c.String(nullable: false),
                        PostId = c.Guid(nullable: false),
                        Post_PostId = c.Int(),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("dbo.Posts", t => t.Post_PostId)
                .Index(t => t.Post_PostId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Posts", "User_UserId", "dbo.Users");
            DropForeignKey("dbo.Comments", "Post_PostId", "dbo.Posts");
            DropIndex("dbo.Comments", new[] { "Post_PostId" });
            DropIndex("dbo.Posts", new[] { "User_UserId" });
            DropTable("dbo.Comments");
            DropTable("dbo.Posts");
        }
    }
}
