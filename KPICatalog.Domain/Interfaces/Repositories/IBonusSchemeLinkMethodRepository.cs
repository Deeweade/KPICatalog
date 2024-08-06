
using KPICatalog.Domain.Dtos.Entities;

namespace KPICatalog.Domain.Interfaces.Repositories;

public interface IBonusSchemeLinkMethodRepository
{
    Task<List<BonusSchemeLinkMethodDto>> GetAll();
}
