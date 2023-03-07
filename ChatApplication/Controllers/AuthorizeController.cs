using ChatApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApplication.Controllers
{
    public class AuthorizeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(AuthorizeModel model)
        {   
            return RedirectToAction("Details", "Chat");
        }
    }
}
