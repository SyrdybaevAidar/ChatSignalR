using ChatMVCApplication.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ChatMVCApplication.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {   
        private readonly IChatService _chatService;
        public ChatHub(IChatService chatService) { 
            _chatService = chatService;
        }
        public override async Task OnConnectedAsync()
        {
            var currentUserId = Context.User!.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await Groups.AddToGroupAsync(Context.ConnectionId, currentUserId);
            await base.OnConnectedAsync();
        }
        public async Task SendPrivateMessage(int toUserId, string message)
        {   
            var currentUserId = Context.User!.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await Clients.Group(toUserId.ToString()).SendAsync("ReceiveMessage", message, int.Parse(currentUserId));
            await _chatService.SendMessageAsync(int.Parse(currentUserId), toUserId, message);
        }
    }
}
