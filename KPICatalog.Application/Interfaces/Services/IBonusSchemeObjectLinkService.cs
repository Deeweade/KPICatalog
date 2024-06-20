﻿using KPICatalog.Application.Models.Views;

namespace KPICatalog.Application.Interfaces.Services;

public interface IBonusSchemeObjectLinkService
{
    Task<IEnumerable<BonusSchemeObjectLinkView>> CreateMany(BonusSchemeObjectLinkView linkView);
    Task<IEnumerable<BonusSchemeObjectLinkView>> DeleteEmployee(List<int> employeeIds);
}
