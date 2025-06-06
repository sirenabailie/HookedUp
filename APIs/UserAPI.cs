using HookedUp.Models;

namespace HookedUp.APIs
{
    public static class UserAPI
    {
        public static void Map(WebApplication app)
        {
            // GET All
            app.MapGet("/users", (HookedUpDbContext db) =>
            {
                var allUsers = db.Users.ToList();
                if (allUsers.Count == 0)
                {
                    return Results.Ok("There are no users.");
                }
                return Results.Ok(allUsers);
            });

            // GET A SINGLE USER BY ID
            app.MapGet("/users/{userId}", (HookedUpDbContext db, int userId) =>
            {
                var user = db.Users
                             .SingleOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return Results.NotFound($"No User found with Id = {userId}");
                }

                return Results.Ok(user);
            });

            // CREATE
            app.MapPost("/users", (HookedUpDbContext db, User newUser) =>
            {
                var u = new User
                {
                    Name           = newUser.Name,
                    Email          = newUser.Email,
                    Password       = newUser.Password,
                    Role           = newUser.Role,
                    ProfilePicture = newUser.ProfilePicture,
                    CreatedAt      = DateTime.Now,
                    UpdatedAt      = DateTime.Now
                };

                db.Users.Add(u);
                db.SaveChanges();

                return Results.Created($"/users/{u.Id}", u);
            });

            // UPDATE
            app.MapPut("/users/{userId}", (HookedUpDbContext db, int userId, User updatedUser) =>
            {
                var existing = db.Users
                                 .SingleOrDefault(u => u.Id == userId);

                if (existing == null)
                {
                    return Results.NotFound($"No User found with Id = {userId}");
                }

                existing.Name           = updatedUser.Name;
                existing.Email          = updatedUser.Email;
                existing.Password       = updatedUser.Password;
                existing.Role           = updatedUser.Role;
                existing.ProfilePicture = updatedUser.ProfilePicture;
                existing.UpdatedAt      = DateTime.Now;

                db.SaveChanges();
                return Results.Ok(existing);
            });

            // DELETE
            app.MapDelete("/users/{userId}", (HookedUpDbContext db, int userId) =>
            {
                var toDelete = db.Users
                                 .SingleOrDefault(u => u.Id == userId);

                if (toDelete == null)
                {
                    return Results.NotFound($"No User found with Id = {userId}");
                }

                db.Users.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
