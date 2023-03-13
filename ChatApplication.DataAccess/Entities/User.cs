using Microsoft.AspNetCore.Identity;

namespace ChatMVCApplication.DataAccess.Entities
{
    public class User : IdentityUser<int>
    {   
        public ICollection<Message> Messages { get; set; }
        public User()
        {
            Messages = new List<Message>();
        }
    }
}
