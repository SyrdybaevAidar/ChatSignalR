using Microsoft.AspNetCore.Mvc;

namespace ChatMVCApplication.Cache
{
    public class OnlineUsersService 
    {
        public List<string> UserIds { get; set; }
        public OnlineUsersService()
        {
            UserIds= new List<string>();
        }
    }
}
