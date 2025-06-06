namespace HookedUp.Models
{
    public class DirectMessage
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ProjectRequestId { get; set; } 
        public required string MessageText { get; set; }
        public DateTime Timestamp { get; set; }

        public User Sender { get; set; }
        public User Receiver { get; set; } 
        public ProjectRequest ProjectRequest { get; set; }
    }
}
