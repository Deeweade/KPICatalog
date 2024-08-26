using KPICatalog.Domain.Interfaces.Repositories;
using KPICatalog.Infrastructure.Utilities;
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Infrastructure.Data.Repositories.ExternalSources;

public class GoalsRepository : IGoalsRepository
{
    private readonly ExternalAPIClient _client;
    private readonly string _domainUrl;

    public GoalsRepository(ExternalAPIClient client, ExternalAPIConfiguration configuration)
    {
        _client = client;
        _domainUrl = configuration.MyGoalsUrl;
    }

    public async Task BulkUpdate(GoalsForEmployeesRequestDto data)
    {
        ArgumentNullException.ThrowIfNull(data);

        var url = _domainUrl + "Goals/UpdateEmployeesTypicalGoals";

        await _client.PostAsync<GoalsForEmployeesRequestDto, string>(url, data);
    }

    public async Task BulkDelete(GoalsForEmployeesRequestDto data)
    {
        ArgumentNullException.ThrowIfNull(data);

        var url = _domainUrl + "Goals/DeleteEmployeesTypicalGoals";

        await _client.PostAsync<GoalsForEmployeesRequestDto, string>(url, data);
    }
}
