namespace KPICatalog.Application.Models.Filters;

/// <summary>
/// Фильтр для метода GetByFilter в сервисе BonusSchemeService
/// Содержит свойства, задающие фильтрацию для выборки элементов на уровне Application и Infrastructure
/// </summary>
public class BonusSchemeFilterView
{
    /// <summary>
    /// Указывает, что должны быть выбраны только активные записи
    /// Обрабатывается репозиторием BonusSchemeRepository
    /// </summary>
    public bool? IncludeActiveOnly { get; set; }
}
