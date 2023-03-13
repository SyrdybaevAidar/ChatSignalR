using ChatMVCApplication.Business.Services;
using ChatMVCApplication.Business.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ChatMVCApplication.DataAccess;
using ChatMVCApplication.Business.Uow;

namespace ChatMVCApplication.Business
{
    public static class ServiceDIRegistration
    {
        public static void AddServices(this IServiceCollection services, IConfiguration configuration) {
            services.AddScoped<IChatService, ChatService>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddChatDbContext(configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
