using AutoMapper;
using ChatApplication.DataAccess.Entities;
using ChatMVCApplication.Business.Models;
using ChatMVCApplication.Business.Services.Interfaces;
using ChatMVCApplication.Business.Uow;
using ChatMVCApplication.DataAccess.Entities;
using ChatMVCApplication.DataAccess.Types;
using Microsoft.EntityFrameworkCore;

namespace ChatMVCApplication.Business.Services
{
    public class ChatService : IChatService
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;
        public ChatService(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        public async Task<PrivateChatDto> GetMessagesByUserIdAsync(int currentUserId, int toUserId, int page, int messagecount) {
            var messages = await _uow.GetRepository<Message>()
                .Where(x => (x.UserId == currentUserId || x.ToUserId == currentUserId) && (x.ToUserId == toUserId || x.UserId == toUserId))
                .OrderByDescending(x => x.CreateDate)
                .Select(x => new MessageDto() { 
                    Id = x.Id,
                    IsMineMessage = currentUserId == x.UserId,
                    CreateDate = x.CreateDate,
                    Text= x.Text
                })
                .Skip((page-1) * messagecount)
                .Take(messagecount)
                .ToListAsync();

            var toUserName = await _uow.GetRepository<User>()
                .Where(x => x.Id == toUserId)
                .Select(x => x.Email)
                .FirstAsync();

            return new PrivateChatDto() { 
                UserName = toUserName,
                ToUserId = toUserId,
                Messages = messages
            };
        }

        public async Task<MessageDto> SendMessageAsync(int currentUserId, int toUserId, string text) {

            var messageEntry = await _uow.GetRepository<Message>().AddAsync(new(text, false, currentUserId) { 
                ToUserId = toUserId
            });

            await _uow.SaveChangesAsync();
            return _mapper.Map<MessageDto>(messageEntry.Entity);
        }

        public async Task<List<UserDto>> GetAllUsers(int currentUserId) { 
            var users = await _uow.GetRepository<User>()
                .Where(x => x.Id != currentUserId)
                .Include(x => x.Messages.Where(x => x.ToUserId == currentUserId || x.UserId == currentUserId).OrderByDescending(x => x.CreateDate).Take(1))
                .ToListAsync();

            return _mapper.Map<List<UserDto>>(users);
        }

        public async Task MarkedMessageToReadAsync(int currentUserId, List<int> messageIds) {
            var messages = await _uow.GetRepository<Message>()
                .Where(x => x.ToUserId == currentUserId && messageIds.Contains(x.Id))
                .ToListAsync();

            messages.ForEach(message => { 
                message.IsRead = true;
            });
            _uow.GetRepository<Message>().UpdateRange(messages);
            await _uow.SaveChangesAsync();
        }
    }
}
