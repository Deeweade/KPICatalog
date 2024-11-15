using System.Linq.Expressions;
using KPICatalog.Domain.Dtos.Entities;
using KPICatalog.Domain.Dtos.Filters;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface ITypicalGoalInBonusSchemeRepository
{
    /// <summary>
    /// Получение коллекции ТЦ в БС по Id типовой цели
    /// </summary>
    /// <param name="typicalGoalId">Id типовой цели</param>
    /// <returns>Возвращает коллекцию типовых целей в бонусной схеме</returns>
    Task<List<TypicalGoalInBonusSchemeDto>> GetByTypicalGoalId(int typicalGoalId);
    /// <summary>
    /// Получение коллекции ТЦ в БС по списку Id
    /// </summary>
    /// <param name="goalsIds">Список Id типовых целей в БС</param>
    /// <returns>Возвращает коллекцию типовых целей в бонусной схеме</returns>
    Task<List<TypicalGoalInBonusSchemeDto>> GetByIds(List<int> goalsIds);
    /// <summary>
    /// Получение коллекции ТЦ в БС по фильтрам
    /// </summary>
    /// <typeparam name="TResult">Свойство сущности или вся сущность</typeparam>
    /// <param name="queryDto">Филтры</param>
    /// <param name="select">Выражение, определяющее, что возвращать</param>
    Task<List<TResult>> GetByQuery<TResult>(TypicalGoalInBSQueryDto queryDto, 
        Expression<Func<TypicalGoalInBonusSchemeDto, TResult>> select = null);
    Task<TypicalGoalInBonusSchemeDto> Create(TypicalGoalInBonusSchemeDto goal);
    /// <summary>
    /// Множественное создание ТЦ в БС
    /// </summary>
    /// <param name="goalsInScheme">Список типовых целей в БС<</param>
    /// <returns>Возвращает коллекцию Id созданных записей</returns>
    Task<IEnumerable<int>> BulkCreate(List<TypicalGoalInBonusSchemeDto> goalsInScheme);
    /// <summary>
    /// Множественное изменение ТЦ в БС
    /// </summary>
    /// <param name="goalsInScheme">Список типовых целей в БС<</param>
    Task BulkUpdate(List<TypicalGoalInBonusSchemeDto> goals);
}