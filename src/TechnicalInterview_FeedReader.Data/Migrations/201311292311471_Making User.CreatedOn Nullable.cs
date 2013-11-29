namespace TechnicalInterview_FeedReader.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakingUserCreatedOnNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "CreatedOn", c => c.DateTime(nullable: false));
        }
    }
}
