using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class RoleClaim: IdentityRoleClaim<Guid>
{
    
}