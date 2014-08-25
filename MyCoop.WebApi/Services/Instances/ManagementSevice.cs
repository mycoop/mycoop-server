using System.Linq;
using System.Threading.Tasks;
using MyCoop.Data;
using MyCoop.Repositories;
using MyCoop.WebApi.Models.OrgUnits;

namespace MyCoop.WebApi.Services.Instances
{
    public class ManagementSevice : ServiceBase, IManagementSevice
    {
        public ManagementSevice(IRepositoryManager repository)
            : base(repository)
        {
        }

        public Task<OrgUnitModel[]> GeOrgUnits()
        {
            return GetValues<OrgUnitModel, OrgUnit, IOrgUnitRepository>(orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<OrgUnitModel> GeOrgUnit(int id)
        {
            return GetValue<OrgUnitModel, OrgUnit, IOrgUnitRepository>(id, orgUnit => new OrgUnitModel(orgUnit));
        }

        public Task<int> AddOrgUnit(EditOrgUnitModel model)
        {
            return Add<OrgUnit, IOrgUnitRepository>(orgUnit => orgUnit.Id, model.GetEntity);
        }

        public Task UpdateOrgUnit(int id, EditOrgUnitModel model)
        {
            return Update<OrgUnit, IOrgUnitRepository>(id, orgUnit =>
            {
                var entity = model.GetEntity();
                orgUnit.Name = entity.Name;
                orgUnit.Address = entity.Address;
                orgUnit.OwnerId = entity.OwnerId;
                orgUnit.ParentId = entity.ParentId;
                orgUnit.ModificationTime = entity.ModificationTime;
                orgUnit.WorkspaceTemplateId = entity.WorkspaceTemplateId;
            });
        }

        public Task DeleteOrgUnit(int id)
        {
            return Delete<OrgUnit, IOrgUnitRepository>(id);
        }

        public Task<PermissionLevelModel[]> GetOrgUnitUserPermissions(int orgUnitId, int userId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IPermissionLevelRepository>().GetValuesForUser(orgUnitId, userId),
                values => values.Select(ug => new PermissionLevelModel(ug)).ToArray());
        }

        public Task<PermissionLevelModel[]> GetOrgUnitGroupPermissions(int orgUnitId, int groupId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IPermissionLevelRepository>().GetValuesForGroup(orgUnitId, groupId),
                values => values.Select(ug => new PermissionLevelModel(ug)).ToArray());
        }

        public Task AddOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            var entity = new OrgUnitUserPermission
            {
                OrgUnitId = orgUnitId,
                UserId = userId,
                PermissionLevelId = permissionId
            };

            var userGroupRepository = Repository.GetWithContext<IOrgUnitUserPermissionRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveOrgUnitUserPermission(int orgUnitId, int userId, int permissionId)
        {
            var entity = new OrgUnitUserPermission
            {
                OrgUnitId = orgUnitId,
                UserId = userId,
                PermissionLevelId = permissionId
            };

            var repository = Repository.GetWithContext<IOrgUnitUserPermissionRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }

        public Task AddOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            var entity = new OrgUnitGroupPermission
            {
                OrgUnitId = orgUnitId,
                GroupId = groupId,
                PermissionLevelId = permissionId
            };

            var userGroupRepository = Repository.GetWithContext<IOrgUnitGroupPermissionRepository>();
            userGroupRepository.Add(entity);

            return Repository.SaveChangesAsync();
        }

        public Task RemoveOrgUnitGroupPermission(int orgUnitId, int groupId, int permissionId)
        {
            var entity = new OrgUnitGroupPermission
            {
                OrgUnitId = orgUnitId,
                GroupId = groupId,
                PermissionLevelId = permissionId
            };

            var repository = Repository.GetWithContext<IOrgUnitGroupPermissionRepository>();
            repository.Attach(entity);
            repository.Delete(entity);

            return Repository.SaveChangesAsync();
        }

        public Task<PermissionLevelModel[]> GetOrgUnitPermissions(int orgUnitId)
        {
            return AsyncOperation(() => Repository.GetWithContext<IPermissionLevelRepository>().GetValuesForOrgUnit(orgUnitId),
                values => values.Select(ug => new PermissionLevelModel(ug)).ToArray());
        }
    }
}