using ChatMVCApplication.Business.Services.Interfaces;
using ChatMVCApplication.Cache;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using NuGet.Protocol.Plugins;
using System.Security.Claims;

namespace ChatMVCApplication.Hubs
{
    [Authorize]
    public class UserStatusHub : Hub
    {   
        public static OnlineUsersService _onlineUsersService { get; set; }
        public UserStatusHub(OnlineUsersService onlineUsersService)
        {
            _onlineUsersService = onlineUsersService;
        }
        public override async Task OnConnectedAsync()
        {   
            var currentUserId = Context.User!.FindFirstValue(ClaimTypes.NameIdentifier)!;
            _onlineUsersService.UserIds.Add(currentUserId);

            await Groups.AddToGroupAsync(Context.ConnectionId, currentUserId);
            await Clients.All.SendAsync("Online", currentUserId);
            await Clients.Client(Context.ConnectionId).SendAsync("GetAllOnlineUserIds", _onlineUsersService.UserIds);
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var currentUserId = Context.User!.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await Clients.All.SendAsync("Offline", currentUserId);
            _onlineUsersService.UserIds.Remove(currentUserId);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
