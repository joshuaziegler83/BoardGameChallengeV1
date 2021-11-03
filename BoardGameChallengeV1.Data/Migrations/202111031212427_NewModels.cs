namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewModels : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BoardGame", "TimesPlayed", c => c.Int(nullable: false));
            DropColumn("dbo.Play", "TimesPlayed");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Play", "TimesPlayed", c => c.Int(nullable: false));
            DropColumn("dbo.BoardGame", "TimesPlayed");
        }
    }
}
