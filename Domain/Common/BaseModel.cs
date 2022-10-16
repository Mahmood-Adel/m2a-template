using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Common;
public class BaseModel
{
    [Column("creation_time")]
    public DateTime CreationTime { get; set; }   
}