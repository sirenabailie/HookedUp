namespace HookedUp.Models
{
    public class ReviewRating
    {
        public int Id { get; set; }
        public int ProjectRequestId { get; set; }  // Foreign key to ProjectRequest
        public int UserId { get; set; }  // Foreign key to User
        public int ArtistId { get; set; }  // Foreign key to ArtistProfile
        public int Rating { get; set; }  // 1-5 star rating
        public string ReviewText { get; set; }
        public string[] ReviewImage { get; set; }  // Array of image URLs for the review
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
