using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("EmployeeRoles")]
public class Role
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Title { get; set; }
    public int RoleTypeId { get; set; }

    public virtual RoleType RoleType { get; set; }

    public virtual ICollection<EmployeeRole> EmployeesRoles { get; set; }
    public virtual ICollection<RoleAllowedAction> AllowedActions { get; set; }
}
