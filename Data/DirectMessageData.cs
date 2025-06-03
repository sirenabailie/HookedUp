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
                SenderId = 1,
                ReceiverId = 2,
                ProjectRequestId = 1,
                MessageText = "Hi, I'd love to help with your baby blanket project!",
                Timestamp = DateTime.Now
            }
        };
    }
}
