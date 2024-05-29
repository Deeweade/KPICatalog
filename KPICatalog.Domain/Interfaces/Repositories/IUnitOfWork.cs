namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserAccessControlRepository UserAccessControlRepository { get; set; }
    IBonusSchemeRepository BonusSchemeRepository { get; set; }
}
