using Microsoft.EntityFrameworkCore;
using HookedUp.Models;

namespace HookedUp.APIs
{
    public static class ArtistProfileAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL
            app.MapGet("/artistprofiles", (HookedUpDbContext db) =>
            {
                var allProfiles = db.ArtistProfiles.ToList();
                if (allProfiles.Count == 0)
                {
                    return Results.Ok("There are no artist profiles.");
                }
                return Results.Ok(allProfiles);
            });

            // GET A SINGLE ARTIST PROFILE BY ID
            app.MapGet("/artistprofiles/{profileId}", (HookedUpDbContext db, int profileId) =>
            {
                var profile = db.ArtistProfiles
                                .Include(ap => ap.User)
                                .SingleOrDefault(ap => ap.Id == profileId);

                if (profile == null)
                {
                    return Results.NotFound($"No ArtistProfile found with Id = {profileId}");
                }

                return Results.Ok(profile);
            });

            // GET ARTIST PROFILE BY USER ID
            app.MapGet("/artistprofiles/user/{userId}", (HookedUpDbContext db, int userId) =>
            {
                var profile = db.ArtistProfiles
                                .Include(ap => ap.User)
                                .SingleOrDefault(ap => ap.UserId == userId);

                if (profile == null)
                {
                    return Results.NotFound($"No ArtistProfile found for UserId = {userId}");
                }

                return Results.Ok(profile);
            });

            // CREATE
            app.MapPost("/artistprofiles", (HookedUpDbContext db, ArtistProfile newProfile) =>
            {
                var ap = new ArtistProfile
                {
                    UserId         = newProfile.UserId,
                    Specialization = newProfile.Specialization,
                    ProfilePicture = newProfile.ProfilePicture,
                    ExpertiseLevel = newProfile.ExpertiseLevel,
                    WorkImages     = newProfile.WorkImages ?? new List<string>(),
                    WorkDescription= newProfile.WorkDescription,
                    CreatedAt      = DateTime.Now,
                    UpdatedAt      = DateTime.Now
                };

                db.ArtistProfiles.Add(ap);
                db.SaveChanges();

                return Results.Created($"/artistprofiles/{ap.Id}", ap);
            });

            // UPDATE
            app.MapPut("/artistprofiles/{profileId}", (HookedUpDbContext db, int profileId, ArtistProfile updatedProfile) =>
            {
                var existing = db.ArtistProfiles
                                 .SingleOrDefault(ap => ap.Id == profileId);

                if (existing == null)
                {
                    return Results.NotFound($"No ArtistProfile found with Id = {profileId}");
                }

                existing.UserId          = updatedProfile.UserId;
                existing.Specialization  = updatedProfile.Specialization;
                existing.ProfilePicture  = updatedProfile.ProfilePicture;
                existing.ExpertiseLevel  = updatedProfile.ExpertiseLevel;
                existing.WorkImages      = updatedProfile.WorkImages ?? new List<string>();
                existing.WorkDescription = updatedProfile.WorkDescription;
                existing.UpdatedAt       = DateTime.Now;

                db.SaveChanges();
                return Results.Ok(existing);
            });

            // DELETE
            app.MapDelete("/artistprofiles/{profileId}", (HookedUpDbContext db, int profileId) =>
            {
                var toDelete = db.ArtistProfiles
                                 .SingleOrDefault(ap => ap.Id == profileId);

                if (toDelete == null)
                {
                    return Results.NotFound($"No ArtistProfile found with Id = {profileId}");
                }

                db.ArtistProfiles.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
