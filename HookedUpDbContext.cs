using Microsoft.EntityFrameworkCore;
using HookedUp.Models;
using HookedUp.Data;

namespace HookedUp
{
    public class HookedUpDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ArtistProfile> ArtistProfiles { get; set; }
        public DbSet<ProjectRequest> ProjectRequests { get; set; }
        public DbSet<ReviewRating> ReviewRatings { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }

        public HookedUpDbContext(DbContextOptions<HookedUpDbContext> context) : base(context)
        {
        }

protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    modelBuilder.Entity<DirectMessage>()
        .HasOne(dm => dm.Receiver)
        .WithMany()
        .HasForeignKey(dm => dm.ReceiverId)  // ReceiverId should point to UserId, not ArtistProfile
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<DirectMessage>()
        .HasOne(dm => dm.Sender)
        .WithMany()
        .HasForeignKey(dm => dm.SenderId)
        .OnDelete(DeleteBehavior.Cascade);

    modelBuilder.Entity<ArtistProfile>()
        .HasOne(ap => ap.User)
        .WithMany()
        .HasForeignKey(ap => ap.UserId)
        .OnDelete(DeleteBehavior.Cascade);
}


    }
}
