using HookedUp.Models;

namespace HookedUp.APIs
{
    public static class ReviewRatingAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL
            app.MapGet("/reviewratings", (HookedUpDbContext db) =>
            {
                var allRatings = db.ReviewRatings.ToList();
                if (allRatings.Count == 0)
                {
                    return Results.Ok("There are no review ratings.");
                }
                return Results.Ok(allRatings);
            });

            // GET A SINGLE REVIEW RATING BY ID
            app.MapGet("/reviewratings/{ratingId}", (HookedUpDbContext db, int ratingId) =>
            {
                var rating = db.ReviewRatings
                               .SingleOrDefault(rr => rr.Id == ratingId);

                if (rating == null)
                {
                    return Results.NotFound($"No ReviewRating found with Id = {ratingId}");
                }

                return Results.Ok(rating);
            });

            // GET ALL FOR A GIVEN PROJECT REQUEST
            app.MapGet("/reviewratings/project/{projectRequestId}", (HookedUpDbContext db, int projectRequestId) =>
            {
                var ratings = db.ReviewRatings
                                .Where(rr => rr.ProjectRequestId == projectRequestId)
                                .ToList();

                if (!ratings.Any())
                {
                    return Results.Ok($"No review ratings for ProjectRequestId = {projectRequestId}");
                }

                return Results.Ok(ratings);
            });

            // ─── CREATE
            app.MapPost("/reviewratings", (HookedUpDbContext db, ReviewRating newRating) =>
            {
                var rr = new ReviewRating
                {
                    ProjectRequestId = newRating.ProjectRequestId,
                    UserId           = newRating.UserId,
                    ArtistId         = newRating.ArtistId,
                    Rating           = newRating.Rating,
                    ReviewText       = newRating.ReviewText,
                    ReviewImage      = newRating.ReviewImage ?? Array.Empty<string>(),
                    CreatedAt        = DateTime.Now,
                    UpdatedAt        = DateTime.Now
                };

                db.ReviewRatings.Add(rr);
                db.SaveChanges();

                return Results.Created($"/reviewratings/{rr.Id}", rr);
            });

            // UPDATE
            app.MapPut("/reviewratings/{ratingId}", (HookedUpDbContext db, int ratingId, ReviewRating updatedRating) =>
            {
                var existing = db.ReviewRatings
                                 .SingleOrDefault(rr => rr.Id == ratingId);

                if (existing == null)
                {
                    return Results.NotFound($"No ReviewRating found with Id = {ratingId}");
                }

                existing.ProjectRequestId = updatedRating.ProjectRequestId;
                existing.UserId           = updatedRating.UserId;
                existing.ArtistId         = updatedRating.ArtistId;
                existing.Rating           = updatedRating.Rating;
                existing.ReviewText       = updatedRating.ReviewText;
                existing.ReviewImage      = updatedRating.ReviewImage ?? Array.Empty<string>();
                existing.UpdatedAt        = DateTime.Now;

                db.SaveChanges();
                return Results.Ok(existing);
            });

            // DELETE
            app.MapDelete("/reviewratings/{ratingId}", (HookedUpDbContext db, int ratingId) =>
            {
                var toDelete = db.ReviewRatings
                                 .SingleOrDefault(rr => rr.Id == ratingId);

                if (toDelete == null)
                {
                    return Results.NotFound($"No ReviewRating found with Id = {ratingId}");
                }

                db.ReviewRatings.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
