﻿using ChatMVCApplication.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.Business.Services.Interfaces
{
    public interface IChatService
    {
        Task<PrivateChatDto> GetPrivateByIdAsync(int id);
    }
}
