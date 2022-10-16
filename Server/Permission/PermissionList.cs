namespace Server.Permission;

public class PermissionList
{
    public static readonly Permission[] InitialList =
    {
        new (PermissionNameList.FullAccess, Array.Empty<string>()),
        new (PermissionNameList.User, new []{PermissionNameList.FullAccess}),
        new (PermissionNameList.UserWrite, new []{PermissionNameList.User}),
        new (PermissionNameList.UserDelete, new []{PermissionNameList.User}),
        new (PermissionNameList.UserRead, new []{PermissionNameList.UserWrite, PermissionNameList.UserDelete})
    };

    private static Permission[] _value;

    public static Permission[] Value
    {
        get
        {
            return _value ??= InitialList.Select(x => x with{ Overriders = GetAllOverriders(x.Id)}).ToArray();
        }
    }

    private static string[] GetAllOverriders(string permissionId)
    {
        var (_,overriders) = InitialList.First(x => x.Id == permissionId);

        return overriders.Concat(overriders.SelectMany(GetAllOverriders)).Distinct().ToArray();
    }
}