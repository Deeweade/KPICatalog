using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("Action")]
public class Action
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual ICollection<RoleAllowedAction> RoleAllowedActions { get; set; }
}
