namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardGame",
                c => new
                    {
                        BoardGameId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.BoardGameId);
            
            CreateTable(
                "dbo.Play",
                c => new
                    {
                        PlayId = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        BoardGameId = c.Int(nullable: false),
                        TimesPlayed = c.Int(nullable: false),
                        Review = c.String(),
                        IsReviewPrivate = c.Boolean(nullable: false),
                        Rating = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.PlayId)
                .ForeignKey("dbo.BoardGame", t => t.BoardGameId, cascadeDelete: true)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BoardGameId);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        Id = c.String(),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.UserId);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        ApplicationUser_UserId = c.Int(),
                        IdentityRole_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_UserId)
                .Index(t => t.IdentityRole_Id);
            
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        UserId1 = c.Int(nullable: false),
                        UserId2 = c.Int(nullable: false),
                        ApplicationUser_UserId = c.Int(),
                        ApplicationUser_UserId1 = c.Int(),
                    })
                .PrimaryKey(t => t.FriendId)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId2)
                .ForeignKey("dbo.ApplicationUser", t => t.UserId1)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_UserId1)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.ApplicationUser_UserId)
                .Index(t => t.ApplicationUser_UserId1);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.Play", "UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "ApplicationUser_UserId1", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "UserId1", "dbo.ApplicationUser");
            DropForeignKey("dbo.Friend", "UserId2", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_UserId", "dbo.ApplicationUser");
            DropForeignKey("dbo.Play", "BoardGameId", "dbo.BoardGame");
            DropIndex("dbo.Friend", new[] { "ApplicationUser_UserId1" });
            DropIndex("dbo.Friend", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.Friend", new[] { "UserId2" });
            DropIndex("dbo.Friend", new[] { "UserId1" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_UserId" });
            DropIndex("dbo.Play", new[] { "BoardGameId" });
            DropIndex("dbo.Play", new[] { "UserId" });
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Friend");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.Play");
            DropTable("dbo.BoardGame");
        }
    }
}
