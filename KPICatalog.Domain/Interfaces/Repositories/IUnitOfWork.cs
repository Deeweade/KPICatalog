namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserAccessControlRepository UserAccessControlRepository { get; }
    IBonusSchemeRepository BonusSchemeRepository { get; }
    IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; }
    IEmlpoyeeRepository EmployeeRepository { get; }
    ITypicalGoalRepository TypicalGoalRepository { get; }
}
