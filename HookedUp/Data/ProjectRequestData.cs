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
            },
            new ProjectRequest
            {
                Id = 2,
                UserId = 3,
                Title = "Finish a Knit Scarf",
                Description = "Looking for someone to finish my grandmother's knit scarf project.",
                ProjectType = "Knit",
                Location = "Chicago",
                DueDate = DateTime.Now.AddDays(7),
                Status = "Open",
                Claimed = false,
                ClaimedByUserId = null,
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            }
        };
    }
}
