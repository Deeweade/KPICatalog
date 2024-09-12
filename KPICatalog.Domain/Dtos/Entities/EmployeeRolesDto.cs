namespace KPICatalog.Domain.Dtos.Entities;

public class EmployeeRolesDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int EmployeeId { get; set; }

    public RoleDto Role { get; set; }
    public EmployeeDto Employee { get; set; }
}
