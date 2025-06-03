namespace HookedUp.Models
{
    public class DirectMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }  // Foreign key to User
        public int ReceiverId { get; set; }  // Foreign key to User (instead of ArtistProfile)
        public int ProjectRequestId { get; set; }  // Foreign key to ProjectRequest
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties for related tables
        public User Sender { get; set; }
        public User Receiver { get; set; }  // Changed from ArtistProfile to User
        public ProjectRequest ProjectRequest { get; set; }
    }
}
