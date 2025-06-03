using HookedUp.Models;

namespace HookedUp.Data
{
    public class ReviewRatingData
    {
        public static List<ReviewRating> ReviewRatings = new()
        {
            new ReviewRating
            {
                Id = 1,
                ProjectRequestId = 1,
                UserId = 1,
                ArtistId = 2,
                Rating = 5,
                ReviewText = "Amazing crochet work! Very satisfied.",
                ReviewImage = new[] { "https://example.com/reviewimage1.jpg" },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
