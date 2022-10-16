using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;
public class CreatableModel: Model 
{
    [Column("created_by_id")] public Guid? CreatedById { get; set; }
    [Column("deletion_time")] public DateTime? DeletionTime { get; set; }
    [Column("deleted_by_id")] public Guid? DeletedById { get; set; }
    [Column("is_deleted")] public bool IsDeleted { get; set; }
}