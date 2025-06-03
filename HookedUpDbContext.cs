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
            modelBuilder.Entity<User>().HasData(UserData.Users);
            modelBuilder.Entity<ArtistProfile>().HasData(ArtistProfileData.ArtistProfiles);
            modelBuilder.Entity<ProjectRequest>().HasData(ProjectRequestData.ProjectRequests);
            modelBuilder.Entity<ReviewRating>().HasData(ReviewRatingData.ReviewRatings);
            modelBuilder.Entity<DirectMessage>().HasData(DirectMessageData.DirectMessages);
        }
    }
}
