using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class Role: IdentityRole<Guid>
{
    public string DisplayName { get; set; } = default!;
}