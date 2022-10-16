using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Entities;

public class Test: ModifiableModel
{
    public string Name { get; set; } = string.Empty;
    public Guid UserId { get; set; }
}