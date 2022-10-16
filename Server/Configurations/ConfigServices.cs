using Application.Common.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Server.Permission;
using Server.Services;

namespace Server.Configurations;

public static partial class Config
{
    public static void ConfigureServices(IServiceCollection services)
    {
        AddSingletonServices(services);
        AddScopedServices(services);
    }

    private static void AddSingletonServices(IServiceCollection services)
    {
        services.AddSingleton<ICurrentUserService, CurrentUserService>();
    }
    
    private static void AddScopedServices(IServiceCollection services)
    {
        services.AddScoped<IAuthorizationHandler, PermissionHandler>();
    }
}