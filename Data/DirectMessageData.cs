using HookedUp.Models;

namespace HookedUp.Data
{
    public class DirectMessageData
    {
        public static List<DirectMessage> DirectMessages = new()
        {
          new DirectMessage
          {
              Id = 1,
              SenderId = 1,  // This should be a valid UserId
              ReceiverId = 2,  // This should be a valid UserId
              ProjectRequestId = 1,
              MessageText = "Hi, I'd love to help with your baby blanket project!",
              Timestamp = DateTime.Now
          }
        };
    }
}
