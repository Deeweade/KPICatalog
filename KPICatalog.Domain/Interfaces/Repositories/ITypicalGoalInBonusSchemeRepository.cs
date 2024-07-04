using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface ITypicalGoalInBonusSchemeRepository
{
    /// <summary>
    /// Получение коллекции ТЦ в БС по Id типовой цели
    /// </summary>
    /// <param name="typicalGoalId">Id типовой цели</param>
    /// <returns>Возвращает коллекцию типовых целей в бонусной схеме</returns>
    Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByTypicalGoalId(int typicalGoalId);
    /// <summary>
    /// Получение коллекции ТЦ в БС по списку Id
    /// </summary>
    /// <param name="goalsIds">Список Id типовых целей в БС</param>
    /// <returns>Возвращает коллекцию типовых целей в бонусной схеме</returns>
    Task<IEnumerable<TypicalGoalInBonusSchemeDto>> GetByIds(List<int> goalsIds);
    Task<TypicalGoalInBonusSchemeDto> Create(TypicalGoalInBonusSchemeDto goal);
    /// <summary>
    /// Множественное создание ТЦ в БС
    /// </summary>
    /// <param name="goalsInScheme">Список типовых целей в БС<</param>
    /// <returns>Возвращает коллекцию Id созданных записей</returns>
    Task<IEnumerable<int>> BulkCreate(List<TypicalGoalInBonusSchemeDto> goalsInScheme);
}