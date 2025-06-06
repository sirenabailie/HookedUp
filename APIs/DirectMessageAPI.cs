// File: APIs/DirectMessageAPI.cs

using Microsoft.EntityFrameworkCore;
using HookedUp;
using HookedUp.Models;

namespace HookedUp.APIs
{
    public static class DirectMessageAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL
            app.MapGet("/directmessages", (HookedUpDbContext db) =>
            {
                var allMessages = db.DirectMessages
                    .Include(dm => dm.Sender)
                    .Include(dm => dm.Receiver)
                    .Include(dm => dm.ProjectRequest)
                    .ToList();

                if (allMessages.Count == 0)
                {
                    return Results.Ok("There are no direct messages.");
                }

                return Results.Ok(allMessages);
            });

            // GET A SINGLE DIRECT MESSAGE BY ID
            app.MapGet("/directmessages/{messageId}", (HookedUpDbContext db, int messageId) =>
            {
                var message = db.DirectMessages
                    .Include(dm => dm.Sender)
                    .Include(dm => dm.Receiver)
                    .Include(dm => dm.ProjectRequest)
                    .SingleOrDefault(dm => dm.Id == messageId);

                if (message == null)
                {
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");
                }

                return Results.Ok(message);
            });

            // GET DIRECT MESSAGES BY SENDER ID
            app.MapGet("/directmessages/sender/{senderId}", (HookedUpDbContext db, int senderId) =>
            {
                var sentMessages = db.DirectMessages
                    .Where(dm => dm.SenderId == senderId)
                    .Include(dm => dm.Sender)
                    .Include(dm => dm.Receiver)
                    .Include(dm => dm.ProjectRequest)
                    .ToList();

                if (!sentMessages.Any())
                {
                    return Results.Ok($"User {senderId} has not sent any direct messages.");
                }

                return Results.Ok(sentMessages);
            });

            // GET DIRECT MESSAGES BY RECEIVER ID
            app.MapGet("/directmessages/receiver/{receiverId}", (HookedUpDbContext db, int receiverId) =>
            {
                var receivedMessages = db.DirectMessages
                    .Where(dm => dm.ReceiverId == receiverId)
                    .Include(dm => dm.Sender)
                    .Include(dm => dm.Receiver)
                    .Include(dm => dm.ProjectRequest)
                    .ToList();

                if (!receivedMessages.Any())
                {
                    return Results.Ok($"User {receiverId} has not received any direct messages.");
                }

                return Results.Ok(receivedMessages);
            });

            // CREATE
            app.MapPost("/directmessages", (HookedUpDbContext db, DirectMessage newMessage) =>
            {
                var dm = new DirectMessage
                {
                    SenderId         = newMessage.SenderId,
                    ReceiverId       = newMessage.ReceiverId,
                    ProjectRequestId = newMessage.ProjectRequestId,
                    MessageText      = newMessage.MessageText,
                    Timestamp        = DateTime.Now
                };

                db.DirectMessages.Add(dm);
                db.SaveChanges();

                db.Entry(dm).Reference(x => x.Sender).Load();
                db.Entry(dm).Reference(x => x.Receiver).Load();
                db.Entry(dm).Reference(x => x.ProjectRequest).Load();

                return Results.Created($"/directmessages/{dm.Id}", dm);
            });

            // UPDATE
            app.MapPut("/directmessages/{messageId}", (HookedUpDbContext db, int messageId, DirectMessage updatedMessage) =>
            {
                var existing = db.DirectMessages
                    .SingleOrDefault(dm => dm.Id == messageId);

                if (existing == null)
                {
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");
                }

                existing.SenderId         = updatedMessage.SenderId;
                existing.ReceiverId       = updatedMessage.ReceiverId;
                existing.ProjectRequestId = updatedMessage.ProjectRequestId;
                existing.MessageText      = updatedMessage.MessageText;
                existing.Timestamp        = DateTime.Now;

                db.SaveChanges();

                // Reload navigation properties:
                db.Entry(existing).Reference(x => x.Sender).Load();
                db.Entry(existing).Reference(x => x.Receiver).Load();
                db.Entry(existing).Reference(x => x.ProjectRequest).Load();

                return Results.Ok(existing);
            });

            // DELETE A DIRECT MESSAGE
            app.MapDelete("/directmessages/{messageId}", (HookedUpDbContext db, int messageId) =>
            {
                var toDelete = db.DirectMessages
                    .SingleOrDefault(dm => dm.Id == messageId);

                if (toDelete == null)
                {
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");
                }

                db.DirectMessages.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
