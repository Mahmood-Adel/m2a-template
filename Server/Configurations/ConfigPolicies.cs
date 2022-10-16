using Server.Permission;

namespace Server.Configurations;

public static partial class Config
{
    public static void ConfigurePolicies(IServiceCollection services)
    {
        foreach (var (permission,_) in PermissionList.Value)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy(permission, builder => builder.Requirements.Add(new PermissionRequirement(permission)));
            });
        }
    }
}