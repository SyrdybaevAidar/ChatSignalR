using ChatMVCApplication.DataAccess.Entities;
using ChatMVCApplication.DataAccess.Types;

namespace ChatApplication.DataAccess.Entities
{
    public class Chat
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? UserId { get; set; }
        public User? User { get; set; }
        public ChatType ChatType { get; set; }
        public ICollection<User> Users { get; set; }
        public ICollection<Message> Messages { get; set; }
        public Chat(string title, ChatType chatType)
        {
            Title = title;
            ChatType = chatType;
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
}
