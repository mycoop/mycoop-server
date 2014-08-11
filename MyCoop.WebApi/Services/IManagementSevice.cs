using System.Threading.Tasks;
using MyCoop.WebApi.Models.OrgUnits;

namespace MyCoop.WebApi.Services
{
    public interface IManagementSevice
    {
        Task<OrgUnitModel[]> GeOrgUnits();
        Task<OrgUnitModel> GeOrgUnit(int id);
        Task<int> AddOrgUnit(EditOrgUnitModel model);

        Task UpdateOrgUnit(int id, EditOrgUnitModel model);

        Task DeleteOrgUnit(int id);
    }
}