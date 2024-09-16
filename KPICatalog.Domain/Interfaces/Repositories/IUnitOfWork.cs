using Microsoft.EntityFrameworkCore.Storage;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IUnitOfWork
{
    //KPICatalog
    IUserAccessControlRepository UserAccessControlRepository { get; }
    IBonusSchemeRepository BonusSchemeRepository { get; }
    IBonusSchemeObjectLinkRepository BonusSchemeObjectLinkRepository { get; }
    ITypicalGoalRepository TypicalGoalRepository { get; }
    ITypicalGoalInBonusSchemeRepository TypicalGoalInBonusSchemeRepository { get; }
    IWeightTypesRepository WeightTypesRepository { get; }
    IBonusSchemeLinkMethodRepository BonusSchemeLinkMethodRepository { get; }
    IPlanningCyclesRepository PlanningCyclesRepository { get; }
    IEvaluationMethodsRepository EvaluationMethodsRepository { get; }
    IEmployeeRolesRepository EmployeeRolesRepository { get; }
    IRoleAllowedActionsRepository RoleAllowedActionsRepository { get; }

    //PerfManagement
    IEmployeeRepository EmployeeRepository { get; }
    IPeriodsRepository PeriodsRepository { get; }

    Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);
    Task<int> SaveChangesAsync();
}
