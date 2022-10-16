using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace Infrastructure.Identity;

public class User: IdentityUser<Guid>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; }
    // public virtual ICollection<Test> Tests { get; set; } = default!;
    // public virtual ICollection<CreatableModel> CreatedModels { get; set; } = default!;
    // public virtual ICollection<CreatableModel> DeletedModels { get; set; } = default!;
}