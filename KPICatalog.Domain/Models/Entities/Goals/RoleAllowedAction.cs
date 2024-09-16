using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("RoleAllowedAction")]
public class RoleAllowedAction
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int ActionId { get; set; }

    public virtual Role Role { get; set; }
    public virtual Action Action { get; set; }
}
