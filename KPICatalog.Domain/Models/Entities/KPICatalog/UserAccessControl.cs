namespace KPICatalog.Domain.Models.Entities.KPICatalog;

public class UserAccessControl : BaseEntity
{
    public string Login { get; set; }
    public bool IsAccessGranted { get; set; }
}
