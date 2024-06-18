namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserAccessControlRepository UserAccessControlRepository { get; set; }
    IBonusSchemeRepository BonusSchemeRepository { get; set; }
    IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; set; }
    IEmlpoyeeRepository EmployeeRepository { get; set; }
    ITypicalGoalRepository TypicalGoalRepository { get; set; }
}
