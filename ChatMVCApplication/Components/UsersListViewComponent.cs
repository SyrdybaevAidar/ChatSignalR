using ChatMVCApplication.Business.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatMVCApplication.Components
{
    public class UsersListViewComponent : ViewComponent
    {
        private readonly IChatService _chatService;
        public UsersListViewComponent(IChatService chatService)
        {
            _chatService = chatService;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUserId = int.Parse(ViewContext.HttpContext.User.FindFirstValue(ClaimTypes.NameIdentifier)!);
            var users = await _chatService.GetAllUsers(currentUserId);
            return View(users);
        }
    }
}
