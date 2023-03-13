using ChatMVCApplication.Business.Models;
using ChatMVCApplication.Business.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ChatMVCApplication.Controllers
{
    [Authorize]
    public class ChatController : Controller
    {
        private readonly IChatService _chatService;
        private int CurrentUserId => int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int id) ? id : 0;
        public ChatController(IChatService chatService)
        {
            _chatService = chatService;
        }

        public async Task<IActionResult> Details(int toUserId) {
            var messages = await _chatService.GetMessagesByUserIdAsync(CurrentUserId, toUserId);
            return View(messages);
        }
    }
}
