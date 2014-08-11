using System.Threading.Tasks;
using MyCoop.Data;

namespace MyCoop.Repositories
{
    public interface IOrgUnitRepository : IRepository<OrgUnit>
    {
        Task<OrgUnit[]> GeOrgUnits();

        Task<OrgUnit> GeOrgUnit(int id);
    }
}