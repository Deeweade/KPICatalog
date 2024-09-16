using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("EmployeeRole")]
public class EmployeeRole
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int EmployeeId { get; set; }

    public virtual Role Role { get; set; }
    public virtual Employee Employee { get; set; }
}