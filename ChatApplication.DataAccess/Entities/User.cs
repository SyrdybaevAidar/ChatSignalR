using Microsoft.AspNetCore.Identity;

namespace ChatApplication.DataAccess.Entities
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
