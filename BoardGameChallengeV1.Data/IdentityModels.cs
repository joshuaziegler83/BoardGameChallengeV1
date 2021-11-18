using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace BoardGameChallengeV1.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get
            {
                return FirstName + " " + LastName;
            }
        }

        public virtual ICollection<FriendRequest> IncomingFriendRequests { get; set; }
        public virtual ICollection<FriendRequest> OutgoingFriendRequests { get; set; }

        public virtual ICollection<Message> OutgoingMessages { get; set; }
        public virtual ICollection<Message> IncomingMessages { get; set; }

        public virtual ICollection<BoardGame> BoardGames { get; set; }

        //public virtual ICollection<Play> User1Plays { get; set; }
        //public virtual ICollection<Play> User2Plays { get; set; }
        //public virtual ICollection<Play> Plays { get; set; }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Play> Plays { get; set; }
        public DbSet<BoardGame> BoardGames { get; set; }
        public DbSet<FriendRequest> FriendRequests { get; set; }
        public DbSet<Message> Messages { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserLoginConfiguration())
                .Add(new IdentityUserRoleConfiguration());


            modelBuilder.Entity<FriendRequest>()
                        .HasRequired(p => p.ApplicationUser1)
                        .WithMany(u => u.OutgoingFriendRequests)
                        .HasForeignKey(p => p.UserId1)
                        .WillCascadeOnDelete(false);
            modelBuilder.Entity<FriendRequest>()
                        .HasRequired(p => p.ApplicationUser2)
                        .WithMany(u => u.IncomingFriendRequests)
                        .HasForeignKey(p => p.UserId2)
                        .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.User1)
                .WithMany(u => u.OutgoingMessages)
                .HasForeignKey(p => p.UserId1)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Message>()
                .HasRequired(m => m.User2)
                .WithMany(u => u.IncomingMessages)
                .HasForeignKey(p => p.UserId2)
                .WillCascadeOnDelete(false);
        }
    }
    public class IdentityUserLoginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserLoginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}
