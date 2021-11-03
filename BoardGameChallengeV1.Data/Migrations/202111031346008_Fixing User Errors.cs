namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixingUserErrors : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ApplicationUser", "ApplicationUserId", c => c.String());
            AddColumn("dbo.ApplicationUser", "ApplicationUsers_UserId", c => c.Int());
            CreateIndex("dbo.ApplicationUser", "ApplicationUsers_UserId");
            AddForeignKey("dbo.ApplicationUser", "ApplicationUsers_UserId", "dbo.ApplicationUser", "UserId");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUser", "ApplicationUsers_UserId", "dbo.ApplicationUser");
            DropIndex("dbo.ApplicationUser", new[] { "ApplicationUsers_UserId" });
            DropColumn("dbo.ApplicationUser", "ApplicationUsers_UserId");
            DropColumn("dbo.ApplicationUser", "ApplicationUserId");
        }
    }
}
