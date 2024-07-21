namespace KPICatalog.Domain.Dtos.Entities;

public class UserAccessControlDto
{
    public string Login { get; set; }
    public bool IsAccessGranted { get; set; }
}
