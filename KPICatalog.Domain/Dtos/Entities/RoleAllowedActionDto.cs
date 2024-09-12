namespace KPICatalog.Domain.Dtos.Entities;

public class RoleAllowedActionDto
{
    public int Id { get; set; }
    public int RoleId { get; set; }
    public int ActionId { get; set; }

    public RoleDto Role { get; set; }
    public ActionDto Action { get; set; }
}
