using Microsoft.AspNetCore.Identity;

namespace ChatMVCApplication.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {
        public ICollection<Chat> Chats { get; set; }
        public User()
        {
            Chats = new List<Chat>();
        }
    }
}
