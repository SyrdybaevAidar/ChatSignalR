using AutoMapper;
using ChatMVCApplication.Business.Models;
using ChatMVCApplication.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace ChatMVCApplication.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private int CurrentUserId => int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int id) ? id : 0;
        private UserManager<User> _userManager { get; set; }
        private IMapper _mapper { get; set; }
        public HomeController(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {   
            var users = await _userManager.Users.Where(x => x.Id != CurrentUserId).ToListAsync();
            return View(_mapper.Map<List<UserDto>>(users));
        }

        public IActionResult Private() {
            return View();
        }
    }
}
