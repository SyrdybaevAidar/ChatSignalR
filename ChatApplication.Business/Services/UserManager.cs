using ChatApplication.Business.Models;
using ChatApplication.Business.UnitOfWork;
using ChatApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatApplication.Business.Services
{
    public class UserManager
    {
        private readonly IUnitOfWork _unitOfWork;
        public UserManager(IUnitOfWork unitOfWork) { 
            _unitOfWork = unitOfWork;
        }

        //public async Task<int> SignInAsync(UserLoginDto dto) {
        //    var repo = _unitOfWork.GetRepository<User>();
        //    if (!await repo.AnyAsync(x => x.Login == dto.login && x.Password == dto.password)) {
        //        throw new Exception("Неверный логин или пароль");
        //    }

        //    return await repo.Where(x => x.Login == dto.login)
        //        .Select(x => x.Id)
        //        .FirstAsync();
        //}
    }
}
