namespace TechnicalInterview_FeedReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStoryExternalId : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Stories", "ExternalId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Stories", "ExternalId");
        }
    }
}
