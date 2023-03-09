using ChatMVCApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChatMVCApplication.DataAccess.Repositories
{
    public class UserRepository
    {
        public readonly IQueryable<User> All;
        public UserRepository(DbContext dbContext)
        {
            All = dbContext.Set<User>();
        }
        //public async Task CheckPassword(string login, string password) {
        //    var user = await All.Where(x => x.Login == login).FirstOrDefaultAsync();

        //}
    }
}
