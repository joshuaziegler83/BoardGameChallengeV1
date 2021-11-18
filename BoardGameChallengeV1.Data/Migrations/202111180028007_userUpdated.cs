namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class userUpdated : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "UserId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ApplicationUser", "UserId");
        }
    }
}
