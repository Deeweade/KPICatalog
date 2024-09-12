using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("RoleType")]
public class RoleType
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string Title { get; set; }

    public virtual ICollection<Role> Roles { get; set; }
}