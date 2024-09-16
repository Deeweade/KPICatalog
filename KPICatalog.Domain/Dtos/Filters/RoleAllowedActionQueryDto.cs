namespace KPICatalog.Domain.Dtos.Filters;

public class RoleAllowedActionQueryDto
{
    public List<int> ActionsIds { get; set; }
    public List<int> RolesIds { get; set; }
}
