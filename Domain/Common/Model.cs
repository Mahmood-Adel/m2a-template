using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;
public class Model : BaseModel
{
    [Column("id")] [Key] public Guid Id { get; set; }
}