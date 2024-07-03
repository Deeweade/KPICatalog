namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    IUserAccessControlRepository UserAccessControlRepository { get; }
    IBonusSchemeRepository BonusSchemeRepository { get; }
    IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; }
    ITypicalGoalRepository TypicalGoalRepository { get; }
    ITypicalGoalInBonusSchemeRepository TypicalGoalInBonusSchemeRepository { get; }

    IEmployeeRepository EmployeeRepository { get; }
    IPeriodsRepository PeriodsRepository { get; }

    Task<int> SaveChangesAsync();
}
