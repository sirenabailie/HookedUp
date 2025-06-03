using HookedUp.Models;

namespace HookedUp.Data
{
    public class ProjectRequestData
    {
        public static List<ProjectRequest> ProjectRequests = new()
        {
            new ProjectRequest
            {
                Id = 1,
                UserId = 1,
                Title = "Create a Baby Blanket",
                Description = "Need a crocheted baby blanket.",
                ProjectType = "Crochet",
                Location = "New York",
                DueDate = DateTime.Now.AddDays(5),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
