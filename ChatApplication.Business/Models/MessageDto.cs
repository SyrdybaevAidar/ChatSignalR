﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Models
{
    public class MessageDto
    {
        public int Id { get; set; }
        public DateTimeOffset CreateDate { get; set; }
        public string Text { get; set; }
        public bool IsMineMessage { get; set; }
    }
}
