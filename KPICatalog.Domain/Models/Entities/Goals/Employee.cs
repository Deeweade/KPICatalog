using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace KPICatalog.Domain.Models.Entities.Goals;

[Table("Employee")]
public class Employee
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string TabNumber { get; set; }
    public string Fio { get; set; }
    public string PositionNum { get; set; }
    public string Position { get; set; }
    public string UnitNum { get; set; }
    public string UnitParentNum { get; set; }
    public string Unit { get; set; }
    public string City { get; set; }
    public string FuncManager { get; set; }
    public string AdmManager { get; set; }
    public string UnitManager { get; set; }
    public bool? Gender { get; set; }
    public bool? IsManager { get; set; }
    public int? State { get; set; }
    public bool? IsStaffMember { get; set; }
    public int? HeadOffice { get; set; }
    public bool? IsActive { get; set; }
    public DateTime? Birthday { get; set; }
    public DateTime? HireDate { get; set; }
    public int? AmountSubordinate { get; set; }
    public string Login { get; set; }
    public int? SpId { get; set; }
    public int? Parent { get; set; }
    public string Parents { get; set; }
    public int? Levels { get; set; }
    public int? BlockNum { get; set; }
    public string PhotoUrl { get; set; }
    public string BonusType { get; set; }
    public string FirstName 
    {
        get
        {
            return Fio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1];
        }
    }
    public string LastName
    {
        get
        {
            return Fio.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0];
        }
    }
}
