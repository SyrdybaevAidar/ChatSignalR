using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int UnreadMessageCount { get; set; }
        public string LastMessage { get; set; }
    }
}
