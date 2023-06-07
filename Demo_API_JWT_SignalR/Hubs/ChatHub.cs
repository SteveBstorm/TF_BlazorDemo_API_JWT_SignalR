using Microsoft.AspNetCore.SignalR;

namespace Demo_API_JWT_SignalR.Hubs
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string username, string message) //MethodCalledByClient
        {
            await Clients.All.SendAsync("ReceiveMessage", username, message);
        }

        public async Task JoinGroup(string groupname)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, groupname);
            await Clients.Group(groupname).SendAsync("FromGroup", "system", "Bienvenue");
        }

        public async Task SendToGroup(string group, string username, string message)
        {
            await Clients.Group(group).SendAsync("FromGroup", username, message);

        }


    }
}
