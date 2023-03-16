using AutoMapper;
using ChatMVCApplication.Business.Models;
using ChatMVCApplication.DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatMVCApplication.Controllers
{
    public class HomeController : Controller
    {
        private UserManager<User> _userManager { get; set; }
        private IMapper _mapper { get; set; }
        public HomeController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {   
            var users = await _userManager.Users.ToListAsync();
            return View(_mapper.Map<List<UserDto>>(users));
        }

        public IActionResult Private() {
            return View();
        }
    }
}
