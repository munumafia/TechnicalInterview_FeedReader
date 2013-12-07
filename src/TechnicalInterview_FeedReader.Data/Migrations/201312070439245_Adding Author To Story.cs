namespace TechnicalInterview_FeedReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddingAuthorToStory : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "Author", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "Author");
        }
    }
}
