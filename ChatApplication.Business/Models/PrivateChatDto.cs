using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models
{
    public class PrivateChatDto
    {
        public int ToUserId { get; set; }
        public List<MessageDto> Messages { get; set; }
        public PrivateChatDto()
        {
            Messages = new();
        }
    }
}
