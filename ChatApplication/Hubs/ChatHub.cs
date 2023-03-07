using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatApplication.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, Context.User.Identity.Name);
            await base.OnConnectedAsync();
        }
        public async Task SendMessage(string receiver, string message)
        {
            await Clients.Group(receiver).SendAsync("ReceiveMessage", Context.User.Identity.Name, message);
        }
    }
}
