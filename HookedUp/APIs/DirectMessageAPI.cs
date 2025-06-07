using Microsoft.EntityFrameworkCore;
using HookedUp;
using HookedUp.Models;
using HookedUp.DTOs;

namespace HookedUp.APIs
{
    public static class DirectMessageAPI
    {
        public static void Map(WebApplication app)
        {
            // GET ALL
            app.MapGet("/directmessages", (HookedUpDbContext db) =>
            {
                var dtos = db.DirectMessages
                    .Select(dm => new DirectMessageDto
                    {
                        Id               = dm.Id,
                        SenderId         = dm.SenderId,
                        ReceiverId       = dm.ReceiverId,
                        ProjectRequestId = dm.ProjectRequestId,
                        MessageText      = dm.MessageText,
                        Timestamp        = dm.Timestamp
                    })
                    .ToList();

                if (!dtos.Any())
                    return Results.Ok("There are no direct messages.");

                return Results.Ok(dtos);
            });

            // GET SINGLE DIRECT MESSAGE BY ID
            app.MapGet("/directmessages/{messageId}", (HookedUpDbContext db, int messageId) =>
            {
                var dto = db.DirectMessages
                    .Where(dm => dm.Id == messageId)
                    .Select(dm => new DirectMessageDto
                    {
                        Id               = dm.Id,
                        SenderId         = dm.SenderId,
                        ReceiverId       = dm.ReceiverId,
                        ProjectRequestId = dm.ProjectRequestId,
                        MessageText      = dm.MessageText,
                        Timestamp        = dm.Timestamp
                    })
                    .SingleOrDefault();

                if (dto == null)
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");

                return Results.Ok(dto);
            });

            // GET DIRECT MESSAGES BY SENDER ID
            app.MapGet("/directmessages/sender/{senderId}", (HookedUpDbContext db, int senderId) =>
            {
                var dtos = db.DirectMessages
                    .Where(dm => dm.SenderId == senderId)
                    .Select(dm => new DirectMessageDto
                    {
                        Id               = dm.Id,
                        SenderId         = dm.SenderId,
                        ReceiverId       = dm.ReceiverId,
                        ProjectRequestId = dm.ProjectRequestId,
                        MessageText      = dm.MessageText,
                        Timestamp        = dm.Timestamp
                    })
                    .ToList();

                if (!dtos.Any())
                    return Results.Ok($"User {senderId} has not sent any direct messages.");

                return Results.Ok(dtos);
            });

            // GET DIRECT MESSAGES BY RECEIVER ID
            app.MapGet("/directmessages/receiver/{receiverId}", (HookedUpDbContext db, int receiverId) =>
            {
                var dtos = db.DirectMessages
                    .Where(dm => dm.ReceiverId == receiverId)
                    .Select(dm => new DirectMessageDto
                    {
                        Id               = dm.Id,
                        SenderId         = dm.SenderId,
                        ReceiverId       = dm.ReceiverId,
                        ProjectRequestId = dm.ProjectRequestId,
                        MessageText      = dm.MessageText,
                        Timestamp        = dm.Timestamp
                    })
                    .ToList();

                if (!dtos.Any())
                    return Results.Ok($"User {receiverId} has not received any direct messages.");

                return Results.Ok(dtos);
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
                var existing = db.DirectMessages.SingleOrDefault(dm => dm.Id == messageId);
                if (existing == null)
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");

                existing.SenderId         = updatedMessage.SenderId;
                existing.ReceiverId       = updatedMessage.ReceiverId;
                existing.ProjectRequestId = updatedMessage.ProjectRequestId;
                existing.MessageText      = updatedMessage.MessageText;
                existing.Timestamp        = DateTime.Now;

                db.SaveChanges();

                db.Entry(existing).Reference(x => x.Sender).Load();
                db.Entry(existing).Reference(x => x.Receiver).Load();
                db.Entry(existing).Reference(x => x.ProjectRequest).Load();

                return Results.Ok(existing);
            });

            // DELETE
            app.MapDelete("/directmessages/{messageId}", (HookedUpDbContext db, int messageId) =>
            {
                var toDelete = db.DirectMessages.SingleOrDefault(dm => dm.Id == messageId);
                if (toDelete == null)
                    return Results.NotFound($"No DirectMessage found with Id = {messageId}");

                db.DirectMessages.Remove(toDelete);
                db.SaveChanges();

                return Results.Ok(toDelete);
            });
        }
    }
}
