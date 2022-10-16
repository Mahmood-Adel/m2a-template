using Microsoft.AspNetCore.Authorization;

namespace Server.Permission;

public class PermissionHandler: AuthorizationHandler<PermissionRequirement>
{
    protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, PermissionRequirement requirement)
    {
        throw new NotImplementedException();
    }
}