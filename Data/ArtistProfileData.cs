using HookedUp.Models;

namespace HookedUp.Data
{
    public class ArtistProfileData
    {
        public static List<ArtistProfile> ArtistProfiles = new()
        {
            new ArtistProfile
            {
                Id = 1,
                UserId = 2,
                Specialization = "Crochet",
                ProfilePicture = "https://example.com/artist1.jpg",
                ExpertiseLevel = "Advanced",
                // Use List<string> for WorkImages instead of an array
                WorkImages = new List<string> { "https://example.com/work1.jpg", "https://example.com/work2.jpg" },
                WorkDescription = "Experienced in creating custom crochet items.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
