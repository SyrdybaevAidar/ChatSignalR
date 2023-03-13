using ChatMVCApplication.DataAccess.Context;
using ChatMVCApplication.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ChatMVCApplication.DataAccess
{
    public static class DbContextRegister
    {
        public static void AddChatDbContext(this IServiceCollection services, string connectionString) {
            services.AddDbContext<ChatDbContext>(options =>
                    options.UseNpgsql(connectionString));
            
            services.AddDefaultIdentity<User>()
                .AddEntityFrameworkStores<ChatDbContext>();

        }
    }
}
