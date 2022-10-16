using Microsoft.AspNetCore.Authorization;

namespace Server.Permission;

public class PermissionRequirement: IAuthorizationRequirement
{
    public string PermissionId { get; }

    public PermissionRequirement(string permissionId)
    {
        PermissionId = permissionId;
    }
}