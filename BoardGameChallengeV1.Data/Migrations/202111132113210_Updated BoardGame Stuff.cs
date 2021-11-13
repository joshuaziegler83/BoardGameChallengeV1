namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedBoardGameStuff : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardGame", "UserId", c => c.Guid(nullable: false));
            CreateIndex("dbo.BoardGame", "UserId");
            AddForeignKey("dbo.BoardGame", "UserId", "dbo.User", "UserId", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BoardGame", "UserId", "dbo.User");
            DropIndex("dbo.BoardGame", new[] { "UserId" });
            DropColumn("dbo.BoardGame", "UserId");
        }
    }
}
