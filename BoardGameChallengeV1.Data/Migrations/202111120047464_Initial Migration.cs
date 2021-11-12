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
                        TimesPlayed = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.BoardGameId);
            
            CreateTable(
                "dbo.Play",
                c => new
                    {
                        PlayId = c.Int(nullable: false, identity: true),
                        UserId = c.Guid(nullable: false),
                        BoardGameId = c.Int(nullable: false),
                        Review = c.String(),
                        IsReviewPrivate = c.Boolean(nullable: false),
                        Rating = c.Double(nullable: false),
                        User_userId = c.Guid(),
                        User_userId1 = c.Guid(),
                        User_userId2 = c.Guid(),
                    })
                .PrimaryKey(t => t.PlayId)
                .ForeignKey("dbo.BoardGame", t => t.BoardGameId, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.User_userId)
                .ForeignKey("dbo.User", t => t.User_userId1)
                .ForeignKey("dbo.User", t => t.User_userId2)
                .ForeignKey("dbo.User", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.BoardGameId)
                .Index(t => t.User_userId)
                .Index(t => t.User_userId1)
                .Index(t => t.User_userId2);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        userId = c.Guid(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.FriendRequest",
                c => new
                    {
                        FriendRequestId = c.Int(nullable: false, identity: true),
                        UserId1 = c.Guid(nullable: false),
                        UserId2 = c.Guid(nullable: false),
                        IsAccepted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.FriendRequestId)
                .ForeignKey("dbo.User", t => t.UserId2)
                .ForeignKey("dbo.User", t => t.UserId1)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2);
            
            CreateTable(
                "dbo.Message",
                c => new
                    {
                        MessageId = c.Int(nullable: false, identity: true),
                        UserId1 = c.Guid(nullable: false),
                        UserId2 = c.Guid(nullable: false),
                        Content = c.String(),
                        FriendRequest_FriendRequestId = c.Int(),
                    })
                .PrimaryKey(t => t.MessageId)
                .ForeignKey("dbo.User", t => t.UserId1, cascadeDelete: true)
                .ForeignKey("dbo.User", t => t.UserId2, cascadeDelete: true)
                .ForeignKey("dbo.FriendRequest", t => t.FriendRequest_FriendRequestId)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.FriendRequest_FriendRequestId);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
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
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.FriendRequest", "UserId1", "dbo.User");
            DropForeignKey("dbo.FriendRequest", "UserId2", "dbo.User");
            DropForeignKey("dbo.Message", "FriendRequest_FriendRequestId", "dbo.FriendRequest");
            DropForeignKey("dbo.Message", "UserId2", "dbo.User");
            DropForeignKey("dbo.Message", "UserId1", "dbo.User");
            DropForeignKey("dbo.Play", "UserId", "dbo.User");
            DropForeignKey("dbo.Play", "User_userId2", "dbo.User");
            DropForeignKey("dbo.Play", "User_userId1", "dbo.User");
            DropForeignKey("dbo.Play", "User_userId", "dbo.User");
            DropForeignKey("dbo.Play", "BoardGameId", "dbo.BoardGame");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Message", new[] { "FriendRequest_FriendRequestId" });
            DropIndex("dbo.Message", new[] { "UserId2" });
            DropIndex("dbo.Message", new[] { "UserId1" });
            DropIndex("dbo.FriendRequest", new[] { "UserId2" });
            DropIndex("dbo.FriendRequest", new[] { "UserId1" });
            DropIndex("dbo.Play", new[] { "User_userId2" });
            DropIndex("dbo.Play", new[] { "User_userId1" });
            DropIndex("dbo.Play", new[] { "User_userId" });
            DropIndex("dbo.Play", new[] { "BoardGameId" });
            DropIndex("dbo.Play", new[] { "UserId" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Message");
            DropTable("dbo.FriendRequest");
            DropTable("dbo.User");
            DropTable("dbo.Play");
            DropTable("dbo.BoardGame");
        }
    }
}
