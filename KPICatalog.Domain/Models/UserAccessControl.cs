﻿namespace KPICatalog.Domain;

public class UserAccessControl : BaseEntity
{
    public string? Login { get; set; }
    public bool IsAccessGranted { get; set; }
}
