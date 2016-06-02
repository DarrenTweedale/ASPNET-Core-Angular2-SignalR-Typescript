using AspNetCoreAngular2.Models;

namespace AspNetCoreAngular2.Hubs
{
    [HubName("coolmessages")]
    public class CoolMessagesHub : Hub
    {
        public void SendMessage(ChatMessage chatMessage)
        {
            Clients.All.SendMessage(chatMessage);
        }
    }
}
