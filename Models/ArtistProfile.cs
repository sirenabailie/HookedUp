namespace HookedUp.Models
{
    public class ArtistProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Foreign key to User
        public string Specialization { get; set; }
        public string ProfilePicture { get; set; }
        public string ExpertiseLevel { get; set; }
        public string[] WorkImages { get; set; }  // Store image URLs
        public string WorkDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
