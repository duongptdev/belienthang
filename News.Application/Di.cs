using News.Application.UserServices;
using News.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using News.Application.NewServices;
using News.Application.SettingServices;

namespace News.Application
{
    public static class Di
    {
        public static void AddDependencies(this IServiceCollection service)
        {
            service.AddScoped<IRepository, Repository>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<INewService, NewService>();
            service.AddScoped<ISettingService, SettingService>();
            service.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
