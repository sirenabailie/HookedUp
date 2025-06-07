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
                WorkImages = new List<string>
                {
                    "https://example.com/work1.jpg",
                    "https://example.com/work2.jpg"
                },
                WorkDescription = "Experienced in creating custom crochet items.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            },
            new ArtistProfile
            {
                Id = 2,
                UserId = 4,
                Specialization = "Knit",
                ProfilePicture = "https://example.com/sophiagarcia_art.jpg",
                ExpertiseLevel = "Intermediate",
                WorkImages = new List<string>
                {
                    "https://example.com/sophia_work1.jpg",
                    "https://example.com/sophia_work2.jpg"
                },
                WorkDescription = "Experienced in creating custom knit items.",
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
