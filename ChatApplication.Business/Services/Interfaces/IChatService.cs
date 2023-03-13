using ChatMVCApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Services.Interfaces
{
    public interface IChatService
    {
        Task<PrivateChatDto> GetMessagesByUserIdAsync(int currentUserId, int toUserId, int page, int messagecount);
        Task<MessageDto> SendMessageAsync(int currentUserId, int toUserId, string text);
        Task<List<UserDto>> GetAllUsers(int currentUserId);
    }
}
