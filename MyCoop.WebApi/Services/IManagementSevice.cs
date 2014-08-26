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

        Task<PermissionLevelModel[]> GetOrgUnitUserPermissions(int orgUnitId, int userId);

        Task<PermissionLevelModel[]> GetOrgUnitGroupPermissions(int orgUnitId, int groupId);

        Task AddOrgUnitUserPermission(int orgUnitId, int userId, int permissionId);

        Task RemoveOrgUnitUserPermission(int orgUnitId, int userId, int permissionId);

        Task AddOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId);

        Task RemoveOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId);

        Task<OrgUnitUserPermissionModel[]> GetUserOrgUnitPermissions(int orgUnitId);

        Task<OrgUnitGroupPermissionModel[]> GetGroupOrgUnitPermissions(int orgUnitId);
    }
}