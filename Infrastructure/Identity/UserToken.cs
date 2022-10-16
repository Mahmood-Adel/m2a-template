using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class UserToken: IdentityUserToken<Guid>
{
}