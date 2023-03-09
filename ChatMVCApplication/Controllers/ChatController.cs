using ChatMVCApplication.Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatMVCApplication.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int id)
        {
            return View(new PrivateChatDto() { ChatId = 1.ToString() });
        }

        public IActionResult Titles() { 
            return View();
        }
    }
}
