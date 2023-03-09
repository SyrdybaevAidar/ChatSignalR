using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models
{
    public class PrivateChatDto
    {
        public string ChatId { get; set; }
        public List<MessageDto> Messages { get; set; }
    }
}
