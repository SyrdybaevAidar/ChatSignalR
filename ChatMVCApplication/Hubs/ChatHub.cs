using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatMVCApplication.Hubs
{
    //[Authorize]
    public class ChatHub : Hub
    {
        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
        }

        public async Task CreatePrivateChat(int toUser) {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Test");
            //createChat
        }

        public async Task CreateGroupChat(List<int> userIds)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, "Test");
            //createChat
        }

        public async Task GetGroupChat(int chatId) { 
            
        }
        public async Task SendPrivateMessage(string toUser, string message)
        {
            await Clients.Group(toUser).SendAsync("ReceiveMessage", toUser, message);
        }

        public async Task SendGroupMessage(int chatId, string message) { 
            
        }
    }
}
