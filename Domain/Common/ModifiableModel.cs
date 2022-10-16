using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain.Common;

public class ModifiableModel: CreatableModel
{
    [Column("modification_history")] public string? ModificationHistory { get; set; }
    [NotMapped] public string? ModificationNotes { get; set; }
}