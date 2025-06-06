namespace HookedUp.Models
{
    public class ReviewRating
    {
        public int Id { get; set; }
        public int ProjectRequestId { get; set; }
        public int UserId { get; set; }
        public int ArtistId { get; set; }
        public int Rating { get; set; }
        public string ReviewText { get; set; }
        public string[] ReviewImage { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
