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
            },
            new ReviewRating
            {
                Id = 2,
                ProjectRequestId = 2,
                UserId = 3,
                ArtistId = 4,
                Rating = 4,
                ReviewText = "Sophia did a great job finishing my scarf—very happy with the result!",
                ReviewImage = new[] { "https://example.com/reviewimage2.jpg" },
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
