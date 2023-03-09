using Microsoft.AspNetCore.Mvc;

namespace ChatMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Private() {
            return View();
        }
    }
}
