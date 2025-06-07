namespace HookedUp.Models
{
    public class ArtistProfile
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Specialization { get; set; }
        public string ProfilePicture { get; set; }
        public string ExpertiseLevel { get; set; }
        public List<string> WorkImages { get; set; }
        public string WorkDescription { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public User User { get; set; }
    }
}
