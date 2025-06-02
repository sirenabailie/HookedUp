namespace HookedUp.Models
{
    public class ProjectRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }  // Foreign key to User
        public string Title { get; set; }
        public string Description { get; set; }
        public string ProjectType { get; set; }
        public string Location { get; set; }
        public DateTime DueDate { get; set; }
        public string Status { get; set; }
        public bool Claimed { get; set; }
        public int ClaimedByUserId { get; set; }  // Foreign key to User
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
