using ChatMVCApplication.Business.Services.Interfaces;
using ChatMVCApplication.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Security.Claims;

namespace ChatMVCApplication.Hubs
{
    [Authorize]
    public class ChatHub : Hub
    {   
        private readonly IChatService _chatService;
        public int CurrentUserId => int.TryParse(Context.User!.FindFirstValue(ClaimTypes.NameIdentifier), out int id) ? id : 0;
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

        public async Task GetMessages(int toUserId, int page) {
            var chat = await _chatService.GetMessagesByUserIdAsync(CurrentUserId, toUserId, page+1, 1);
            await Clients.Group(CurrentUserId.ToString()).SendAsync("ReturnMessages", chat.Messages, page+1);
        }
    }
}
