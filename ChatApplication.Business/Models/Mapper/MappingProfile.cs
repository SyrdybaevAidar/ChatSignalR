using AutoMapper;
using ChatMVCApplication.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
            CreateMap<Message, MessageDto>();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.LastMessage, opt => opt.MapFrom(src => src.Messages.FirstOrDefault() == null ? "" : src.Messages.First().Text))
                .ForMember(dest => dest.UnreadMessageCount, opt => opt.MapFrom(src => src.Messages.Count(x => !x.IsRead)));
        }
    }
}
