namespace HookedUp.DTOs
{
    public class DirectMessageDto
    {
        public int Id { get; set; }
        public int SenderId { get; set; }
        public int ReceiverId { get; set; }
        public int ProjectRequestId { get; set; }
        public string MessageText { get; set; } = null!;
        public DateTime Timestamp { get; set; }
    }
}
