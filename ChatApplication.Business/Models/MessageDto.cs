using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public DateTimeOffset LastMessageDateTime { get; set; }
        public string LastMessageText { get; set; }
    }
}
