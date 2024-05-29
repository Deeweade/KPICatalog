namespace KPICatalog.Domain.Models.Entities;

public class UserAccessControl : BaseEntity
{
    public string? Login { get; set; }
    public bool IsAccessGranted { get; set; }
}
