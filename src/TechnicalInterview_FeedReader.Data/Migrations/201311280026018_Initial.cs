namespace TechnicalInterview_FeedReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        LastCheckedOn = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Stories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false),
                        Body = c.String(nullable: false),
                        Url = c.String(nullable: false),
                        PublishedOn = c.DateTime(nullable: false),
                        Feed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .Index(t => t.Feed_Id);
            
            CreateTable(
                "dbo.StoryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IsRead = c.Boolean(nullable: false),
                        ReadOn = c.DateTime(),
                        Story_Id = c.Int(nullable: false),
                        User_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Stories", t => t.Story_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Story_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(nullable: false),
                        EmailAddress = c.String(nullable: false),
                        CreatedOn = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserFeeds",
                c => new
                    {
                        User_Id = c.Int(nullable: false),
                        Feed_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.User_Id, t.Feed_Id })
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id, cascadeDelete: true)
                .Index(t => t.User_Id)
                .Index(t => t.Feed_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StoryStatus", "User_Id", "dbo.Users");
            DropForeignKey("dbo.UserFeeds", "Feed_Id", "dbo.Feeds");
            DropForeignKey("dbo.UserFeeds", "User_Id", "dbo.Users");
            DropForeignKey("dbo.StoryStatus", "Story_Id", "dbo.Stories");
            DropForeignKey("dbo.Stories", "Feed_Id", "dbo.Feeds");
            DropIndex("dbo.StoryStatus", new[] { "User_Id" });
            DropIndex("dbo.UserFeeds", new[] { "Feed_Id" });
            DropIndex("dbo.UserFeeds", new[] { "User_Id" });
            DropIndex("dbo.StoryStatus", new[] { "Story_Id" });
            DropIndex("dbo.Stories", new[] { "Feed_Id" });
            DropTable("dbo.UserFeeds");
            DropTable("dbo.Users");
            DropTable("dbo.StoryStatus");
            DropTable("dbo.Stories");
            DropTable("dbo.Feeds");
        }
    }
}
