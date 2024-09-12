namespace KPICatalog.Domain.Dtos.Filters;

public class EmployeeRolesQueryDto
{
    public List<int> RoleIds { get; set; }
    public List<int> EmployeeIds { get; set; }
}
