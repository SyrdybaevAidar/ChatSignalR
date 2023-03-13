using ChatMVCApplication.Business;
using ChatMVCApplication.Business.Models.Mapper;
using ChatMVCApplication.Cache;
using ChatMVCApplication.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddSignalR();
builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication();
builder.Services.AddAutoMapper(typeof(MappingProfile));
builder.Services.AddServices(builder.Configuration);
builder.Services.AddSingleton<OnlineUsersService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();
app.MapHub<ChatHub>("/chatHub");
app.MapHub<UserStatusHub>("/userStatus");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
