namespace HookedUp.Models
{
    public class DirectMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }  // Foreign key to User
        public int ReceiverId { get; set; }  // Foreign key to ArtistProfile
        public int ProjectRequestId { get; set; }  // Foreign key to ProjectRequest
        public string MessageText { get; set; }
        public DateTime Timestamp { get; set; }

        // Navigation properties for related tables
        public User Sender { get; set; }
        public ArtistProfile Receiver { get; set; }
        public ProjectRequest ProjectRequest { get; set; }
    }
}
