using Microsoft.EntityFrameworkCore;
using HookedUp.Models;

namespace YourProjectName.APIs
{
    public class ProjectRequestAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL ProjectRequests
            app.MapGet("/projectrequests", (AppDbContext db) =>
            {
                var allProjectRequests = db.ProjectRequests
                    .Include(pr => pr.User) // Eager load the user related to the project request
                    .ToList();

                var projectRequestDtos = allProjectRequests.Select(pr => new ProjectRequestDto(pr)).ToList();

                if (!projectRequestDtos.Any())
                {
                    return Results.Ok("No project requests found");
                }
                return Results.Ok(projectRequestDtos);
            });

            // GET SINGLE ProjectRequest
            app.MapGet("/projectrequests/{id}", (AppDbContext db, int id) =>
            {
                var projectRequest = db.ProjectRequests
                    .Include(pr => pr.User)
                    .SingleOrDefault(pr => pr.Id == id);

                if (projectRequest == null)
                {
                    return Results.NotFound($"No project request found with the id: {id}");
                }

                return Results.Ok(new ProjectRequestDto(projectRequest));
            });

            // CREATE ProjectRequest
            app.MapPost("/projectrequests", (AppDbContext db, ProjectRequest newRequest) =>
            {
                var projectRequest = new ProjectRequest
                {
                    UserId = newRequest.UserId,
                    Title = newRequest.Title,
                    Description = newRequest.Description,
                    ProjectType = newRequest.ProjectType,
                    Location = newRequest.Location,
                    DueDate = newRequest.DueDate,
                    Status = newRequest.Status,
                    Claimed = newRequest.Claimed,
                    ClaimedByUserId = newRequest.ClaimedByUserId
                };

                db.ProjectRequests.Add(projectRequest);
                db.SaveChanges();

                return Results.Created($"/projectrequests/{projectRequest.Id}", new ProjectRequestDto(projectRequest));
            });

            // UPDATE ProjectRequest
            app.MapPut("/projectrequests/{id}", (AppDbContext db, ProjectRequest updatedRequest, int id) =>
            {
                var projectRequest = db.ProjectRequests
                    .SingleOrDefault(pr => pr.Id == id);

                if (projectRequest == null)
                {
                    return Results.NotFound($"No project request found with the id: {id}");
                }

                projectRequest.Title = updatedRequest.Title;
                projectRequest.Description = updatedRequest.Description;
                projectRequest.ProjectType = updatedRequest.ProjectType;
                projectRequest.Location = updatedRequest.Location;
                projectRequest.DueDate = updatedRequest.DueDate;
                projectRequest.Status = updatedRequest.Status;
                projectRequest.Claimed = updatedRequest.Claimed;
                projectRequest.ClaimedByUserId = updatedRequest.ClaimedByUserId;

                db.SaveChanges();

                return Results.Ok(new ProjectRequestDto(projectRequest));
            });

            // DELETE ProjectRequest
            app.MapDelete("/projectrequests/{id}", (AppDbContext db, int id) =>
            {
                var projectRequest = db.ProjectRequests
                    .SingleOrDefault(pr => pr.Id == id);

                if (projectRequest == null)
                {
                    return Results.NotFound($"No project request found with the id: {id}");
                }

                db.ProjectRequests.Remove(projectRequest);
                db.SaveChanges();

                return Results.Ok(new ProjectRequestDto(projectRequest));
            });
        }
    }
}
