namespace BoardGameChallengeV1.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedFriendsToFriendRequests : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Friend", "UserId2", "dbo.User");
            DropForeignKey("dbo.Friend", "UserId1", "dbo.User");
            DropForeignKey("dbo.Friend", "User_userId", "dbo.User");
            DropForeignKey("dbo.Friend", "User_userId1", "dbo.User");
            DropIndex("dbo.Friend", new[] { "UserId1" });
            DropIndex("dbo.Friend", new[] { "UserId2" });
            DropIndex("dbo.Friend", new[] { "User_userId" });
            DropIndex("dbo.Friend", new[] { "User_userId1" });
            CreateTable(
                "dbo.FriendRequest",
                c => new
                    {
                        FriendRequestId = c.Int(nullable: false, identity: true),
                        UserId1 = c.Guid(nullable: false),
                        UserId2 = c.Guid(nullable: false),
                        User_userId = c.Guid(),
                        User_userId1 = c.Guid(),
                    })
                .PrimaryKey(t => t.FriendRequestId)
                .ForeignKey("dbo.User", t => t.UserId2)
                .ForeignKey("dbo.User", t => t.UserId1)
                .ForeignKey("dbo.User", t => t.User_userId)
                .ForeignKey("dbo.User", t => t.User_userId1)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.User_userId)
                .Index(t => t.User_userId1);

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
                .ForeignKey("dbo.User", t => t.UserId1, cascadeDelete: false)
                .ForeignKey("dbo.User", t => t.UserId2, cascadeDelete: false)

                .ForeignKey("dbo.FriendRequest", t => t.FriendRequest_FriendRequestId)
                .Index(t => t.UserId1)
                .Index(t => t.UserId2)
                .Index(t => t.FriendRequest_FriendRequestId);
            
            DropTable("dbo.Friend");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Friend",
                c => new
                    {
                        FriendId = c.Int(nullable: false, identity: true),
                        UserId1 = c.Guid(nullable: false),
                        UserId2 = c.Guid(nullable: false),
                        User_userId = c.Guid(),
                        User_userId1 = c.Guid(),
                    })
                .PrimaryKey(t => t.FriendId);
            
            DropForeignKey("dbo.FriendRequest", "User_userId1", "dbo.User");
            DropForeignKey("dbo.FriendRequest", "User_userId", "dbo.User");
            DropForeignKey("dbo.FriendRequest", "UserId1", "dbo.User");
            DropForeignKey("dbo.FriendRequest", "UserId2", "dbo.User");
            DropForeignKey("dbo.Message", "FriendRequest_FriendRequestId", "dbo.FriendRequest");
            DropForeignKey("dbo.Message", "UserId2", "dbo.User");
            DropForeignKey("dbo.Message", "UserId1", "dbo.User");
            DropIndex("dbo.Message", new[] { "FriendRequest_FriendRequestId" });
            DropIndex("dbo.Message", new[] { "UserId2" });
            DropIndex("dbo.Message", new[] { "UserId1" });
            DropIndex("dbo.FriendRequest", new[] { "User_userId1" });
            DropIndex("dbo.FriendRequest", new[] { "User_userId" });
            DropIndex("dbo.FriendRequest", new[] { "UserId2" });
            DropIndex("dbo.FriendRequest", new[] { "UserId1" });
            DropTable("dbo.Message");
            DropTable("dbo.FriendRequest");
            CreateIndex("dbo.Friend", "User_userId1");
            CreateIndex("dbo.Friend", "User_userId");
            CreateIndex("dbo.Friend", "UserId2");
            CreateIndex("dbo.Friend", "UserId1");
            AddForeignKey("dbo.Friend", "User_userId1", "dbo.User", "userId");
            AddForeignKey("dbo.Friend", "User_userId", "dbo.User", "userId");
            AddForeignKey("dbo.Friend", "UserId1", "dbo.User", "userId");
            AddForeignKey("dbo.Friend", "UserId2", "dbo.User", "userId");
        }
    }
}
