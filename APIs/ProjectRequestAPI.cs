using HookedUp.Models;

namespace HookedUp.APIs
{
    public static class ProjectRequestAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL
            app.MapGet("/projectrequests", (HookedUpDbContext db) =>
            {
                var allRequests = db.ProjectRequests.ToList();
                if (allRequests.Count == 0)
                {
                    return Results.Ok("There are no project requests.");
                }
                return Results.Ok(allRequests);
            });

            // GET A SINGLE PROJECT REQUEST BY ID
            app.MapGet("/projectrequests/{requestId}", (HookedUpDbContext db, int requestId) =>
            {
                var request = db.ProjectRequests
                                .SingleOrDefault(pr => pr.Id == requestId);

                if (request == null)
                {
                    return Results.NotFound($"No ProjectRequest found with Id = {requestId}");
                }

                return Results.Ok(request);
            });

            // GET ALL PROJECT REQUESTS FOR A GIVEN USER
            app.MapGet("/projectrequests/user/{userId}", (HookedUpDbContext db, int userId) =>
            {
                var userRequests = db.ProjectRequests
                                     .Where(pr => pr.UserId == userId)
                                     .ToList();

                if (!userRequests.Any())
                {
                    return Results.Ok($"User {userId} has no project requests.");
                }

                return Results.Ok(userRequests);
            });

            // CREATE A NEW PROJECT REQUEST
            app.MapPost("/projectrequests", (HookedUpDbContext db, ProjectRequest newRequest) =>
            {
                var pr = new ProjectRequest
                {
                    UserId          = newRequest.UserId,
                    Title           = newRequest.Title,
                    Description     = newRequest.Description,
                    ProjectType     = newRequest.ProjectType,
                    Location        = newRequest.Location,
                    DueDate         = newRequest.DueDate,
                    Status          = newRequest.Status,
                    Claimed         = newRequest.Claimed,
                    ClaimedByUserId = newRequest.ClaimedByUserId,
                    CreatedAt       = DateTime.Now,
                    UpdatedAt       = DateTime.Now
                };

                db.ProjectRequests.Add(pr);
                db.SaveChanges();

                return Results.Created($"/projectrequests/{pr.Id}", pr);
            });

            // UPDATE
            app.MapPut("/projectrequests/{requestId}", (HookedUpDbContext db, int requestId, ProjectRequest updatedRequest) =>
            {
                var existing = db.ProjectRequests
                                 .SingleOrDefault(pr => pr.Id == requestId);

                if (existing == null)
                {
                    return Results.NotFound($"No ProjectRequest found with Id = {requestId}");
                }

                // Overwrite each property except Id and CreatedAt
                existing.UserId          = updatedRequest.UserId;
                existing.Title           = updatedRequest.Title;
                existing.Description     = updatedRequest.Description;
                existing.ProjectType     = updatedRequest.ProjectType;
                existing.Location        = updatedRequest.Location;
                existing.DueDate         = updatedRequest.DueDate;
                existing.Status          = updatedRequest.Status;
                existing.Claimed         = updatedRequest.Claimed;
                existing.ClaimedByUserId = updatedRequest.ClaimedByUserId;

                // Update the timestamp
                existing.UpdatedAt = DateTime.Now;

                db.SaveChanges();
                return Results.Ok(existing);
            });

            // DELETE
            app.MapDelete("/projectrequests/{requestId}", (HookedUpDbContext db, int requestId) =>
            {
                var toDelete = db.ProjectRequests
                                 .SingleOrDefault(pr => pr.Id == requestId);

                if (toDelete == null)
                {
                    return Results.NotFound($"No ProjectRequest found with Id = {requestId}");
                }

                db.ProjectRequests.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
