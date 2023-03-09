using AutoMapper;
using ChatMVCApplication.Business.Models;
using ChatMVCApplication.Business.Services.Interfaces;
using ChatMVCApplication.Business.UnitOfWork;
using ChatMVCApplication.DataAccess.Entities;
using ChatMVCApplication.DataAccess.Types;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<PrivateChatDto> GetPrivateByIdAsync(int chatId) { 
            var chat = await _uow.GetRepository<Chat>()
                .Where(x => x.Id == chatId)
                .Include(x => x.Messages.OrderByDescending(x => x.CreateDate).Take(5).OrderBy(x => x.User))
                .Include(x => x.Users)
                .FirstAsync();

            return _mapper.Map<PrivateChatDto>(chat);
        }

        public async Task<PrivateChatDto> CreatePrivateChat(string title, int createUserId, int receiveUserId) {
            var users = await _uow.GetRepository<User>()
                .Where(x => x.Id == createUserId || x.Id == receiveUserId)
                .ToListAsync();
            var existChat = await _uow.GetRepository<Chat>()
                .Include(x => x.Messages)
                .Include(x => x.Users)
                .FirstOrDefaultAsync(x => x.Users.Any(x => x.Id == createUserId && x.Id == receiveUserId));

            if (existChat != null) {
                return _mapper.Map<PrivateChatDto>(existChat);
            }
            var chat = await _uow.GetRepository<Chat>().AddAsync(new Chat(title, ChatType.Private) {
                Users = users
            });

            await _uow.SaveChangesAsync();

            return _mapper.Map<PrivateChatDto>(chat);
        }
    }
}
